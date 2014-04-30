
using System;

public class Numeros
{
	public static void Main () 
	{
		int edad;
		string aux;

		Console.Write("Ingrese su edad: ");
		// edad = Convert.ToInt32(Console.ReadLine());
		// edad = int.Parse(Console.ReadLine());
		aux = Console.ReadLine();
		
		if (int.TryParse(aux, out edad)) {
			if (edad < 18)
				Console.WriteLine(edad + " y es menor de edad");
			else if (edad < 65)
				Console.WriteLine(edad + " y es mayor de edad");
			else
				Console.WriteLine(edad + " y es adulto mayor");
		}

		else {
			Console.WriteLine("Ingrese solo numeros");
		}
	}
}
