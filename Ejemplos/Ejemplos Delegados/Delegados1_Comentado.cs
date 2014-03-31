//
// Delegados1_Comentado.cs : Ejemplo mínimo sobre delegados.
//
// Compilar en Linux con Mono:
//	gmcs Delegados1_Comentado.cs
//
// Ejecutar:
//	mono Delegados1_comentado.exe

using System;

// Un delegado puede estar dentro de una clase, fuera de una clase, dentro de
// un namespace o fuera de un namespace.

// Se crea y define el -tipo- delegado, en la definición (o firma) de un tipo delegado
// se consideran: el tipo de retorno, número de parámetros y el tipo de los parámetros,
// con estas características deben cumplir los métodos que luego se asignarán.
// Para crear un delegado se usa la palabra clave delegate
public delegate int MiDelegado (int parametro);  // Es muy similar a declarar un método


public class Programa
{
	public static void Main ()
	{
		Console.WriteLine ("Se inicia el programa");

		// Se crea un objeto de la clase 'OtraClase'
		OtraClase objOtraClase = new OtraClase ();

		// Se crea un objeto delegado y se le asigna un método, en este ejemplo le
		// asignamos solo un método, pero se le pueden asignar más.
		// Crear un objeto delegado es muy similar a crear un objeto con una clase, la 
		// diferencia es que le asignamos un método, en ves de argumentos.
		// El método no se esta llamando por eso no se utiliza los paréntesis 
		// 'objOtraClase.Metodo1' 
		MiDelegado objDelegado = new MiDelegado (objOtraClase.Metodo1);

		// Se crea una variable de tipo int y se le asigna el valor de retorno
		// del objeto delegado, que es el mismo retorno de el método anteriormente asignado
		int retorno = objDelegado (5); // Se hace la llamada de la misma forma que un método

		// Muestra el valor de retorno
		Console.WriteLine ("El valor devuelto es {0}", retorno); 
	}
}

public class OtraClase
{
	// Este método cumple con la firma del delegado (al cual se lo asignamos)
	public int Metodo1 (int a)
	{
		Console.WriteLine ("Soy Metodo1 y mi argumento es: {0}", a);
		return a + 10;
	}
}
