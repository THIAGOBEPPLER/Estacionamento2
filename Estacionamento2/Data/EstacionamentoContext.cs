using Estacionamento2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Estacionamento2.Data
{
    public class EstacionamentoContext : DbContext
    {
        public DbSet<Carro> Carros { get; set; }
        public DbSet<TempoPermanencia> TemposPermanencia { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=1234;Persist Security Info=True;User ID=sa;Initial Catalog=Estacionamento2;Data Source=DESKTOP-2EBCKJD\\SQLEXPRESS");
        }

    }
}
