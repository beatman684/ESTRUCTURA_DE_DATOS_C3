using System;
using System.Collections.Generic;
using System.IO;

public class ProgramaVacunacion
{
    public static void Main()
    {
        // Crear un conjunto ficticio de 500 ciudadanos
        HashSet<string> ciudadanos = GenerarCiudadanos(500);

        // Crear conjuntos ficticios de ciudadanos vacunados con Pfizer y AstraZeneca
        HashSet<string> vacunadosPfizer = GenerarCiudadanos(75, "Pfizer");
        HashSet<string> vacunadosAstraZeneca = GenerarCiudadanos(75, "AstraZeneca");

        // Operaciones de conjuntos
        // Ciudadanos no vacunados
        HashSet<string> noVacunados = new HashSet<string>(ciudadanos);
        noVacunados.ExceptWith(vacunadosPfizer);
        noVacunados.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados con ambas vacunas
        HashSet<string> vacunadosAmbas = new HashSet<string>(vacunadosPfizer);
        vacunadosAmbas.IntersectWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con Pfizer
        HashSet<string> soloPfizer = new HashSet<string>(vacunadosPfizer);
        soloPfizer.ExceptWith(vacunadosAstraZeneca);

        // Ciudadanos vacunados solo con AstraZeneca
        HashSet<string> soloAstraZeneca = new HashSet<string>(vacunadosAstraZeneca);
        soloAstraZeneca.ExceptWith(vacunadosPfizer);

        // Mostrar los resultados
        Console.WriteLine("Ciudadanos no vacunados: " + noVacunados.Count);
        Console.WriteLine("Ciudadanos vacunados con ambas vacunas: " + vacunadosAmbas.Count);
        Console.WriteLine("Ciudadanos vacunados solo con Pfizer: " + soloPfizer.Count);
        Console.WriteLine("Ciudadanos vacunados solo con AstraZeneca: " + soloAstraZeneca.Count);

        // Generar reporte en PDF (opcional)
        GenerarReportePDF(noVacunados, vacunadosAmbas, soloPfizer, soloAstraZeneca);
    }

    // Método para generar un conjunto de ciudadanos ficticios
    public static HashSet<string> GenerarCiudadanos(int cantidad, string vacuna = null)
    {
        HashSet<string> ciudadanos = new HashSet<string>();
        for (int i = 1; i <= cantidad; i++)
        {
            ciudadanos.Add($"Ciudadano {i} ({vacuna ?? "No Vacunado"})");
        }
        return ciudadanos;
    }

    // Método para generar un reporte en PDF (simulado en este caso como archivo de texto)
    public static void GenerarReportePDF(HashSet<string> noVacunados, HashSet<string> vacunadosAmbas, 
                                         HashSet<string> soloPfizer, HashSet<string> soloAstraZeneca)
    {
        string filePath = "reporte_vacunacion.txt"; // Simulamos PDF como archivo de texto
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine("Reporte de Vacunación COVID-19");
            writer.WriteLine("====================================");
            writer.WriteLine($"Ciudadanos no vacunados: {noVacunados.Count}");
            writer.WriteLine($"Ciudadanos vacunados con ambas vacunas: {vacunadosAmbas.Count}");
            writer.WriteLine($"Ciudadanos vacunados solo con Pfizer: {soloPfizer.Count}");
            writer.WriteLine($"Ciudadanos vacunados solo con AstraZeneca: {soloAstraZeneca.Count}");
        }

        Console.WriteLine($"Reporte generado en: {filePath}");
    }
}
