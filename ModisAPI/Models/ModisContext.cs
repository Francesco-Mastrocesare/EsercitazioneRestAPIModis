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
        public DbSet<Esame> Esami { get; set; }
        public DbSet<EsameStudente> EsamiStudenti { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
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

            modelBuilder.Entity<EsameStudente>()
            .HasKey(es => new { es.StudenteId, es.EsameId });

            modelBuilder.Entity<EsameStudente>()
            .HasOne(bc => bc.Studente)
            .WithMany(b => b.EsameStudenti)
            .HasForeignKey(bc => bc.StudenteId);

            modelBuilder.Entity<EsameStudente>()
                .HasOne(bc => bc.Esame)
                .WithMany(c => c.EsameStudenti)
                .HasForeignKey(bc => bc.EsameId);
        }
    }

}
