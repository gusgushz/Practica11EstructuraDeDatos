using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System;
class Program {
    static void Main () {
        Console.WriteLine ("Se escribiran números al azar para llenar una matriz 5x10 y se mostrarán las sumas y promedio.");
        int FM = 5; int CM = 10; //Datos del ejercicio.
        double[,] matriz = new double [FM,CM];
        Random random = new ();
        for (int i = 0; i < FM; i++)
        {
            for (int j = 0; j < CM; j++)
            {
                double ran = random.Next(1,10)*1.00;
                matriz[i,j] = ran;
            }
        }

        Calcu gus = new();
        gus.Sumar(matriz);
        gus.Promediar(matriz);
        Console.WriteLine("                                              A    B");
        for (int i = 0; i < FM; i++)
        {
            Console.Write("   |");
            for (int j = 0; j < CM; j++)
            {
                Console.Write(" {0}  ", matriz[i,j]);
            }
            Console.Write("| ");
            Console.Write(gus.SumaFila[i,0]+" | ");
            Console.WriteLine(gus.PromFila[i,0].ToString("0.##")+" |");
        }
        Console.WriteLine("------------------------------------------------------- ");
        for (int i = 0; i < gus.SumaColu.GetLength(0); i++)
        {
            Console.Write("C  |");
            for (int j = 0; j < CM; j++)
            {
                Console.Write(" {0}  ", gus.SumaColu[i,j]);
            }
            Console.WriteLine("| ");
        }
        for (int i = 0; i < gus.PromColu.GetLength(0); i++)
        {
            Console.Write("D  |");
            for (int j = 0; j < CM; j++)
            {
                Console.Write(" {0} ", gus.PromColu[i,j].ToString("0.##"));
            }
            Console.WriteLine("| ");
        }
    }
}
public class Calcu {
    public double[,] SumaFila = new double[5,1];
    public double[,] SumaColu = new double[1,10];
    public double[,] PromFila = new double[5,1];
    public double[,] PromColu = new double[1,10];

    public void Sumar (double[,] matriz) {
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                SumaFila[i,0] += matriz[i,j];
                SumaColu[0,j] += matriz[i,j];
            }
        }
    }
    public void Promediar (double[,] matriz) {
        for (int i = 0; i < SumaFila.GetLength(0); i++)
        {
            for (int j = 0; j < SumaFila.GetLength(1); j++)
            {
                PromFila[i,0] = (SumaFila[i,j])/matriz.GetLength(1);
            }
        }
        for (int i = 0; i < SumaColu.GetLength(0); i++)
        {
            for (int j = 0; j < SumaColu.GetLength(1); j++)
            {
                PromColu[0,j] = (SumaColu[i,j])/matriz.GetLength(0);
            }
        }
    }
}