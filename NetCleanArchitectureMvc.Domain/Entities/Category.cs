using NetCleanArchitectureMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Domain.Entities
{
    public sealed class Category: Entity
    {        
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id<0, "Id Invalido, Id esta menor que zero");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }

        public ICollection<Product> Products { get; private set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Preencha o Nome");
            DomainExceptionValidation.When(name.Length<3, "Preencha o Nome com mais de 3 caracter");  

            Name= name;
        }

    }
}
