using System;
using System.Collections.Generic;

// Clase que representa la atracción del parque y maneja la asignación de asientos
class AtraccionParque
{
    private List<string> asientos = new List<string>(new string[30]); // Lista para representar los asientos

    // Método para asignar un asiento a una persona según la elección del usuario
    public void AsignarAsiento(string nombre, int numeroAsiento)
    {
        if (numeroAsiento < 1 || numeroAsiento > 30)
        {
            Console.WriteLine("Número de asiento inválido. Debe estar entre 1 y 30.");
            return;
        }
        
        if (asientos[numeroAsiento - 1] == null)
        {
            asientos[numeroAsiento - 1] = nombre;
            Console.WriteLine($"{nombre} ha ocupado el asiento {numeroAsiento}.");
        }
        else
        {
            Console.WriteLine("Ese asiento ya está ocupado, por favor elija otro.");
        }
    }

    // Método para mostrar el estado actual de los asientos
    public void MostrarAsientos()
    {
        Console.WriteLine("Estado de los asientos:");
        for (int i = 0; i < asientos.Count; i++)
        {
            Console.WriteLine($"Asiento {i + 1}: {(asientos[i] ?? "Disponible")}");
        }
    }
}

// Clase principal donde se ejecuta el programa
class Program
{
    static void Main()
    {
        AtraccionParque atraccion = new AtraccionParque(); // Se crea la instancia de la atracción
        
        while (true)
        {
            Console.WriteLine("\nMenú:");
            Console.WriteLine("1. Ingresar persona y asignar asiento");
            Console.WriteLine("2. Mostrar estado de los asientos");
            Console.WriteLine("3. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                    Console.Write("Ingrese su nombre: ");
                    string nombre = Console.ReadLine();
                    
                    Console.Write("Elija un número de asiento (1-30): ");
                    if (int.TryParse(Console.ReadLine(), out int numeroAsiento))
                    {
                        atraccion.AsignarAsiento(nombre, numeroAsiento);
                    }
                    else
                    {
                        Console.WriteLine("Entrada inválida. Debe ingresar un número válido.");
                    }
                    break;
                
                case "2":
                    atraccion.MostrarAsientos();
                    break;
                
                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                
                default:
                    Console.WriteLine("Opción inválida. Intente nuevamente.");
                    break;
            }
        }
    }
}
