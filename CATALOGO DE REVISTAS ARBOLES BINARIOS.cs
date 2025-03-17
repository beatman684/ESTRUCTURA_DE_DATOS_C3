using System;
using System.Collections.Generic;

class Revista
{
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public int AnioPublicacion { get; set; }

    public Revista(string titulo, string autor, int anio)
    {
        Titulo = titulo;
        Autor = autor;
        AnioPublicacion = anio;
    }
}

class CatalogoRevistas
{
    private static List<Revista> revistas = new List<Revista>
    {
        new Revista("National Geographic", "National Geographic Society", 1888),
        new Revista("Scientific American", "Springer Nature", 1845),
        new Revista("Time", "Henry Luce", 1923),
        new Revista("Forbes", "B.C. Forbes", 1917),
        new Revista("Nature", "Springer Nature", 1869),
        new Revista("The Economist", "James Wilson", 1843),
        new Revista("Popular Science", "Bonnier Corporation", 1872),
        new Revista("Harvard Business Review", "Harvard University", 1922),
        new Revista("IEEE Spectrum", "IEEE", 1964),
        new Revista("MIT Technology Review", "MIT", 1899)
    };

    static void Main()
    {
        bool continuar = true;
        while (continuar)
        {
            Console.WriteLine("\nMenú de catálogo de revistas:");
            Console.WriteLine("1. Buscar título (iterativo)");
            Console.WriteLine("2. Buscar título (recursivo)");
            Console.WriteLine("3. Agregar nueva revista");
            Console.WriteLine("4. Eliminar una revista");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            switch (opcion)
            {
                case "1":
                case "2":
                    Console.Write("Ingrese el título a buscar: ");
                    string titulo = Console.ReadLine();
                    
                    bool encontrado = opcion == "1" ? BuscarIterativo(titulo) : BuscarRecursivo(titulo, 0);
                    
                    Console.WriteLine(encontrado ? "\nResultado: Revista encontrada!" : "\nResultado: Revista no encontrada.");
                    break;
                
                case "3":
                    AgregarRevista();
                    break;
                
                case "4":
                    EliminarRevista();
                    break;
                
                case "5":
                    continuar = false;
                    Console.WriteLine("Saliendo del programa...");
                    break;
                
                default:
                    Console.WriteLine("\nOpción no válida. Intente nuevamente.");
                    break;
            }
        }
    }

    static bool BuscarIterativo(string titulo)
    {
        foreach (var revista in revistas)
        {
            if (string.Equals(revista.Titulo, titulo, StringComparison.OrdinalIgnoreCase))
                return true;
        }
        return false;
    }

    static bool BuscarRecursivo(string titulo, int indice)
    {
        if (indice >= revistas.Count) return false;
        if (string.Equals(revistas[indice].Titulo, titulo, StringComparison.OrdinalIgnoreCase)) return true;
        return BuscarRecursivo(titulo, indice + 1);
    }

    static void AgregarRevista()
    {
        Console.Write("Ingrese el título de la revista: ");
        string titulo = Console.ReadLine();
        Console.Write("Ingrese el autor de la revista: ");
        string autor = Console.ReadLine();
        Console.Write("Ingrese el año de publicación: ");
        int anio = int.Parse(Console.ReadLine());

        revistas.Add(new Revista(titulo, autor, anio));
        Console.WriteLine("Revista agregada exitosamente!");
    }

    static void EliminarRevista()
    {
        Console.Write("Ingrese el título de la revista a eliminar: ");
        string titulo = Console.ReadLine();
        
        Revista revistaAEliminar = revistas.Find(r => string.Equals(r.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
        
        if (revistaAEliminar != null)
        {
            revistas.Remove(revistaAEliminar);
            Console.WriteLine("Revista eliminada correctamente.");
        }
        else
        {
            Console.WriteLine("Revista no encontrada.");
        }
    }
}
