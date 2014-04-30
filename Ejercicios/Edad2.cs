
using System;

public class Numeros
{
	public static void Main () 
	{
		int edad;
		string aux;

		do {
			Console.Clear();
			Console.WriteLine("Debe ingresar solo numeros");
			Console.WriteLine("Ingrese su edad: ");
			aux = Console.ReadLine();

			if (int.TryParse(aux, out edad) == false) {
				Console.WriteLine("Debe ingresar solo numeros");
				Console.ReadKey();
			}
		}
		while (!(int.TryParse(aux, out edad)));
	}
}
