using System;
using System.Collections.Generic;

class Program
{
    // Función para resolver el problema de las Torres de Hanoi utilizando pilas
    static void TorresDeHanoi(int numDiscos, Stack<int> origen, Stack<int> destino, Stack<int> auxiliar, char torreOrigen, char torreDestino, char torreAuxiliar)
    {
        // Caso base: si solo hay un disco, lo movemos directamente
        if (numDiscos == 1)
        {
            destino.Push(origen.Pop());
            Console.WriteLine($"Mover disco de {torreOrigen} a {torreDestino}");
            return;
        }

        // Mover los discos superiores de la torre de origen a la torre auxiliar
        TorresDeHanoi(numDiscos - 1, origen, auxiliar, destino, torreOrigen, torreAuxiliar, torreDestino);

        // Mover el disco restante de la torre de origen a la torre destino
        destino.Push(origen.Pop());
        Console.WriteLine($"Mover disco de {torreOrigen} a {torreDestino}");

        // Mover los discos de la torre auxiliar a la torre destino
        TorresDeHanoi(numDiscos - 1, auxiliar, destino, origen, torreAuxiliar, torreDestino, torreOrigen);
    }

    // Función principal para probar las Torres de Hanoi
    static void Main()
    {
        int numDiscos = 3; // Número de discos
        Stack<int> torreA = new Stack<int>(); // Torre de origen
        Stack<int> torreB = new Stack<int>(); // Torre de destino
        Stack<int> torreC = new Stack<int>(); // Torre auxiliar

        // Inicializamos la torre de origen con los discos en orden descendente
        for (int i = numDiscos; i >= 1; i--)
        {
            torreA.Push(i);
        }

        // Llamada a la función para resolver el problema
        TorresDeHanoi(numDiscos, torreA, torreB, torreC, 'A', 'B', 'C');
    }
}
