using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Parte : IDBEntity
    {
        public int ParteId { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public List<AltParte> altPartes { get; set; }
    }
}
