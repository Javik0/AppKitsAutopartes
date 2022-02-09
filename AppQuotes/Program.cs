using Controladores;
using Escenarios;
using Persistencia;
using System;
using Info;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AppQuotes
{
    class Program
    {
        static void Main(string[] args)
        {
            DatosInicales escenario = new DatosInicales();
            EscenarioControlador escenarioControlador = new EscenarioControlador();
            escenarioControlador.Grabar(escenario);


            string respuesta = QuoteControlador.ProcesarQuote(3);
            Console.WriteLine(respuesta + "-- ID: 3");

            string respuesta2 = QuoteControlador.ProcesarQuote(1);
            Console.WriteLine(respuesta2 + "-- ID: 1");

            string respuesta3 = QuoteControlador.ProcesarQuote(2);
            Console.WriteLine(respuesta3 + "-- ID: 2");
            
            string respuesta7 = QuoteControlador.ProcesarQuote(7);
            Console.WriteLine(respuesta7 + "-- ID: 7");

            QuoteControlador.procesarQuoteconKit(4);

            using (var db = new QuoteDB())
            {
                var quotes = db.quotes
                    .Include(quote => quote.Cliente)
                    .Include(quote => quote.QuoteParts)
                    .ThenInclude(qParts => qParts.AltParte)
                    .Include(quote => quote.Estado)
                    .ToList();

                QuoteInfo.mostrarQuotes(quotes);

                var partes = db.partes
                    .Include(partes => partes.altPartes)
                    .ToList();

                ParteInfo.mostrarPartes(partes);

            }
        }
    }
}
