using System;

public class Arreglos
{
	public static void Main () 
	{
		int [] numeros = {32, 2, 32, 42, 423, 2, 1};

		Console.WriteLine("Numero de elementos: " + numeros.Length);
		Console.WriteLine("Primer elemento: " + numeros[0]);
		Console.WriteLine("Último elemento: " + numeros[numeros.Length - 1]);
		Console.Write("Los elementos del array son: ");
		for (int i = 0; i < numeros.Length; i++)
			Console.Write(numeros[i] + " ");
		Console.WriteLine();
	}
}
