using System;
using System.Collections.Generic;

public class Grafo
{
    // Diccionario para almacenar la lista de adyacencia
    // clave: vértice, valor: lista de (destino, peso)
    private Dictionary<int, List<(int destino, int peso)>> listaAdyacencia;

    public Grafo()
    {
        listaAdyacencia = new Dictionary<int, List<(int, int)>>();
    }

    // Agrega un nuevo vértice al grafo
    public void AgregarVertice(int vertice)
    {
        if (!listaAdyacencia.ContainsKey(vertice))
        {
            listaAdyacencia[vertice] = new List<(int, int)>();
        }
    }

    // Agrega una arista no dirigida con peso opcional (default = 1)
    public void AgregarArista(int origen, int destino, int peso = 1)
    {
        if (!listaAdyacencia.ContainsKey(origen))
            AgregarVertice(origen);
        
        if (!listaAdyacencia.ContainsKey(destino))
            AgregarVertice(destino);
        
        listaAdyacencia[origen].Add((destino, peso));
        listaAdyacencia[destino].Add((origen, peso)); // Grafo no dirigido
    }

    // Muestra la estructura del grafo en consola
    public void MostrarGrafo()
    {
        Console.WriteLine("\nEstructura del grafo:");
        foreach (var vertice in listaAdyacencia)
        {
            Console.Write($"Nodo {vertice.Key} conectado a: ");
            foreach (var arista in vertice.Value)
            {
                Console.Write($"{arista.destino}(peso:{arista.peso}) ");
            }
            Console.WriteLine();
        }
    }

    // Calcula la centralidad por grado (número de conexiones por nodo)
    public Dictionary<int, int> CalcularCentralidadGrado()
    {
        var centralidad = new Dictionary<int, int>();
        
        foreach (var vertice in listaAdyacencia)
        {
            centralidad[vertice.Key] = vertice.Value.Count;
        }
        
        return centralidad;
    }

    // Muestra los resultados de centralidad ordenados
    public void MostrarCentralidad(Dictionary<int, int> centralidad)
    {
        Console.WriteLine("\nCentralidad por grado:");
        Console.WriteLine("| Nodo | Conexiones |");
        Console.WriteLine("|------|------------|");
        
        foreach (var item in centralidad)
        {
            Console.WriteLine($"| {item.Key,4} | {item.Value,10} |");
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Demo de análisis de grafos");
        
        // Crear grafo de ejemplo
        Grafo grafo = new Grafo();
        grafo.AgregarArista(1, 2);
        grafo.AgregarArista(1, 3);
        grafo.AgregarArista(2, 4);
        grafo.AgregarArista(3, 4);
        grafo.AgregarArista(4, 5);
        
        // Mostrar estructura
        grafo.MostrarGrafo();
        
        // Calcular y mostrar centralidad
        var centralidad = grafo.CalcularCentralidadGrado();
        grafo.MostrarCentralidad(centralidad);
        
        Console.WriteLine("\nPresione cualquier tecla para salir...");
        Console.ReadKey();
    }
}