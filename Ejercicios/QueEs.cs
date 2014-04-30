
using System;

public class Numeros
{
	public static void Main () 
	{
		char letra;
		Console.Write("Ingrese una letra: ");
		letra = System.Console.ReadKey().KeyChar;
		letra = char.ToLower(letra);

		if (char.IsLetter(letra)) {
			Console.WriteLine("\nEs letra");

			if (letra == 'a' 
				|| letra == 'e'
				|| letra == 'i'
				|| letra == 'o'
				|| letra == 'u') {
				Console.WriteLine("Es vocal");
			}

			else {
				Console.WriteLine("Es consonante");
			}
		}

		else if (char.IsDigit(letra))
			Console.WriteLine("\nEs digito");
		else if (char.IsPunctuation(letra))
			Console.WriteLine("\nEs puntuacion");
		else 
			Console.WriteLine("\nDigitó otro caracter");
	}
}
