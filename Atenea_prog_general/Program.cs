using System;

public class ProgramacionGeneral
{
    public static string InvertirTexto(string texto)
    {
        char[] caracteres = texto.ToCharArray();
        Array.Reverse(caracteres);
        return new string(caracteres);
    }

    public static Dictionary<char, int> Moda(string texto)
    {
        Dictionary<char, int> frecuencia = new Dictionary<char, int>();

        foreach (char c in texto)
        {
            if (char.IsLetter(c))
            {
                char letraNormalizada = char.ToLower(c);
                if (frecuencia.ContainsKey(letraNormalizada))
                {
                    frecuencia[letraNormalizada]++;
                }
                else
                {
                    frecuencia[letraNormalizada] = 1;
                }
            }
        }

        return frecuencia;
    }

    private static readonly char[] separator = [' ', '\t', '\n', '\r']; //espacios en blanco, saltos de linea y tabulación

    public static int Palabras(string texto)
    {
        if (string.IsNullOrWhiteSpace(texto))
            return 0;

        string[] palabras = texto.Split(separator, StringSplitOptions.RemoveEmptyEntries);
        return palabras.Length;
    }

    public static List<List<int>> Combinaciones(List<int> numeros, int objetivo)
    {
        List<List<int>> result = new List<List<int>>();
        List<int> combinacionActual = new List<int>();

        EncontrarCombinacionesRecursivo(numeros, objetivo, 0, combinacionActual, result);
        return result;
    }

    private static void EncontrarCombinacionesRecursivo(List<int> numeros, int objetivo, int indiceActual, List<int> combinacionActual, List<List<int>> result)
    {
        if (objetivo == 0)
        {
            result.Add(new List<int>(combinacionActual));
            return;
        }

        for (int i = indiceActual; i < numeros.Count; i++)
        {
            if (objetivo - numeros[i] >= 0)
            {
                combinacionActual.Add(numeros[i]);
                EncontrarCombinacionesRecursivo(numeros, objetivo - numeros[i], i + 1, combinacionActual, result); //llamada recursiva
                combinacionActual.RemoveAt(combinacionActual.Count - 1);
            }
        }
    }


    static void Main()
    {
        // Ejercicio a: Inversión de texto
        string textoOriginal = "Hola mundo";
        string textoInvertido = InvertirTexto(textoOriginal);
        Console.WriteLine($"Texto original: {textoOriginal}");
        Console.WriteLine($"Texto invertido: {textoInvertido}");

        // Ejercicio b: Moda
        string textoEjercicioB = "Ejemplo de texto";
        Dictionary<char, int> frecuencias = Moda(textoEjercicioB);
        Console.WriteLine("\nFrecuencia de caracteres:");
        Console.WriteLine("'Ejemplo de texto'");
        foreach (var frec in frecuencias)
        {
            Console.WriteLine($"Carácter: {frec.Key}, Frecuencia: {frec.Value}");
        }

        // Ejercicio c: Palabras
        string textoEjercicioC = "\nEste es un ejemplo de conteo de palabras.";
        int cantidadPalabras = Palabras(textoEjercicioC);
        Console.WriteLine($"{textoEjercicioC}");
        Console.WriteLine($"\nCantidad de palabras en el texto: {cantidadPalabras}");

        // Ejercicio d: Combinaciones
        List<int> numeros = [1, 5, 3, 2];
        int objetivo = 6;
        List<List<int>> soluciones = Combinaciones(numeros, objetivo);
        if (soluciones.Count != 0)
        {
            Console.WriteLine($"\nSoluciones para el objetivo {objetivo}: dentro de la lista: {string.Join(", ", numeros)}");
            foreach (var solucion in soluciones)
            {
                Console.WriteLine($"[{string.Join(", ", solucion)}]");
            }
        }
        else
        {
            Console.WriteLine("\nNo se encontraron combinaciones que sumen el objetivo.");
        }
    }
}