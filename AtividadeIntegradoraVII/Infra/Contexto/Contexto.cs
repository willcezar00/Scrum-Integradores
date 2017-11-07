using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Infra.Contexto
{
    public class Contexto : DbContext,IDisposable
    {
        public DbSet<Gerente> Gerentes { get; set; }

        public DbSet<Mensagem> Mensagens { get; set; }

        public DbSet<ProgramadorProjeto> ProgramadorProjeto { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }

        public DbSet<Programador> Programadores { get; set; }

        public DbSet<Projeto> Projetos { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        public virtual void Commit()
        {
            base.SaveChanges();
        }

        public new void Dispose()
        {
            base.Dispose();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Configuration.LazyLoadingEnabled = true;
            modelBuilder.Entity<Gerente>().ToTable("Gerente");
            modelBuilder.Entity<Mensagem>().ToTable("Mensagem");
            modelBuilder.Entity<Pessoa>().ToTable("Pessoa");
            modelBuilder.Entity<ProgramadorProjeto>().ToTable("ProgramadorProjeto");
            modelBuilder.Entity<Projeto>().ToTable("Projeto");
            modelBuilder.Entity<Tarefa>().ToTable("Tarefa");
        }

    }
}
