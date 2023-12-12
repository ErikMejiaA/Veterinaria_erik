using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Proveedor
{
    public class ListaProveedoresDto
    {
        public int IdCodigo { get; set; }
        public string ? Nombre { get; set; }
        public string ? Direccion { get; set; }
        public string ? Telefono {  get; set; }
    }
}