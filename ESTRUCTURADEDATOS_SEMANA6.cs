// Ejercicio 1: Calcular el número de elementos de una lista
using System;

public class Node {
    public int Data;
    public Node Next;

    public Node(int data) {
        Data = data;
        Next = null;
    }
}

public class LinkedList {
    private Node head;

    public LinkedList() {
        head = null;
    }

    // Método para agregar un nodo al final de la lista
    public void Add(int data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode;
        } else {
            Node current = head;
            while (current.Next != null) {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Método para contar el número de elementos en la lista
    public int CountElements() {
        int count = 0;
        Node current = head;
        while (current != null) {
            count++;
            current = current.Next;
        }
        return count;
    }

    // Método para imprimir los elementos de la lista
    public void PrintList() {
        Node current = head;
        while (current != null) {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

class Program {
    static void Main() {
        LinkedList list = new LinkedList();
        list.Add(10);
        list.Add(20);
        list.Add(30);

        Console.WriteLine("Lista enlazada:");
        list.PrintList();

        Console.WriteLine("Número de elementos en la lista: " + list.CountElements());
    }
}

// Ejercicio 2: Lista Invertida

using System;

public class LinkedListReversible {
    private Node head;

    public LinkedListReversible() {
        head = null;
    }

    // Clase Node para representar cada elemento de la lista
    public class Node {
        public int Data;
        public Node Next;

        public Node(int data) {
            Data = data;
            Next = null;
        }
    }

    // Método para agregar un nodo al final de la lista
    public void Add(int data) {
        Node newNode = new Node(data);
        if (head == null) {
            head = newNode;
        } else {
            Node current = head;
            while (current.Next != null) {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // Método para invertir la lista enlazada
    public void Reverse() {
        Node prev = null;
        Node current = head;
        Node next = null;

        while (current != null) {
            next = current.Next; // Guardar el siguiente nodo
            current.Next = prev; // Invertir el enlace
            prev = current;      // Avanzar el puntero "prev"
            current = next;      // Avanzar el puntero "current"
        }

        head = prev; // Actualizar el inicio de la lista
    }

    // Método para imprimir los elementos de la lista
    public void PrintList() {
        Node current = head;
        while (current != null) {
            Console.Write(current.Data + " -> ");
            current = current.Next;
        }
        Console.WriteLine("null");
    }
}

class ProgramReverse {
    static void Main() {
        LinkedListReversible list = new LinkedListReversible();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);

        Console.WriteLine("Lista original:");
        list.PrintList();

        list.Reverse();

        Console.WriteLine("Lista invertida:");
        list.PrintList();
    }
}
