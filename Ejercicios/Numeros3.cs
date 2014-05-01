/*
	-Preguntar al usuario cuantos numeros quiere ingresar
	-leer los numeros
	-calcular el promedio
	-mostrar el numero minimo y maximo
	-ordenarlos utilizando el metodo de la burbuga
 */

using System;

public class Numeros3
{
	public static void Main () 
	{
		Console.Write("Cuantos numeros desea ingresar: ");

		int cantNumeros = 0;
		bool esNumero = false;

		// Ingresar cantidad de numeros con validación
		//

		do {
			esNumero = int.TryParse(Console.ReadLine(), out cantNumeros);
			if (!esNumero) {
				Console.WriteLine("-- Ingrese solo numeros --");
				Console.Write("Ingrese un numero: ");
			}
		} while (!esNumero);

		int [] numeros = new int [cantNumeros];
		esNumero = false;

		// Ingresar cada numero con validación
		//

		for (int i = 0; i < numeros.Length; i++) {
			do {
				Console.Write("numeros[" + i + "]: ");
				esNumero = int.TryParse(Console.ReadLine(), out numeros[i]);

				if (!esNumero) {
					Console.WriteLine("-- Ingrese solo numeros --");
				}
			} while (!esNumero);
		}

		// Calcular promedio
		//

		// Sumar numeros

		int acumulador = 0;

		foreach (int i in numeros)
			acumulador += i;

		// Calcular promedio
		float promedio = (float) acumulador / cantNumeros;

		Console.WriteLine("El promedio es: " + promedio);

		// Mostrar el mínimo y el maximo
		//

		// Minimo

		int min = int.MaxValue;

		foreach (int numero in numeros) {
			if (numero < min)
				min = numero;
		}

		Console.WriteLine("El numero menor es: " + min);

		// Maximo

		int max = int.MinValue;

		foreach (int numero in numeros) {
			if (numero > max)
				max = numero;
		}

		Console.WriteLine("El numero mayor es: " + max);

		// Ordenamiento burbuja
		//

		Ordena.OrdBurb(numeros);

    	// Mostrar numeros ordenados

    	Console.WriteLine("Los numeros ordenados son los siguientes: ");
    	foreach (int numero in numeros)
    		Console.Write(numero + " ");
    	Console.WriteLine();
	}
}

public class Ordena
{
	public static void OrdBurb (int [] nums)
	{
		int aux;

		for (int i = 1; i < nums.Length; i++) {
			for (int j = 0; j < nums.Length - i; j++) {
				if (nums[j] > nums[j + 1]) {
					aux = nums[j];
					nums[j] = nums[j + 1];
					nums[j + 1] = aux;
				} 
			}
		}
	}
}
