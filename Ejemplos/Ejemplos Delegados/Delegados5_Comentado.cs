//
// Delegados5_Comentado.cs : Hacer llamadas asíncronas usando delegados
//
// Compilar en Linux con Mono:
//	gmcs Delegados5_Comentado.cs
//
// Compilar en Linux con Mono en C# 5:
//	gmcs -langversion:future Delegados5_Comentado.cs
//
// Ejecutar:
//	mono Delegados5_comentado.exe

// Recordar que en el namespace System están definidos todos las clases para el
// tratamiento de las llamadas asíncrona y también síncrona.
using System;

// Creamos un tipo delegado común y corriente 
delegate void DelegadoAsíncronas (string str);

class Test
{
	public static void Main ()
	{
		// Creamos un objeto delegado común 'objDA' y le asignamos el método 'Metodo1'
		DelegadoAsíncronas objDA = new DelegadoAsíncronas (Metodo1);
		// El objeto 'objDA' solo debe contener un solo método almacenado si luego se quiere
		// hacer una llamada asíncrona.

		// Se crea un objeto 'AsyncCallback' y se le añade un método 'Metodo2', para luego
		// enviarle este objeto con su método referenciado al objeto delegado 'objDA' que creamos
		// anteriormente.
		// A continuación se indica que es AsyncCallvack :
		// public delegate void AsyncCallback (IAsyncResult ar)
		AsyncCallback objAC = new AsyncCallback (Metodo2);
	
		// Almacena información relativa al método que será llamado de forma asíncrona:
		// public interface System.IAsyncResult
		// Se puede saber si el método asíncrona se termino de ejecutar con la propiedad:
		// public  bool IsCompleted [solo lectura]
		// Se puede saber si el método asíncrona se terminó de ejecutar de manera sícrona con:
		// public bool CompletedSyncronously [solo lectura]
		IAsyncResult objIAR;

		// Lanza la llamada al 'Metodo2' que está contenida en el objeto delegado 'objAC' de
		// manera asíncrona. el 'Metodo2' se ejecuta de manera asíncrona (en un hilo de ejecución
		// a parte), pero el método que referencia 'objDA' se ejecuta de manera síncrona.
		// 'IAsyncResult' almacenará información relacionada a ese hilo :
		// IAsyncResult BeginInvoke (<parámetros>, AsyncCallback cb, Object o)
		// En <parámetros> van los parámetros del típo delegado. 
		objIAR = objDA.BeginInvoke ("Hola", objAC, "Hola2");
		// 'objAC' contiene el o los métodos que se quiere que sean asíncronos. '"Hola2"' es
		// un argumento opcional que se le puede enviar a los métodos a ejecutar de forma 
		// asíncrona. Es opcional, puede ir tanto '"Hola2"' como 'null'.

		// Cuando se ejecuta el método EndInvoke se muestran los resultados de los métodos
		// llamados, las excepciones que hubieron (si es que hubieron), etc.
		// <tipoRetorno> EndInvoke (<parámetrosRefOut>, IASyncResult ar)
		objDA.EndInvoke (objIAR);

		// Si se terminó de ejecutar el hilo o no
		if (objIAR.IsCompleted)
			Console.WriteLine ("Se termino la llamada asíncrona");
		else
			Console.WriteLine ("Aún no termina la llamada asíncrona");

		// Si se terminó de ejecutar el hilo de manera síncrona. Se usa, ya que puede que
		// existan excepciones de las cuales no se informe. Pero esas excepciones se
		// informarán si se utiliza el método EndInvoque.
		if (objIAR.CompletedSynchronously)
			Console.WriteLine ("El hilo se termino de forma síncrona");
		// Si se termino de ejecutar el hilo de manera asíncrona
		else if (objIAR.CompletedSynchronously == false)
			Console.WriteLine ("El hilo se termino de forma asíncrona");
			
		// Espera a que se presione una tecla
		Console.Read ();
	}

	public static void Metodo1 (string str)
	{
		Console.WriteLine ("Desde Metodo1: {0}",str);
	}
	
	public static void Metodo2 (IAsyncResult obj)
	{
		// Se obtiene el objeto proporcionado al empezar la ejecución de la operación asíncrona :
		// public object AsyncState [solo lectura]
		Console.WriteLine ("Desde Metodo2: {0}", obj.AsyncState);
	}
}
