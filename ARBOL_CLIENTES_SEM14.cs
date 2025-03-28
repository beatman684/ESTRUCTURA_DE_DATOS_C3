using System;

public class Cliente
{
    // Propiedades del cliente
    public string Nombre { get; set; }
    public string Dni { get; set; }

    // Constructor para inicializar un cliente con su nombre y DNI
    public Cliente(string nombre, string dni)
    {
        Nombre = nombre;
        Dni = dni;
    }

    // Método para representar al cliente como cadena de texto
    public override string ToString()
    {
        return $"{Nombre} ({Dni})";
    }
}

public class Nodo
{
    // Nodo de un árbol binario, contiene un cliente y referencias a los nodos hijos
    public Cliente Cliente { get; set; }
    public Nodo Izquierda { get; set; }
    public Nodo Derecha { get; set; }

    // Constructor para crear un nodo con un cliente
    public Nodo(Cliente cliente)
    {
        Cliente = cliente;
        Izquierda = null;
        Derecha = null;
    }
}

public class ArbolBinarioClientes
{
    // Raíz del árbol
    public Nodo Raiz { get; set; }

    // Constructor para inicializar el árbol vacío
    public ArbolBinarioClientes()
    {
        Raiz = null;
    }

    // Método para insertar un cliente en el árbol binario
    public void Insertar(Cliente cliente)
    {
        Raiz = InsertarRecursivo(Raiz, cliente);
    }

    // Método recursivo que inserta un nodo en el árbol binario
    private Nodo InsertarRecursivo(Nodo nodo, Cliente cliente)
    {
        // Si el árbol está vacío, creamos un nuevo nodo
        if (nodo == null)
        {
            return new Nodo(cliente);
        }

        // Si el DNI del cliente es menor, lo insertamos en el subárbol izquierdo
        if (string.Compare(cliente.Dni, nodo.Cliente.Dni) < 0)
        {
            nodo.Izquierda = InsertarRecursivo(nodo.Izquierda, cliente);
        }
        // Si el DNI del cliente es mayor, lo insertamos en el subárbol derecho
        else if (string.Compare(cliente.Dni, nodo.Cliente.Dni) > 0)
        {
            nodo.Derecha = InsertarRecursivo(nodo.Derecha, cliente);
        }

        return nodo;
    }

    // Método para buscar un cliente por su DNI
    public Cliente Buscar(string dni)
    {
        Nodo nodo = BuscarRecursivo(Raiz, dni);
        return nodo != null ? nodo.Cliente : null;
    }

    // Método recursivo que busca un nodo en el árbol binario
    private Nodo BuscarRecursivo(Nodo nodo, string dni)
    {
        // Si el nodo es nulo o encontramos el cliente con el DNI buscado
        if (nodo == null || nodo.Cliente.Dni == dni)
        {
            return nodo;
        }

        // Si el DNI a buscar es menor, lo buscamos en el subárbol izquierdo
        if (string.Compare(dni, nodo.Cliente.Dni) < 0)
        {
            return BuscarRecursivo(nodo.Izquierda, dni);
        }
        // Si el DNI a buscar es mayor, lo buscamos en el subárbol derecho
        else
        {
            return BuscarRecursivo(nodo.Derecha, dni);
        }
    }

    // Método para eliminar un cliente por su DNI
    public void Eliminar(string dni)
    {
        Raiz = EliminarRecursivo(Raiz, dni);
    }

    // Método recursivo para eliminar un nodo del árbol binario
    private Nodo EliminarRecursivo(Nodo nodo, string dni)
    {
        if (nodo == null)
        {
            return null;
        }

        // Si el DNI a eliminar es menor, lo buscamos en el subárbol izquierdo
        if (string.Compare(dni, nodo.Cliente.Dni) < 0)
        {
            nodo.Izquierda = EliminarRecursivo(nodo.Izquierda, dni);
        }
        // Si el DNI a eliminar es mayor, lo buscamos en el subárbol derecho
        else if (string.Compare(dni, nodo.Cliente.Dni) > 0)
        {
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, dni);
        }
        else
        {
            // Si el nodo a eliminar tiene un solo hijo o es hoja, lo eliminamos directamente
            if (nodo.Izquierda == null)
            {
                return nodo.Derecha;
            }
            else if (nodo.Derecha == null)
            {
                return nodo.Izquierda;
            }

            // Si el nodo a eliminar tiene dos hijos, buscamos el menor de los nodos derechos
            nodo.Cliente = MinimoValorNodo(nodo.Derecha).Cliente;
            nodo.Derecha = EliminarRecursivo(nodo.Derecha, nodo.Cliente.Dni);
        }

        return nodo;
    }

    // Método para encontrar el nodo con el valor mínimo
    private Nodo MinimoValorNodo(Nodo nodo)
    {
        Nodo actual = nodo;
        // Recorremos hacia la izquierda para encontrar el nodo más pequeño
        while (actual.Izquierda != null)
        {
            actual = actual.Izquierda;
        }
        return actual;
    }

    // Método para recorrer el árbol en orden (inorden)
    public void InOrden(Action<Cliente> accion)
    {
        InOrdenRecursivo(Raiz, accion);
    }

    // Método recursivo para el recorrido en orden
    private void InOrdenRecursivo(Nodo nodo, Action<Cliente> accion)
    {
        if (nodo != null)
        {
            // Recorremos el subárbol izquierdo
            InOrdenRecursivo(nodo.Izquierda, accion);
            // Ejecutamos la acción sobre el cliente del nodo actual
            accion(nodo.Cliente);
            // Recorremos el subárbol derecho
            InOrdenRecursivo(nodo.Derecha, accion);
        }
    }

    // Método para recorrer el árbol en preorden
    public void PreOrden(Action<Cliente> accion)
    {
        PreOrdenRecursivo(Raiz, accion);
    }

    // Método recursivo para el recorrido en preorden
    private void PreOrdenRecursivo(Nodo nodo, Action<Cliente> accion)
    {
        if (nodo != null)
        {
            // Ejecutamos la acción sobre el cliente del nodo actual
            accion(nodo.Cliente);
            // Recorremos el subárbol izquierdo
            PreOrdenRecursivo(nodo.Izquierda, accion);
            // Recorremos el subárbol derecho
            PreOrdenRecursivo(nodo.Derecha, accion);
        }
    }

    // Método para recorrer el árbol en postorden
    public void PostOrden(Action<Cliente> accion)
    {
        PostOrdenRecursivo(Raiz, accion);
    }

    // Método recursivo para el recorrido en postorden
    private void PostOrdenRecursivo(Nodo nodo, Action<Cliente> accion)
    {
        if (nodo != null)
        {
            // Recorremos el subárbol izquierdo
            PostOrdenRecursivo(nodo.Izquierda, accion);
            // Recorremos el subárbol derecho
            PostOrdenRecursivo(nodo.Derecha, accion);
            // Ejecutamos la acción sobre el cliente del nodo actual
            accion(nodo.Cliente);
        }
    }
}

class Program
{
    static void Main()
    {
        // Creamos un árbol binario para almacenar los clientes
        ArbolBinarioClientes arbol = new ArbolBinarioClientes();

        bool continuar = true;

        while (continuar)
        {
            // Menú de opciones
            Console.Clear();
            Console.WriteLine("----- Menú de Opciones -----");
            Console.WriteLine("1. Insertar Cliente");
            Console.WriteLine("2. Buscar Cliente");
            Console.WriteLine("3. Eliminar Cliente");
            Console.WriteLine("4. Mostrar Clientes (Inorden)");
            Console.WriteLine("5. Mostrar Clientes (Preorden)");
            Console.WriteLine("6. Mostrar Clientes (Postorden)");
            Console.WriteLine("7. Salir");
            Console.Write("\nSelecciona una opción: ");
            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    // Insertar cliente
                    Console.Write("Ingrese el nombre del cliente: ");
                    string nombre = Console.ReadLine();
                    Console.Write("Ingrese el DNI del cliente: ");
                    string dni = Console.ReadLine();
                    arbol.Insertar(new Cliente(nombre, dni));
                    Console.WriteLine("Cliente insertado exitosamente.");
                    break;

                case "2":
                    // Buscar cliente
                    Console.Write("Ingrese el DNI del cliente a buscar: ");
                    string dniBuscar = Console.ReadLine();
                    Cliente clienteBuscado = arbol.Buscar(dniBuscar);
                    if (clienteBuscado != null)
                    {
                        Console.WriteLine($"Cliente encontrado: {clienteBuscado}");
                    }
                    else
                    {
                        Console.WriteLine("Cliente no encontrado.");
                    }
                    break;

                case "3":
                    // Eliminar cliente
                    Console.Write("Ingrese el DNI del cliente a eliminar: ");
                    string dniEliminar = Console.ReadLine();
                    arbol.Eliminar(dniEliminar);
                    Console.WriteLine("Cliente eliminado (si existía).");
                    break;

                case "4":
                    // Mostrar clientes en orden (inorden)
                    Console.WriteLine("\nClientes en orden (Inorden):");
                    arbol.InOrden(cliente => Console.WriteLine(cliente));
                    break;

                case "5":
                    // Mostrar clientes en preorden
                    Console.WriteLine("\nClientes en preorden:");
                    arbol.PreOrden(cliente => Console.WriteLine(cliente));
                    break;

                case "6":
                    // Mostrar clientes en postorden
                    Console.WriteLine("\nClientes en postorden:");
                    arbol.PostOrden(cliente => Console.WriteLine(cliente));
                    break;

                case "7":
                    // Salir
                    continuar = false;
                    break;

                default:
                    Console.WriteLine("Opción inválida. Por favor, elige una opción válida.");
                    break;
            }

            // Esperar para continuar
            Console.WriteLine("\nPresiona una tecla para continuar...");
            Console.ReadKey();
        }
    }
}

