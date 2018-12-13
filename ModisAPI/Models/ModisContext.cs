using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModisAPI.Models
{
    public class ModisContext : DbContext
    {

        public ModisContext(DbContextOptions<ModisContext> options) : base(options)
        {

        }

        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<StudenteCorso> StudenteCorsi { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // definisce le relazioni 1 to many per la classe studentecorso
            modelBuilder.Entity<StudenteCorso>()
                .HasKey(sc => new { sc.StudenteId, sc.CorsoId });

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(bc => bc.Studente)
                .WithMany(b => b.StudenteCorsi)
                .HasForeignKey(bc => bc.StudenteId);

            modelBuilder.Entity<StudenteCorso>()
                .HasOne(bc => bc.Corso)
                .WithMany(c => c.StudenteCorsi)
                .HasForeignKey(bc => bc.CorsoId);
        }
        
    }
}
