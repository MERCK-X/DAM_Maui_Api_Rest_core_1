using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class PersonaCLS
    {
        //Listado de personas
        public int iidpersona { get; set; }
        public string? nombrecompleto { get; set; }
        public string? correo { get; set; }
        public string? fechanacimientocadena { get; set; }

        //RECUPERAR
        public string? nombre { get; set; }
        public string? appaterno { get; set; }
        public string? apmaterno { get; set; }
        public DateTime? fechanacimiento { get; set; }
        public int? iisexo { get; set; }


    }
}
