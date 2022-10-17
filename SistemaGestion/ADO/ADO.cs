using SistemaGestion.Repository;
using System.Data.SqlClient;

namespace SistemaGestion.ADO
{
    static internal class ADO
    {
        private static SqlConnection GetConncection()
        {
            string connectionString = "Server=WORK-LAP-IERS\\SQLEXPRESS;Database=SistemaGestion;Trusted_Connection=True;";
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        public static List<Producto> GetProductos(string userIDParameter)
        {
            var listaProductos = new List<Producto>();
            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(
                    new SqlParameter("id", System.Data.SqlDbType.Int) { Value = userIDParameter }
                    );
                cmd.CommandText = "SELECT * FROM producto WHERE idUsuario = @id";
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

        public static Usuario GetUsuarios(string nombreParameter)
        {
            Usuario usuario = new Usuario();

            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(
                    new SqlParameter("nombre", System.Data.SqlDbType.VarChar) { Value = nombreParameter }
                    );
                cmd.CommandText = "SELECT * FROM Usuario WHERE Nombre = @nombre";
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    usuario.ID = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contrasenia = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();


                }

                Console.WriteLine("---- USUARIO ----- ");
                Console.WriteLine("id = " + usuario.ID);
                Console.WriteLine("Nombre = " + usuario.Nombre);
                Console.WriteLine("Apellido = " + usuario.Apellido);
                Console.WriteLine("Nombre de usuario = " + usuario.NombreUsuario);
                Console.WriteLine("Contrasenia = " + usuario.Contrasenia);
                Console.WriteLine("Mail = " + usuario.Mail);
                reader.Close();
                connection.Close();
            }

            return usuario;
        }

        public static List<ProductoVendido> GetProductosVendidos(string userParameter)
        {
            var ProductosVendidos = new List<ProductoVendido>();

            using (SqlConnection connection = GetConncection())
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.Parameters.Add(
                    new SqlParameter("user",System.Data.SqlDbType.VarChar) {Value = userParameter }
                    );
                cmd.CommandText = @"
                    SELECT
						pv.Id,
						pv.IdVenta AS ID_Venta,
						Descripciones AS Articulo,
						PrecioVenta AS Precio,
						pv.Stock AS Cantidad,
						(PrecioVenta*pv.Stock) AS Total
                    FROM
                        Producto AS p
                        INNER JOIN ProductoVendido pv ON p.Id = pv.IdProducto
						INNER JOIN Usuario u ON u.Id = p.IdUsuario
                    WHERE u.Nombre = @user
                    ";


                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var pVendido = new ProductoVendido();

                    pVendido.ID = Convert.ToInt32(reader.GetValue(0));
                    pVendido.IDVenta = Convert.ToInt32(reader.GetValue(1));
                    pVendido.Articulo = reader.GetValue(2).ToString();
                    pVendido.Precio = Convert.ToDouble(reader.GetValue(3));
                    pVendido.Cantidad = Convert.ToInt32(reader.GetValue(4));
                    pVendido.Total = Convert.ToDouble(reader.GetValue(5));

                    ProductosVendidos.Add(pVendido);

                }

                Console.WriteLine("---- PRODUCTOS VENDIDOS ----- ");
                foreach (var pVendido in ProductosVendidos)
                {
                    Console.WriteLine("id_venta = " + pVendido.IDVenta);
                    Console.WriteLine("Articulo = " + pVendido.Articulo);
                    Console.WriteLine("Precio = " + pVendido.Precio);
                    Console.WriteLine("Cantidad = " + pVendido.Cantidad);
                    Console.WriteLine("Total = " + pVendido.Total);
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

        public static bool Session(string userParameter, string passParameter)
        {
            using(SqlConnection connection = GetConncection())
            {
                connection.Open();
                var cmd = connection.CreateCommand();
                cmd.Parameters.Add(
                    new SqlParameter("user",System.Data.SqlDbType.VarChar) { Value = userParameter }
                    );
                cmd.Parameters.Add(
                    new SqlParameter("pass",System.Data.SqlDbType.VarChar) { Value = passParameter }
                    );

                cmd.CommandText = @"
                SELECT
	                *
                FROM
	                Usuario
				WHERE
					NombreUsuario = @user AND
					Contraseña = @pass
                ";

                var reader = cmd.ExecuteReader();

                if (reader.Read()) { return true; } 
                else { return false; }
                
                reader.Close();
                connection.Close();
            }

            return false;
        }

    }
}
