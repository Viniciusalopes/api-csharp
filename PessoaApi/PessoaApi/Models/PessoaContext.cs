//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace PessoaApi.Models
{
    public class PessoaContext : DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }

    }
}
