using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nombre = "Yael Carballo Brenes";
            string cedula = "402730265";
            string nacimiento = "15 de junio del 2001";
            string telefono = "89981331";
            string edad = "23";
            double salarioPorHora = 1800; // Salario por hora normal

            while (true)
            {
                Console.WriteLine("\nMenú de Registro de Horas Trabajadas");
                Console.WriteLine("1. Registrar horas");
                Console.WriteLine("2. Salir");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    Console.Write("Ingrese la hora de entrada (hh:mm AM/PM): ");
                    DateTime entrada = DateTime.Parse(Console.ReadLine());

                    Console.Write("Ingrese la hora de salida (hh:mm AM/PM): ");
                    DateTime salida = DateTime.Parse(Console.ReadLine());

                    TimeSpan horasTrabajadas = salida - entrada;
                    double horasTotales = horasTrabajadas.TotalHours;
                    double horasNormales = horasTotales > 8 ? 8 : horasTotales;
                    double horasExtras = horasTotales > 8 ? horasTotales - 8 : 0;

                    double pagoNormal = horasNormales * salarioPorHora;
                    double pagoExtra = horasExtras * (salarioPorHora * 2);
                    double pagoTotal = pagoNormal + pagoExtra;

                    Console.WriteLine("\nResumen de horas trabajadas:");
                    Console.WriteLine("Entrada: " + entrada.ToString("hh:mm tt"));
                    Console.WriteLine("Salida: " + salida.ToString("hh:mm tt"));
                    Console.WriteLine("Total de horas trabajadas: " + horasTotales.ToString("F2"));
                    Console.WriteLine("Horas normales: " + horasNormales.ToString("F2"));
                    Console.WriteLine("Horas extras: " + horasExtras.ToString("F2"));
                    Console.WriteLine("Pago normal: $" + pagoNormal.ToString("F2"));
                    Console.WriteLine("Pago extra: $" + pagoExtra.ToString("F2"));
                    Console.WriteLine("Pago total: $" + pagoTotal.ToString("F2"));
                }
                else if (opcion == "2")
                {
                    Console.WriteLine("Saliendo del programa...");
                    break;
                }
                else
                {
                    Console.WriteLine("Opción no válida, intente de nuevo.");
                }
            }
        }
    }
}
    

