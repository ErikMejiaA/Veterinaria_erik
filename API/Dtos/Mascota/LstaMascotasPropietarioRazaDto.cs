using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Propietario;

namespace API.Dtos.Mascota
{
    public class LstaMascotasPropietarioRazaDto
    {
        public int IdCodigo { get; set; }
        public string ? Nombre { get; set; }
        public PropietarioMascotaDto ? Propietario { get; set; }
    }
}