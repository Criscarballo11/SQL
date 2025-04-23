using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace claseees
{
    internal class Program
    {
        

class Articulo
        {
            public string Codigo;
            public string Nombre;
            public decimal Precio;
            public int Stock;

            public Articulo(string codigo, string nombre, decimal precio, int stock)
            {
                Codigo = codigo;
                Nombre = nombre;
                Precio = precio;
                Stock = stock;
            }

            public void MostrarInfo()
            {
                Console.WriteLine("Código: " + Codigo);
                Console.WriteLine("Nombre: " + Nombre);
                Console.WriteLine("Precio: " + Precio);
                Console.WriteLine("Stock: " + Stock);
                Console.WriteLine("------------------------");
            }
        }

        class Cliente
        {
            public string ID;
            public string Nombre;
            public string Correo;

            public Cliente(string id, string nombre, string correo)
            {
                ID = id;
                Nombre = nombre;
                Correo = correo;
            }

            public void MostrarCliente()
            {
                Console.WriteLine("ID: " + ID);
                Console.WriteLine("Nombre: " + Nombre);
                Console.WriteLine("Correo: " + Correo);
            }
        }

        class program
        {
            static Articulo[] inventario = new Articulo[50];
            static int cantidadArticulos = 0;
            static Cliente cliente = new Cliente("CL001", "Carlos Jiménez", "carlos@mail.com");

            static void Main(string[] args)
            {
                int opcion;

                do
                {
                    Console.WriteLine("\n--- MENÚ ---");
                    Console.WriteLine("1. Agregar Artículo");
                    Console.WriteLine("2. Mostrar Inventario");
                    Console.WriteLine("3. Buscar Artículo");
                    Console.WriteLine("4. Modificar Artículo");
                    Console.WriteLine("5. Mostrar Cliente");
                    Console.WriteLine("6. Salir");
                    Console.Write("Ingrese una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            AgregarArticulo();
                            break;
                        case 2:
                            MostrarInventario();
                            break;
                        case 3:
                            BuscarArticulo();
                            break;
                        case 4:
                            ModificarArticulo();
                            break;
                        case 5:
                            cliente.MostrarCliente();
                            break;
                        case 6:
                            Console.WriteLine("Saliendo del sistema...");
                            break;
                        default:
                            Console.WriteLine("Opción inválida.");
                            break;
                    }

                } while (opcion != 6);
            }

            static void AgregarArticulo()
            {
                if (cantidadArticulos >= 50)
                {
                    Console.WriteLine("Inventario lleno.");
                    return;
                }

                Console.Write("Código: ");
                string codigo = Console.ReadLine();
                Console.Write("Nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Precio: ");
                decimal precio = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Stock: ");
                int stock = Convert.ToInt32(Console.ReadLine());

                inventario[cantidadArticulos] = new Articulo(codigo, nombre, precio, stock);
                cantidadArticulos++;

                Console.WriteLine("Artículo agregado con éxito.");
            }

            static void MostrarInventario()
            {
                Console.WriteLine("\n--- INVENTARIO ---");
                for (int i = 0; i < cantidadArticulos; i++)
                {
                    inventario[i].MostrarInfo();
                }
            }

            static void BuscarArticulo()
            {
                Console.Write("Ingrese el código del artículo a buscar: ");
                string codigo = Console.ReadLine();

                for (int i = 0; i < cantidadArticulos; i++)
                {
                    if (inventario[i].Codigo == codigo)
                    {
                        inventario[i].MostrarInfo();
                        return;
                    }
                }

                Console.WriteLine("Artículo no encontrado.");
            }

            static void ModificarArticulo()
            {
                Console.Write("Ingrese el código del artículo a modificar: ");
                string codigo = Console.ReadLine();

                for (int i = 0; i < cantidadArticulos; i++)
                {
                    if (inventario[i].Codigo == codigo)
                    {
                        Console.Write("Nuevo precio: ");
                        inventario[i].Precio = Convert.ToDecimal(Console.ReadLine());
                        Console.Write("Nuevo stock: ");
                        inventario[i].Stock = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Artículo modificado.");
                        return;
                    }
                }

                Console.WriteLine("Artículo no encontrado.");
            }
        }

    }
}

