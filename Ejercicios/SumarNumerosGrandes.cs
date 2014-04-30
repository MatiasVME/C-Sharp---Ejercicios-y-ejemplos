using System;

public class SumarNumerosGrandes
{
	public static void Main ()
	{
		string bigNum1;
		string bigNum2;

		Console.WriteLine("Escriba numero 1: ");
		bigNum1 = Console.ReadLine();
		Console.WriteLine("Escriba numero 2: ");
		bigNum2 = Console.ReadLine();

		Sumar(bigNum1, bigNum2);
	}

	public static void Sumar (string n1, string n2)
	{
		byte [] numero = new byte [n1.Length + 1];
		int num1 = 0;
		int num2 = 0;
		int reserva = 0;
		int total = 0;

		for (int i = numero.Length - 2; i >= 0; i--) {	
			num1 = Convert.ToInt32(char.GetNumericValue(n1[i]));
			num2 = Convert.ToInt32(char.GetNumericValue(n2[i]));
			
			total = num1 + num2 + reserva;

			if (total >= 10) {
				// Almacena la reserva para sumarla en la siguiente interación
				reserva = total / 10;
				numero[i] = (byte) (total % 10);
			}

			else {
				numero[i] = (byte) total;
				reserva = 0;
			}
		}

		Console.WriteLine("Resultado: ");
		
		if (reserva == 1)
			Console.Write(reserva);
		
		for (int i = 0; i < numero.Length - 1; i++)
			Console.Write(numero[i]);

		Console.WriteLine();
	}
}
