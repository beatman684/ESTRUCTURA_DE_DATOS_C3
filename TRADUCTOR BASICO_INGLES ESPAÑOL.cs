using System;
using System.Collections.Generic;

class Traductor
{
    // Diccionario para almacenar palabras en inglés y su traducción en español
    static Dictionary<string, string> diccionario = new Dictionary<string, string>()
    {
        {"time", "tiempo"}, {"person", "persona"}, {"year", "año"},
        {"way", "camino"}, {"day", "día"}, {"thing", "cosa"},
        {"man", "hombre"}, {"world", "mundo"}, {"life", "vida"},
        {"hand", "mano"}, {"part", "parte"}, {"child", "niño/a"},
        {"eye", "ojo"}, {"woman", "mujer"}, {"place", "lugar"},
        {"work", "trabajo"}, {"week", "semana"}, {"case", "caso"},
        {"point", "punto"}, {"government", "gobierno"}, {"company", "empresa"}
    };

    static void Main()
    {
        int opcion;
        do
        {
            // Mostrar menú de opciones
            Console.WriteLine("\nMENU");
            Console.WriteLine("========================================");
            Console.WriteLine("1. Traducir una frase");
            Console.WriteLine("2. Agregar palabras al diccionario");
            Console.WriteLine("0. Salir");
            Console.Write("Seleccione una opción: ");
            
            // Leer opción del usuario
            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción inválida, intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    TraducirFrase();
                    break;
                case 2:
                    AgregarPalabra();
                    break;
                case 0:
                    Console.WriteLine("Saliendo...");
                    break;
                default:
                    Console.WriteLine("Opción inválida, intente de nuevo.");
                    break;
            }
        } while (opcion != 0);
    }

    // Función para traducir una frase ingresada por el usuario
    static void TraducirFrase()
    {
        Console.Write("Ingrese la frase: ");
        string frase = Console.ReadLine().ToLower();
        string[] palabras = frase.Split(' ');

        // Recorre cada palabra y la traduce si está en el diccionario
        for (int i = 0; i < palabras.Length; i++)
        {
            if (diccionario.ContainsKey(palabras[i]))
            {
                palabras[i] = diccionario[palabras[i]]; // Traducción de inglés a español
            }
            else if (diccionario.ContainsValue(palabras[i]))
            {
                // Traducción de español a inglés
                foreach (var par in diccionario)
                {
                    if (par.Value == palabras[i])
                    {
                        palabras[i] = par.Key;
                        break;
                    }
                }
            }
        }

        // Imprime la frase traducida
        Console.WriteLine("Frase traducida: " + string.Join(" ", palabras));
    }

    // Función para agregar nuevas palabras al diccionario
    static void AgregarPalabra()
    {
        Console.Write("Ingrese la palabra en inglés: ");
        string ingles = Console.ReadLine().ToLower();
        
        Console.Write("Ingrese la traducción en español: ");
        string espanol = Console.ReadLine().ToLower();
        
        // Verifica si la palabra ya existe en el diccionario
        if (!diccionario.ContainsKey(ingles))
        {
            diccionario.Add(ingles, espanol);
            Console.WriteLine("Palabra agregada con éxito.");
        }
        else
        {
            Console.WriteLine("Esta palabra ya existe en el diccionario.");
        }
    }
}
