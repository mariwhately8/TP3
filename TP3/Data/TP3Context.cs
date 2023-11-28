using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TP3.Models;

namespace TP3.Data
{
    public class TP3Context : DbContext
    {
        public TP3Context (DbContextOptions<TP3Context> options)
            : base(options)
        {
        }

        public DbSet<TP3.Models.LivorModel> LivorModel { get; set; } = default!;

        public DbSet<TP3.Models.ClienteModel>? ClienteModel { get; set; }

        public DbSet<TP3.Models.PedidoModel>? PedidoModel { get; set; }
    }
}
