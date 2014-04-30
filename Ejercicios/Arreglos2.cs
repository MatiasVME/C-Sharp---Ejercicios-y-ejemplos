using System;

public class Arreglos
{
	public static void Main () 
	{
		int cuantos;
		int [] numeros = {32, 31, 23, 32, 4, 34};

		Console.Write("¿Cuantos numeros quiere ingresar?: ");
		cuantos = int.Parse(Console.ReadLine());

		Array.Resize(ref numeros, cuantos);

		for (int i = 0; i < cuantos; i++) {
			Console.WriteLine("Ingrese Elementos[" + i + "]: ");
			numeros[i] = int.Parse(Console.ReadLine());
		}
	}

	public static int Sumar (int [] numeros)
	{
		int suma = 0;

		for (int i = 0; i < numeros.Length; i++) {
			suma = suma + numeros[i];
		}

		return suma;
	}
}
