using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class AltParte : IDBEntity
    {
        public int ParteId { get; set; }
        public Parte Parte { get; set; }
        public int ParteAlternaId { get; set; }
        public Parte ParteAlterna { get; set; }

    }
}
