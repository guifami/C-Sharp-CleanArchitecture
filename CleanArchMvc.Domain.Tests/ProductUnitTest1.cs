using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using System;
using Xunit;

namespace CleanArchMvc.Domain.Tests
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Criar produto com estados válidos")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m,
                99, "Imagem do Produto");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar produto com Id negativo")]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Nome do Produto", "Descrição do Produto", 9.99m,
                99, "Imagem do Produto");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Id inválido.");
        }

        [Fact(DisplayName = "Criar produto com nome muito curto")]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "Pr", "Descrição do Produto", 9.99m, 99,
                "Imagem do Produto");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Nome inválido. Mínimo de 3 Caracteres.");
        }

        [Fact(DisplayName = "Criar produto com nome da imagem muito longo")]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            string o = new('o', 240);
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m,
                99, $"Imagem do Produto com nome l{o}ngo");

            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Nome da imagem inválido, máximo de 250 Caracteres.");
        }

        [Fact(DisplayName = "Criar produto com nome da imagem nulo")]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar produto com nome da imagem nulo sem exceção")]
        public void CreateProduct_WithNullImageName_NoNullReferenceException()
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m, 99, null);
            action.Should().NotThrow<NullReferenceException>();
        }

        [Fact(DisplayName = "Criar produto com nome da imagem vazio")]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Criar produto com preço inválido")]
        public void CreateProduct_InvalidPriceValue_DomainExceptionInvalidPrice()
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", -9.99m, 99, "");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Preço inválido.");
        }

        [Theory(DisplayName = "Criar produto com valor inválido de estoque")]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Product(1, "Nome do Produto", "Descrição do Produto", 9.99m, value,
                "Imagem do Produto");
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Estoque inválido.");
        }

    }
}
