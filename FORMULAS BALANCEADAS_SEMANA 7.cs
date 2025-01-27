using System;
using System.Collections.Generic;

class Program
{
    // Función para verificar si la fórmula está balanceada
    static string VerificarBalanceado(string formula)
    {
        Stack<char> pila = new Stack<char>(); // Usamos una pila para almacenar los símbolos abiertos
        
        // Recorremos la fórmula carácter por carácter
        foreach (char c in formula)
        {
            // Si encontramos un paréntesis o corchete abierto, lo añadimos a la pila
            if (c == '(' || c == '{' || c == '[')
            {
                pila.Push(c);
            }
            // Si encontramos un paréntesis o corchete cerrado, verificamos que coincida con el último abierto
            else if (c == ')' || c == '}' || c == ']')
            {
                // Si la pila está vacía o el elemento superior no coincide, la fórmula no está balanceada
                if (pila.Count == 0 || !EsSimboloBalanceado(pila.Pop(), c))
                {
                    return "fórmula no balanceada";
                }
            }
        }
        
        // Si la pila está vacía al final, la fórmula está balanceada
        return pila.Count == 0 ? "fórmula balanceada" : "fórmula no balanceada";
    }

    // Función auxiliar para verificar si los símbolos coinciden
    static bool EsSimboloBalanceado(char abierto, char cerrado)
    {
        return (abierto == '(' && cerrado == ')') ||
               (abierto == '{' && cerrado == '}') ||
               (abierto == '[' && cerrado == ']');
    }

    // Función principal para probar la verificación
    static void Main()
    {
        string formula = "{7+(8*5)-[(9-7)+(4+1)]}"; // Ejemplo de fórmula balanceada
        Console.WriteLine(VerificarBalanceado(formula)); // Salida esperada: "fórmula balanceada"
    }
}
