// Ejemplo copiado del libro "Pro C Sharp 2010 and the dotNet 4 Platform 5th
// Edition - Andrew Troelsen - Apress" página 405 del libro. Traducido, comentado, 
// editado por Writkas
//
// Car--Ejemplo.cs : 	Ejemplo que muestra como usar delegados para facilitar el
//	uso de eventos. Este ejemplo no muestra como usar eventos, lo que trata de
//	mostrar, es un ejemplo en el que podría ser útil el uso de delegados, un
//	ejemplo más o menos real.
//	En resumen el ejemplo trata sobre un auto que va subiendo la velocidad y a
//	traves de notificaciones 'personalizadas' nos avisa del peligro, y estado del
//	auto. Al chocar el auto, suponemos que alguien ejecuta la caja negra del auto
//	y se dencadenan los mensajes (métodos) registrados.
//
// Compilar :			gmcs Car--Ejemplo.cs

using System;

public class Program 
{
	public static void Main ()
	{
		Console.WriteLine ("***** Delegados para facilitar eventos *****\n");

		// Crear un objeto de la clase "Car".
		Car c1 = new Car (100, 10);

		// Hay que decirle al objeto "c1" cual es el método a llamar (OnCarEngineEvent)
		// cuando se nos envíe un mensaje o notificación. Debe cumplir con la firma.
		c1.RegisterWithCarEngine (new Car.CarEngineHandler (OnCarEngineEvent));

		// Subir velocidad (este es el punto de partida para luego recibir eventos o
		// mensajes). (el bucle for no tiene llaves por que tiene una sola linea de
		// código y se puede hacer eso)
		Console.WriteLine ("***** subir velocidad *****");
		for (int i = 0; i < 6; i++)
			c1.Accelerate (20);

		Console.ReadLine ();
	}

	// Este es nuestro método personalizado que le enviaremos a el objeto delegado. 
	public static void OnCarEngineEvent (string msg)
	{
		Console.WriteLine ("\n****** mensaje desde el objeto c1 *****");
		Console.WriteLine ("=> {0}", msg);
		Console.WriteLine ("************************************\n");
	}
}

public class Car
{
	// 1) Definir un tipo delegado.
	public delegate void CarEngineHandler (string msgForCaller);
	// 2) Definir un objeto delegado miembro de esta clase.
	private CarEngineHandler listOfHandlers;
	// 3) Añadir una función registro para el llamador.
	// Se le envía un objeto delegado (el creado con new, anteriormente) y se copia
	// ese objeto delegado al del objeto delegado de esta clase.
	public void RegisterWithCarEngine (CarEngineHandler methodToCall)
		{ listOfHandlers = methodToCall;}

	// Estados de las variables internas
	public int CurrentSpeed {get; set;} // Velocidad común
	public int MaxSpeed {get; set;} // Velocidad máxima

	// El auto esta vivo?
	private bool carIsDead;
  
	// Constructores de la clase
	public Car () 
	{
		MaxSpeed = 100; 
	}
	
	public Car (int maxSp, int currSp)
	{
		CurrentSpeed = currSp;
		MaxSpeed = maxSp;
	}

	public void Accelerate (int delta)
	{
		// ¿Si, este auto esta muerto?, enviar el mensaje de que está muerto.
		if (carIsDead) {
			// ¿Si, el objeto delegado 'listOfHandlers' no tiene métodos y es null?
			if (listOfHandlers != null)
				listOfHandlers ("este auto esta muerto...");
		}

		else {
			CurrentSpeed += delta;

			// ¿Si, este auto está casi muerto?
			if (10 == (MaxSpeed - CurrentSpeed) && listOfHandlers != null)
				listOfHandlers ("¡cuidado! va a chocar");
			// ¿Si, este auto va a más velocidad del limite o igual velocidad?
			if (CurrentSpeed >= MaxSpeed)
				carIsDead = true;
			else
				Console.WriteLine ("CurrentSpeed = {0}", CurrentSpeed);
		}
	}
}