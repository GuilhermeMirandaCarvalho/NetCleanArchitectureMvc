using NetCleanArchitectureMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCleanArchitectureMvc.Domain.Entities
{
    public sealed class Product: Entity
    {        
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }
        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Id Invalido, Id esta menor que zero");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }
        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Preencha o Nome");
            DomainExceptionValidation.When(name.Length < 3, "Preencha o Nome com mais de 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Preencha a Descrição");
            DomainExceptionValidation.When(description.Length < 5, "Preencha a descrição com mais de 5 caracteres");
            DomainExceptionValidation.When(price < 0, "Preço deve ser maior que zero");
            DomainExceptionValidation.When(stock < 0, "Estoque deve ser maior que zero");
            DomainExceptionValidation.When(image.Length > 250, "Nome imagem não pode ter mais que 250 caracteres");
            
            Name = name;
            Description= description;
            Price= price;
            Stock=stock;
            Image= image;
        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
