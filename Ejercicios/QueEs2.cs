
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
			switch (letra) {
				case 'a':
					Console.WriteLine("\nEs vocal");
					break;
				case 'e':
					Console.WriteLine("\nEs vocal");
					break;
				case 'i':
					Console.WriteLine("\nEs vocal");
					break;
				case 'o':
					Console.WriteLine("\nEs vocal");
					break;
				case 'u':
					Console.WriteLine("\nEs vocal");
					break;
				default:
					Console.WriteLine("Es consonante");
					break;
			}
		}
	}
}
