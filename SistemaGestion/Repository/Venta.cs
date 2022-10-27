using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion.Repository
{
    internal class Venta
    {
        public int ID { get; set; }
        public string Comentarios { get; set; }
        public Usuario Usuario { get; set; }
        public List<ProductoVendido> Productos { get; set; }
        public Venta() { }

        public Venta(int iD, string comentarios, Usuario usuario, List<ProductoVendido> productos)
        {
            ID = iD;
            Comentarios = comentarios;
            Usuario = usuario;
            Productos = productos;
        }
    }
}
