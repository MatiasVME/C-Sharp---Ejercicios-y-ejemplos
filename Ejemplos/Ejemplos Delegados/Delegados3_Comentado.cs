//
// Delegados3_Comentado.cs : Acceder a varios métodos estáticos y privados de la clase 
//	principal y otras clases a través de un objeto delegado.
//	También repasamos el añadir y quitar métodos a un objeto delegado con los 
//	operadores '=' y '+=' y los atajos que aparecieron en la versión 2.0 de C#.
//
// Compilar en Linux con Mono:
//	gmcs Delegados3_Comentado.cs
//
// Ejecutar:
//	mono Delegados3_comentado.exe
//

using System;

public class EstaClase
{
	public delegate void MiDelegado (int parametro1, int parametro2);

	public static void Main ()
	{
		Console.WriteLine ("Se inicia el programa");

		// Se crea una instancia de la clase 'OtraClase'
		OtraClase objOtraClase = new OtraClase ();

		Console.WriteLine ("Se añade al objeto delegado el método estático 'Metodo1DeOtraClase'");
		// Añadir a 'objDelegado' un método estático de 'OtraClase'
		// Para añadir un primer método a un objeto delegado, se usa el operador '=' . 
		// Pero esto vale solo para el primer método a añadir, el resto de los métodos se añaden 
		// con el operador '+=' .
		Console.WriteLine ("Se crea una instancia de la clase 'OtraClase'");
		MiDelegado objDelegado = new MiDelegado (OtraClase.Metodo1DeOtraClase);

		Console.WriteLine ("Se añade al objeto delegado el método no estático 'Metodo2DeOtraClase'");
		// Se añade 'Metodo2DeOtraClase' que no es estático. Ahora usamos el operador 
		//'+=' ya que no es el primer método a añadir.
		objDelegado += new MiDelegado (objOtraClase.Metodo2DeOtraClase);

		Console.WriteLine ("Se añade al objeto delegado el método estático 'Metodo1DeEstaClase'");
		// Se añade un método estático de esta clase. No hay para que referirse al nombre de esta
		objDelegado += new MiDelegado (Metodo1DeEstaClase);

		Console.WriteLine ("Se crea una instancia de la clase 'EstaClase'");
		// Crear una instancia de esta clase 'EstaClase'
		EstaClase objEstaClase = new EstaClase ();

		Console.WriteLine ("Se añade al objeto delegado el método no estático 'Metodo2DeEstaClase'");
		// Se añade un método publico de esta clase
		objDelegado += new MiDelegado (objEstaClase.Metodo2DeEstaClase);

		Console.WriteLine ("Se llama a objDelegado objDelegado (8, 3);");
		// Llamar a un método estático que se almacena en 'objDelegado'	
		objDelegado (8, 3);
		
		// Ahora, llamamos a los métodos que están relacionados con los métodos de
		// 'objEstaClase' y los de 'objOtraClase'. Se vió que a 'objDelegado' al llamarlo no le
		// importa si los métodos a añadir son estáticos o públicos.

		// Ahora veremos algunos atajos para añadir métodos a un objeto delegado que se añadieron en la
		// versión 2.0 del lenguaje C# . Es importante tener en cuenta estos atajos para usarlos y también
		// leer código de otros programadores.
		objDelegado += objEstaClase.Metodo2DeEstaClase;
		objDelegado += OtraClase.Metodo1DeOtraClase;
		
		// Ejecutando el delegado
		objDelegado (10, 20);
	}

	public static void Metodo1DeEstaClase (int parametro1, int parametro2)
	{
		Console.WriteLine ("Se a llamado a un método estático 'Metodo1DeEstaClase' de esta clase");
		Console.WriteLine ("Muestra estos argumentos: {0} y {1}", parametro1, parametro2);
	}
	
	public void Metodo2DeEstaClase (int parametro1, int parametro2)
	{
		Console.WriteLine ("Se a llamado a 'Metodo2DeOtraClase' de esta clase");
		Console.WriteLine ("Muestra estos argumentos: {0} y {1}", parametro1, parametro2);
	}
}

public class OtraClase
{
	public static void Metodo1DeOtraClase (int parametro1, int parametro2)
	{
		Console.WriteLine ("Se a llamado a un método estático 'Metodo1DeOtraClase' de la clase 'OtraClase'");
		Console.WriteLine ("Muestra estos argumentos: {0} y {1}", parametro1, parametro2);
	}	

	public void Metodo2DeOtraClase (int parametro1, int parametro2)
	{
		Console.WriteLine ("Se a llamado a 'Metodo2DeOtraClase' de un objeto de la clase OtraClase");
		Console.WriteLine ("Muestra estos argumentos: {0} y {1}", parametro1, parametro2);
	}
}
