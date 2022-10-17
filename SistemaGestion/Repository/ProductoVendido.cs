using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion.Repository
{
    internal class ProductoVendido
    {
        public int ID { get; set; }
        public string Articulo { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }

        public ProductoVendido() { }

        public ProductoVendido(int iD, string articulo, double precio, int cantidad)
        {
            ID = iD;
            Articulo = articulo;
            Precio = precio;
            Cantidad = cantidad;
        }
    }
}
