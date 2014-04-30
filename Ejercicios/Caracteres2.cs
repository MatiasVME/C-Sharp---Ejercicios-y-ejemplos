
using System;

public class Numeros
{
	public static void Main () 
	{
		Console.WriteLine ("Ingrese su nombre completo: ");
		string nombreCompleto = Console.ReadLine();

		Console.WriteLine("Caracter -- Código");

		for (int i = 0; i < nombreCompleto.Length; i++)
			Console.WriteLine("{0}        -- {1}     ", nombreCompleto[i], Convert.ToInt32(nombreCompleto[i]));
	}
}
