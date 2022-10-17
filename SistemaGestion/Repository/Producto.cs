using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion.Repository
{
    public class Producto
    {
        public int ID { get; set; }
        public string Descripciones { get; set; }
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int IDUsuario { get; set; }

        public Producto() { }

        public Producto(int iD, string descripciones, double costo, double precioVenta, int stock, int iDUsuario)
        {
            ID = iD;
            Descripciones = descripciones;
            Costo = costo;
            PrecioVenta = precioVenta;
            Stock = stock;
            IDUsuario = iDUsuario;
        }




    }
}
