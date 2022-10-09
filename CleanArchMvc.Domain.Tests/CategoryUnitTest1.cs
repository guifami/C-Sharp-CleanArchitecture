using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Criar categoria com estados válidos")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Nome da Categoria");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar categoria com Id negativo")]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Nome da Categoria");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact(DisplayName = "Criar categoria com nome muito curto")]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido. Mínimo de 3 Caracteres.");
        }

        [Fact(DisplayName = "Criar categoria com nome vazio")]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Nome inválido. Campo obrigatório.");
        }

        [Fact(DisplayName = "Criar categoria com nome nulo")]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
