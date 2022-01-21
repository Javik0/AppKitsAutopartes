using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Quote
{
    public class Quote :  IDBEntity
    {
        public int QuoteId { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public List<QuotePart> QuoteParts { get; set; }
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
        public int? KitId { get; set; }
        #nullable enable
        public Kit? kit { get; set; }
    }
}
