
using System;

public class Numeros
{
	public static void Main () 
	{
		int edad;

		Console.Write("Ingrese su edad: ");
		// edad = Convert.ToInt32(Console.ReadLine());
		edad = int.Parse(Console.ReadLine());
		Console.WriteLine("Su edad es: " + edad);
	}
}
