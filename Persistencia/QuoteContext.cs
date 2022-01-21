using Microsoft.EntityFrameworkCore;
using Modelos.Quote;

namespace Persistencia
{
    public class QuoteContext : DbContext
    {
        public DbSet<Cliente> clientes { get; set; }
        public DbSet<AltParte> altPartes { get; set; }
        public DbSet<Estado> estados { get; set; }
        public DbSet<Kit> kits { get; set; }
        public DbSet<KitPart> kitParts { get; set; }
        public DbSet<Parte> partes { get; set; }
        public DbSet<Quote> quotes { get; set; }
        public DbSet<QuotePart> quoteParts { get; set; }

        public QuoteContext() : base()
        {

        }

        public QuoteContext(DbContextOptions<QuoteContext> opciones) : base(opciones)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                QuoteConfig.ContextOptions(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltParte>()
                .HasKey(alt => new { alt.ParteId, alt.ParteAlternaId }); 

            modelBuilder.Entity<AltParte>()
                .HasOne(part => part.Parte)
                .WithMany(part => part.altPartes)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(parte => parte.ParteId);


            modelBuilder.Entity<KitPart>()
                .HasKey(kitp => new { kitp.KitId, 
                                        kitp.ParteId });
              
            modelBuilder.Entity<KitPart>()
                .HasOne(kpart => kpart.Kit)
                .WithMany(kit => kit.KitParts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(kpart => kpart.KitId);

            modelBuilder.Entity<QuotePart>()
                .HasOne(quoteP => quoteP.Quote)
                .WithMany(quote => quote.QuoteParts)
                .OnDelete(DeleteBehavior.Cascade)
                .HasForeignKey(quoteP => quoteP.QuoteId);

            modelBuilder.Entity<QuotePart>()
                .HasOne(quote => quote.Parte);
            modelBuilder.Entity<QuotePart>()
                .HasOne(quote => quote.AltParte);
        }
    }
}
