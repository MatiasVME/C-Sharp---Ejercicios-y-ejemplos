//
// Delegados4_Comentado.cs : Ejemplo puramente teórico que muestra como manejar las listas 
//	de métodos que referencian los objetos delegados para saber sus métodos y su
//	clase, combinar dos objetos delegados y ejecutar todos los métodos que referencia
//	un objeto delegado.
//
// Compilar en Linux con Mono:
//	gmcs Delegados4_Comentado.cs
//
// Ejecutar:
//	mono Delegados4_comentado.exe

using System;
using System.Reflection;

delegate int MiTipoDelegado (int Parametro);

public class Programa
{
	public static void Main ()
	{
		Console.WriteLine ("Se inicia el programa\n");

		OtraClase objOtraClase = new OtraClase ();

		//	Ya que la palabra clave 'delegate' representa una clase sellada
		//	'System.MulticastDelegate', sus intancias pueden ser inicializadas como cualquier
		//	otra clase.
		//	Entonces ->
		//	MiTipoDelegado miObjDelegado1 = new MiTipoDelegado (objOtraClase.Metodo1);
		//	Es lo mismo que -->
		MiTipoDelegado miObjDelegado1 = objOtraClase.Metodo1;

		miObjDelegado1 += objOtraClase.Metodo2;
		
		MiTipoDelegado miObjDelegado2 = objOtraClase.Metodo3;
		
		//	Este es el objeto delegado que contendra los métodos de 'miObjDelegado1'
		//	y también los de 'miObjDelegado2'. Es importante asignarle un valor nulo (null)
		MiTipoDelegado miObjDelegado3 = null;

		//	Información sobre los objetos delegados tratados gracias a la clase
		//	'TratarDelegados'
		Console.WriteLine ("Mostrar información de 'miObjDelegado1'");
		TratarDelegados.InformaciónObjDelegado (miObjDelegado1);
		Console.WriteLine ("\nMostrar información de 'miObjDelegado2'");
		TratarDelegados.InformaciónObjDelegado (miObjDelegado2);
		Console.WriteLine ("\nMostrar información de 'miObjDelegado3'");
		TratarDelegados.InformaciónObjDelegado (miObjDelegado3);
		
		//	Combinar los objetos delegados que contienen métodos, para que los contenga
		//	un solo objeto delegado. Y mostrar información de los objetos delegados.
		Console.WriteLine ("\nLuego de combinar los objetos delegados 'miObjDelegado1'");
		Console.WriteLine ("y 'miObjDelegado2' en 'miObjDelegado3'");
		miObjDelegado3 += miObjDelegado1 + miObjDelegado2;
		Console.WriteLine ("\nMostrar información de 'miObjDelegado3'");
		TratarDelegados.InformaciónObjDelegado (miObjDelegado3);
		
		//	Llamar a todos los métodos de 'miObjDelegado3'
		Console.WriteLine ("\nLlamar a los métodos de 'miObjDelegado3'");
		miObjDelegado3 (5);
	}
}

public class OtraClase
{
	public int Metodo1 (int a)
	{
		int retorno = a + 10;

		Console.WriteLine ("Soy Metodo1 y mi argumento es: {0} y retorno: {1}", 
		  a, retorno);
		
		return retorno;
	}

	public int Metodo2 (int a)
	{
		int retorno = a + 20;

		Console.WriteLine ("Soy Metodo2 y mi argumento es: {0} y retorno: {1}", 
		  a, retorno);
		
		return retorno;
	}
	
	public int Metodo3 (int a)
	{
		int retorno = a + 30;

		Console.WriteLine ("Soy Metodo3 y mi argumento es: {0} y retorno: {1}", 
		  a, retorno);
		
		return retorno;
	}
}

public class TratarDelegados
{

	public static void InformaciónObjDelegado (Delegate objDel)
	{
		Console.WriteLine ("Información del objeto delegado");
		
		if (objDel == null) {
			Console.WriteLine ("\tEl objeto delegado no referencia a ningún método");
			return;
		}
		
		foreach (Delegate d in objDel.GetInvocationList ()) {
			Console.WriteLine ("\tNombre del método: {0}", d.Method);
			Console.WriteLine ("\tNombre de su clase: {0}", d.Target);
		}
	}
}