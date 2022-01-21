using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class KitPart :IDBEntity
    {
        public int KitId { get; set; }
        public Kit Kit { get; set; }
        public int ParteId { get; set; }
        public Parte Parte { get; set; }
        public int Cantidad { get; set; }
    }
}
