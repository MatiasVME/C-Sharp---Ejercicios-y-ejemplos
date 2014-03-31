//
// Delegados2_Comentado.cs : Añadir y quitar métodos a un objeto delegado.
// 
// Compilar en Linux con Mono:
//	gmcs Delegados2_Comentado.cs
//
// Ejecutar:
//	mono Delegados2_comentado.exe
//

using System;

public class Programa
{
	// Se crea y define un tipo delegado, tambén se puede definir dentro de una clase.
	// Se define el tipo delegado, tipo de retorno, numero de parámetros y tipos de parámetros. Los
	// métodos a asignar al objeto delegado deben cumplir con esta firma o definición.
	public delegate void TipoDelegado ();

	public static void Main ()
	{
		Console.WriteLine ("Se inicia el programa");

		// Se crea una objeto de la clase Programa
		Programa objPrograma = new Programa ();
		
		// Se crea un objeto de el tipo delegado y se le añade un método. No importa si el método es de
		// un objeto de la propia clase.
		TipoDelegado objDelegado = new TipoDelegado (objPrograma.Metodo1); 

		// Se añade al objeto delegado un método, ahora el objeto delegado tendrá 2 métodos añadidos.
		// Al añadir un primer método a un delegado se puede usar el operador de asignación '=' pero
		// si quisiéramos añadir otro método se tiene que usar el operador '+=' , como lo siguiente.
		objDelegado += new TipoDelegado (objPrograma.Metodo2);

		Console.WriteLine ("Se llamará al objeto delegado con los métodos ya asignados");	
		objDelegado ();

		Console.WriteLine ("Se llamará al objeto delegado después de quitar Metodo2");
		// Quitar el método 'Metodo2' y luego llamar al objeto delegado
		objDelegado -= new TipoDelegado (objPrograma.Metodo2);		
		objDelegado ();

		// Se puede añadir el mismo método más de una vez
		Console.WriteLine ("Se añade el Metodo1, que ya se añadió");
		objDelegado += new TipoDelegado (objPrograma.Metodo1);
	}

	// Observa que los métodos cumplen con la definición del tipo delegado
	public void Metodo1 ()
	{
		Console.WriteLine ("Soy Metodo1");
	}

	public void Metodo2 ()
	{
		Console.WriteLine ("Soy Metodo2");
	}
}