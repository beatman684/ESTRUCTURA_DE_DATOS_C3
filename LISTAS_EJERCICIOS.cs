using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    // EJERCICIO 1: CREAR UNA CLASE QUE SIMULE UNA LISTA DE ESTUDIANTES CON SUS NOTAS
    // Crea una clase llamada Estudiante que tenga las propiedades nombre y nota. Luego, crea una lista de instancias de Estudiante,
    // y permite agregar, eliminar y mostrar estudiantes.
    class Estudiante
    {
        public string Nombre { get; set; }
        public double Nota { get; set; }

        public Estudiante(string nombre, double nota)
        {
            Nombre = nombre;
            Nota = nota;
        }

        public override string ToString()
        {
            return $"{Nombre}: {Nota}";
        }
    }

    static void Ejercicio1()
    {
        List<Estudiante> estudiantes = new List<Estudiante>
        {
            new Estudiante("Juan", 7.8),
            new Estudiante("María", 9.2),
            new Estudiante("Pedro", 6.5)
        };

        // Mostrar estudiantes
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine(estudiante);
        }

        // Agregar un nuevo estudiante
        estudiantes.Add(new Estudiante("Ana", 8.4));

        // Eliminar un estudiante
        estudiantes.RemoveAll(e => e.Nombre == "Pedro");

        // Mostrar estudiantes después de cambios
        Console.WriteLine("\nDespués de modificaciones:");
        foreach (var estudiante in estudiantes)
        {
            Console.WriteLine(estudiante);
        }
    }

    // EJERCICIO 2: CREAR UNA CLASE PARA REALIZAR OPERACIONES CON UNA LISTA DE NÚMEROS
    // Crea una clase llamada OperacionesLista que reciba una lista de números y permita realizar operaciones como calcular el promedio
    // y encontrar el número mayor.
    class OperacionesLista
    {
        public List<int> Numeros { get; set; }

        public OperacionesLista(List<int> numeros)
        {
            Numeros = numeros;
        }

        public double CalcularPromedio()
        {
            return Numeros.Average();
        }

        public int EncontrarMayor()
        {
            return Numeros.Max();
        }
    }

    static void Ejercicio2()
    {
        List<int> numeros = new List<int> { 5, 10, 20, 35, 50 };

        OperacionesLista operaciones = new OperacionesLista(numeros);

        Console.WriteLine("Promedio: " + operaciones.CalcularPromedio());
        Console.WriteLine("Número mayor: " + operaciones.EncontrarMayor());
    }

    // EJERCICIO 3: CREAR UNA CLASE PARA COMBINAR DOS LISTAS DE NOMBRES
    // Crea una clase llamada CombinaListas que reciba dos listas de nombres, las combine y devuelva una lista única sin duplicados.
    class CombinaListas
    {
        public List<string> CombinarListas(List<string> lista1, List<string> lista2)
        {
            HashSet<string> resultado = new HashSet<string>(lista1);
            resultado.UnionWith(lista2);
            return new List<string>(resultado);
        }
    }

    static void Ejercicio3()
    {
        List<string> lista1 = new List<string> { "Ana", "Juan", "Pedro" };
        List<string> lista2 = new List<string> { "María", "Carlos", "Ana" };

        CombinaListas combina = new CombinaListas();
        List<string> listaCombinada = combina.CombinarListas(lista1, lista2);

        Console.WriteLine("Lista combinada:");
        foreach (var nombre in listaCombinada)
        {
            Console.WriteLine(nombre);
        }
    }

    // EJERCICIO 4: CREAR UNA CLASE QUE ADMINISTRE UNA TUPLA CON COORDENADAS (X, Y)
    // Crea una clase llamada Coordenadas que reciba una tupla con las coordenadas (X, Y) y permita calcular la distancia desde el origen (0,0).
    class Coordenadas
    {
        public (double X, double Y) Punto { get; set; }

        public Coordenadas(double x, double y)
        {
            Punto = (x, y);
        }

        public double CalcularDistancia()
        {
            return Math.Sqrt(Math.Pow(Punto.X, 2) + Math.Pow(Punto.Y, 2));
        }
    }

    static void Ejercicio4()
    {
        Coordenadas coordenada = new Coordenadas(3, 4);
        Console.WriteLine("Distancia desde el origen: " + coordenada.CalcularDistancia());
    }

    // EJERCICIO 5: CREAR UNA CLASE QUE MANIPULE UNA LISTA DE CADENAS DE TEXTO
    // Crea una clase llamada ManipulaTexto que reciba una lista de cadenas y permita realizar operaciones como agregar, eliminar y buscar un texto en la lista.
    class ManipulaTexto
    {
        public List<string> Textos { get; set; }

        public ManipulaTexto(List<string> textos)
        {
            Textos = textos;
        }

        public void AgregarTexto(string texto)
        {
            Textos.Add(texto);
        }

        public void EliminarTexto(string texto)
        {
            Textos.Remove(texto);
        }

        public bool BuscarTexto(string texto)
        {
            return Textos.Contains(texto);
        }
    }

    static void Ejercicio5()
    {
        List<string> textos = new List<string> { "Hola", "Mundo", "C# es genial" };

        ManipulaTexto manipula = new ManipulaTexto(textos);

        // Mostrar la lista inicial
        Console.WriteLine("Lista inicial:");
        foreach (var texto in textos)
        {
            Console.WriteLine(texto);
        }

        // Agregar texto
        manipula.AgregarTexto("Nuevo texto");

        // Eliminar texto
        manipula.EliminarTexto("Mundo");

        // Buscar texto
        bool encontrado = manipula.BuscarTexto("Hola");
        Console.WriteLine("\n¿Encontrado 'Hola'? " + encontrado);

        // Mostrar la lista final
        Console.WriteLine("\nLista después de modificaciones:");
        foreach (var texto in manipula.Textos)
        {
            Console.WriteLine(texto);
        }
    }

    static void Main()
    {
        // Llamar a cada ejercicio
        Console.WriteLine("EJERCICIO 1:");
        Ejercicio1();

        Console.WriteLine("\nEJERCICIO 2:");
        Ejercicio2();

        Console.WriteLine("\nEJERCICIO 3:");
        Ejercicio3();

        Console.WriteLine("\nEJERCICIO 4:");
        Ejercicio4();

        Console.WriteLine("\nEJERCICIO 5:");
        Ejercicio5();
    }
}
