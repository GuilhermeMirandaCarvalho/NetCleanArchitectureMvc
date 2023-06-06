using FluentAssertions;
using NetCleanArchitectureMvc.Domain.Entities;
using Xunit;

namespace NetCleanArchitectureMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {            
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<NetCleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionValidation()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<NetCleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Id Invalido, Id esta menor que zero");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<NetCleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Preencha o Nome com mais de 3 caracter");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<NetCleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Preencha o Nome");
        }
        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionValidation()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<NetCleanArchitectureMvc.Domain.Validation.DomainExceptionValidation>().WithMessage("Preencha o Nome");
        }

    }
}