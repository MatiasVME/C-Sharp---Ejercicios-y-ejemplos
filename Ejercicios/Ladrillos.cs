
/*
 * Supongamos que se consruye una escalera usando ladrillos, tal
 * como se muestra en la figura:
 *
 *       []
 *     [][]
 *   [][][]
 * [][][][]
 *
 * Cree un método que devuelva la cantiad de ladrillos totales, según
 * el número de columnas que se decida crear para la escalera. Por
 * ejemplo si se le pasan 4 columnas abrán 10 ladrillos.
 *
 * El método debe tener la siguiente forma:
 * 		public static int CantLadrillos (int col)
 */


using System; 

public class Ladrillos 
{
	public static void Main () 
	{
		int col = 0;

		Console.WriteLine ("Introdusca el numero de columnas de la escalera:");
		col = int.Parse(Console.ReadLine());

		int cantLadrillos = 0;
		cantLadrillos = CantLadrillos (col);

		Console.WriteLine ("Columnas: " + col + "\n" 
			+ "Cantidad de Ladrillos: " + cantLadrillos);
	}

	public static int CantLadrillos (int col)
	{
		int cantLadrillos = 0;

		for (int i = 0; i <= col; i++) {
			cantLadrillos = cantLadrillos + (col - i);
		}

		return cantLadrillos;
	}
}