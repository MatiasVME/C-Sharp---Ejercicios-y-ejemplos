using System;

public class Arreglos3
{
	public static void Main ()
	{
		// Ingresar cantidad de numeros con validación
		//
		
		Console.Write("¿Cuantos numeros desea ingresar?: ");

		int cantNumeros = 0;
		bool esNumero = false;

		do {
			esNumero = int.TryParse(Console.ReadLine(), out cantNumeros);
			if (!esNumero) {
				Console.WriteLine("-- Ingrese solo numeros --");
				Console.Write("Ingrese un numero: ");
			}
		} while (!esNumero);

		// Ingresar cada numero con validación
		//

		int [] numeros = new int [cantNumeros];
		esNumero = false;

		for (int i = 0; i < numeros.Length; i++) {
			do {
				Console.Write("numeros[" + i + "]: ");
				esNumero = int.TryParse(Console.ReadLine(), out numeros[i]);

				if (!esNumero) {
					Console.WriteLine("-- Ingrese solo numeros --");
				}
			} while (!esNumero);
		}

		// Resultado
		//

		foreach (int num in numeros) {
			if (Numeros.EsPar(num)) {
				Console.Write("El " + num + " es par y ");
			}

			else {
				Console.Write("El " + num + " es impar y ");
			}

			if (Numeros.EsPrimo(num)) {
				Console.WriteLine("primo");
			}

			else {
				Console.WriteLine("no primo");
			}
		}
	}
}

public class Numeros
{
	public static bool EsPar (int num)
	{
		bool result = false;
		if (num % 2 == 0) result = true;
		return result;
	}

	public static bool EsPrimo (int num)
	{
		bool result = false;
		int a = 0;

		for (int i = 1; i < (num + 1); i++){  
        	if (num % i == 0)  
            	a++;
        }

        if (a == 2)
        	result = true;

		return result;
	}
}