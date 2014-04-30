
using System;

public class Caracteres
{
	public static void Main () 
	{
		Console.WriteLine("-- Tabla --\n");
		Console.WriteLine("+--------+----------+--------+----------+--------+----------+");
		Console.WriteLine("| Código | Caracter | Código | Caracter | Código | Caracter |");
		Console.WriteLine("+--------+----------+--------+----------+--------+----------+");

		for (int i = 32; i < 125;) {
			for (int j = 0; j < 3; j++) {
				Console.Write(string.Format("| {0,-6} | {1,-8} ", i, Convert.ToChar(i)));
				i++;
			}

			Console.WriteLine("|");
		}

		Console.WriteLine("+--------+----------+--------+----------+--------+----------+");
	}
}
