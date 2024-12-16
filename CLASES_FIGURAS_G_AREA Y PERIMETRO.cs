// Clase para representar un círculo
public class Circulo
{
    public double radio; // Variable pública para el radio

    // Método para calcular el área del círculo
    public double CalcularArea()
    {
        return Math.PI * radio * radio; // Fórmula del área
    }

    // Método para calcular el perímetro del círculo
    public double CalcularPerimetro()
    {
        return 2 * Math.PI * radio; // Fórmula del perímetro
    }
}

// Clase para representar un rectángulo
public class Rectangulo
{
    public double largo; // Variable pública para el largo
    public double ancho; // Variable pública para el ancho

    // Método para calcular el área del rectángulo
    public double CalcularArea()
    {
        return largo * ancho; // Fórmula del área
    }

    // Método para calcular el perímetro del rectángulo
    public double CalcularPerimetro()
    {
        return 2 * (largo + ancho); // Fórmula del perímetro
    }
}

// Programa principal
class Program
{
    static void Main(string[] args)
    {
        // Crear un círculo e ingresar el valor del radio
        Circulo miCirculo = new Circulo();
        Console.WriteLine("Ingrese el radio del círculo:");
        miCirculo.radio = Convert.ToDouble(Console.ReadLine()); // Leer valor del radio
        Console.WriteLine("Área del círculo: " + miCirculo.CalcularArea());
        Console.WriteLine("Perímetro del círculo: " + miCirculo.CalcularPerimetro());

        // Crear un rectángulo e ingresar los valores del largo y ancho
        Rectangulo miRectangulo = new Rectangulo();
        Console.WriteLine("Ingrese el largo del rectángulo:");
        miRectangulo.largo = Convert.ToDouble(Console.ReadLine()); // Leer valor del largo
        Console.WriteLine("Ingrese el ancho del rectángulo:");
        miRectangulo.ancho = Convert.ToDouble(Console.ReadLine()); // Leer valor del ancho
        Console.WriteLine("Área del rectángulo: " + miRectangulo.CalcularArea());
        Console.WriteLine("Perímetro del rectángulo: " + miRectangulo.CalcularPerimetro());
    }
}
