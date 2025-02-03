namespace inventario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}


namespace Inventario
{
    class program
    {
        static Dictionary<int, Articulo> inventario = new Dictionary<int, Articulo>();

        static void Main()
        {
            // Agregar producto predeterminado
            inventario[1] = new Articulo(1, "Botellas de agua", 250, 20);

            while (true)
            {
                Console.WriteLine("\nMenú:");
                Console.WriteLine("1. Agregar artículo");
                Console.WriteLine("2. Facturar");
                Console.WriteLine("3. Reporte de artículos faltantes");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        AgregarArticulo();
                        break;
                    case "2":
                        Facturar();
                        break;
                    case "3":
                        ReporteFaltantes();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción no válida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void AgregarArticulo()
        {
            try
            {
                Console.Write("Ingrese código: ");
                int codigo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese precio: ");
                decimal precio = decimal.Parse(Console.ReadLine());
                Console.Write("Ingrese nombre: ");
                string nombre = Console.ReadLine();
                Console.Write("Ingrese cantidad: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (!inventario.ContainsKey(codigo))
                {
                    inventario[codigo] = new Articulo(codigo, nombre, precio, cantidad);
                    Console.WriteLine("Artículo agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("El código ya existe.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese valores numéricos donde corresponda.");
            }
        }

        static void Facturar()
        {
            try
            {
                Console.Write("Ingrese código del artículo: ");
                int codigo = int.Parse(Console.ReadLine());
                Console.Write("Ingrese cantidad a comprar: ");
                int cantidad = int.Parse(Console.ReadLine());

                if (inventario.ContainsKey(codigo))
                {
                    Articulo articulo = inventario[codigo];
                    if (articulo.Cantidad >= cantidad)
                    {
                        decimal subtotal = articulo.Precio * cantidad;
                        decimal iva = subtotal * 0.10m;
                        decimal total = subtotal + iva;
                        articulo.Cantidad -= cantidad;
                        Console.WriteLine($"Subtotal: {subtotal}, IVA: {iva}, Total: {total}");
                    }
                    else
                    {
                        Console.WriteLine("No hay suficiente stock disponible.");
                    }
                }
                else
                {
                    Console.WriteLine("Código no encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese valores numéricos donde corresponda.");
            }
        }

        static void ReporteFaltantes()
        {
            Console.WriteLine("Artículos con baja existencia:");
            foreach (var articulo in inventario.Values)
            {
                if (articulo.Cantidad <= 5)
                {
                    Console.WriteLine($"Código: {articulo.Codigo}, Nombre: {articulo.Nombre}, Cantidad: {articulo.Cantidad}");
                }
            }
        }
    }

    class Articulo
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }

        public Articulo(int codigo, string nombre, decimal precio, int cantidad)
        {
            Codigo = codigo;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
