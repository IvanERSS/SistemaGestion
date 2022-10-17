using SistemaGestion.Repository;
using System.Data.SqlClient;

namespace SistemaGestion.ADO
{
    static internal class ADO_Listas
    {
        private static SqlConnection GetConncection()
        {
            string connectionString = "Server=WORK-LAP-IERS\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static List<Producto> GetProductos()
        {
            var listaProductos = new List<Producto>();
            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Producto produc = new Producto()
                    {
                        ID = Convert.ToInt32(reader.GetValue(0)),
                        Descripciones = reader.GetValue(1).ToString(),
                        Costo = Convert.ToDouble(reader.GetValue(2)),
                        PrecioVenta = Convert.ToDouble(reader.GetValue(3)),
                        Stock = Convert.ToInt32(reader.GetValue(4)),
                        IDUsuario = Convert.ToInt32(reader.GetValue(5)),
                    };

                    listaProductos.Add(produc);

                }

                Console.WriteLine("---- PRODUCTOS ----- ");
                foreach (var produc in listaProductos)
                {
                    Console.WriteLine("id = " + produc.ID);
                    Console.WriteLine("Descripciones = " + produc.Descripciones);
                    Console.WriteLine("Costo = " + produc.Costo);
                    Console.WriteLine("PrecioVenta = " + produc.PrecioVenta);
                    Console.WriteLine("Stock = " + produc.Stock);
                    Console.WriteLine("IdUsuario = " + produc.IDUsuario);

                    Console.WriteLine("--------------");

                }
                reader.Close();
                connection.Close();
            }


            return listaProductos;
        }

        public static List<Usuario> GetUsuarios()
        {
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var usuario = new Usuario();

                    usuario.ID = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contrasenia = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();

                    listaUsuarios.Add(usuario);

                }

                Console.WriteLine("---- USUARIOS ----- ");
                foreach (var usuario in listaUsuarios)
                {
                    Console.WriteLine("id = " + usuario.ID);
                    Console.WriteLine("Nombre = " + usuario.Nombre);
                    Console.WriteLine("Apellido = " + usuario.Apellido);
                    Console.WriteLine("Nombre de usuario = " + usuario.NombreUsuario);
                    Console.WriteLine("Contrasenia = " + usuario.Contrasenia);
                    Console.WriteLine("Mail = " + usuario.Mail);
                    Console.WriteLine("--------------");

                }
                reader.Close();
                connection.Close();
            }

            return listaUsuarios;
        }

        public static List<ProductoVendido> GetProductosVendidos()
        {
            var ProductosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
                    SELECT
                        pv.ID as ID,
						Descripciones AS Articulo, 
						PrecioVenta AS Precio, 
						pv.Stock AS Cantidad,
						PrecioVenta*pv.Stock AS Total,
						pv.IdVenta AS id_venta
                    FROM
                        Producto AS p
                        INNER JOIN ProductoVendido pv ON p.Id = pv.IdProducto
                    ";


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pVendido = new ProductoVendido();

                    pVendido.ID = Convert.ToInt32(reader.GetValue(0));
                    pVendido.Articulo = reader.GetValue(1).ToString();
                    pVendido.Precio = Convert.ToDouble(reader.GetValue(2));
                    pVendido.Cantidad = Convert.ToInt32(reader.GetValue(3));
                    pVendido.Total = Convert.ToInt32(reader.GetValue(4));
                    pVendido.IDVenta = Convert.ToInt32(reader.GetValue(5));

                    ProductosVendidos.Add(pVendido);

                }

                Console.WriteLine("---- PRODUCTOS VENDIDOS ----- ");
                foreach (var pVendido in ProductosVendidos)
                {
                    Console.WriteLine("id: " + pVendido.ID);
                    Console.WriteLine("Articulo: " + pVendido.Articulo);
                    Console.WriteLine("Precio: " + pVendido.Precio);
                    Console.WriteLine("Cantidad: " + pVendido.Cantidad);
                    Console.WriteLine("Total: " + pVendido.Total);
                    Console.WriteLine("id_venta: " + pVendido.IDVenta);
                    Console.WriteLine("--------------");

                }
                reader.Close();
                connection.Close();
                return ProductosVendidos;
            }
        }

        public static List<Venta> GetVentas()
        {
            var Ventas = new List<Venta>();

            using (SqlConnection connection = GetConncection())
            {
                connection.Open();

                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = @"
                SELECT
	                v.id as id_venta,
                    v.Comentarios AS Comentarios,
	                CONCAT(u.Nombre, ' ',u.Apellido) AS Uusario, 
	                Descripciones AS Articulo, 
	                PrecioVenta AS Precio, 
	                pv.Stock AS Cantidad
                FROM
	                Venta v
	                INNER JOIN Usuario u ON v.IdUsuario = u.Id
	                INNER JOIN ProductoVendido pv ON v.Id = pv.IdVenta
	                INNER JOIN Producto p ON pv.IdProducto = p.id
                ";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var venta = new Venta();
                    var pVendido = new ProductoVendido();

                    venta.ID = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    Ventas.Add(venta);
                }

                Console.WriteLine("---- Ventas ----- ");
                foreach (var venta in Ventas)
                {
                    Console.WriteLine("id = " + venta.ID);
                    Console.WriteLine("Comentarios = " + venta.Comentarios);
                    Console.WriteLine("--------------");

                }
                reader.Close();
                connection.Close();

            }

            return Ventas;
        }

    }
}
