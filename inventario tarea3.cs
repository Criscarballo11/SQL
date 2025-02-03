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
                Console.WriteLine("\nMen�:");
                Console.WriteLine("1. Agregar art�culo");
                Console.WriteLine("2. Facturar");
                Console.WriteLine("3. Reporte de art�culos faltantes");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opci�n: ");

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
                        Console.WriteLine("Opci�n no v�lida. Intente de nuevo.");
                        break;
                }
            }
        }

        static void AgregarArticulo()
        {
            try
            {
                Console.Write("Ingrese c�digo: ");
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
                    Console.WriteLine("Art�culo agregado correctamente.");
                }
                else
                {
                    Console.WriteLine("El c�digo ya existe.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese valores num�ricos donde corresponda.");
            }
        }

        static void Facturar()
        {
            try
            {
                Console.Write("Ingrese c�digo del art�culo: ");
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
                    Console.WriteLine("C�digo no encontrado.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Ingrese valores num�ricos donde corresponda.");
            }
        }

        static void ReporteFaltantes()
        {
            Console.WriteLine("Art�culos con baja existencia:");
            foreach (var articulo in inventario.Values)
            {
                if (articulo.Cantidad <= 5)
                {
                    Console.WriteLine($"C�digo: {articulo.Codigo}, Nombre: {articulo.Nombre}, Cantidad: {articulo.Cantidad}");
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
