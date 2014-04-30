
using System;

public class Ciclos
{
	public static void Main () 
	{
		Console.WriteLine("Codigo  -- Caracter");

		for (int i = 125; i >= 32; i--) {
			Console.WriteLine("   {0}   --    {1}  ", i, Convert.ToChar(i));
		}
	}
}
