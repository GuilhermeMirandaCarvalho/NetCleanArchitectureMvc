using Microsoft.EntityFrameworkCore;
using NetCleanArchitectureMvc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Infra.Data.Context
{
    public class ApplicationDbContext: DbContext
    {
        /*
        base(options) está chamando o construtor da classe base DbContext e passando o parâmetro options.
        A palavra-chave base é usada em uma classe derivada para chamar um construtor da classe base correspondente. 
        Nesse caso, ApplicationDbContext é uma classe derivada da classe base DbContext. 
        Ao chamar base(options), você está passando as opções do contexto para o construtor da classe base, 
        permitindo que a classe base seja inicializada corretamente com essas opções.

        Basicamente, base(options) garante que a classe base DbContext seja corretamente inicializada com as opções fornecidas, 
        antes de qualquer lógica adicional ser executada no construtor de ApplicationDbContext.         
         */

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) { 

        }        

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }

    }
}
