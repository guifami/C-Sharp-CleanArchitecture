//using CleanArchMvc.Domain.Entities;
//using FluentValidation;
//using FluentValidation.Results;

//namespace CleanArchMvc.Domain.Validation
//{
//    public class ProductValidator : AbstractValidator<Product>
//    {
//        public ProductValidator()
//        {
//            RuleFor(x => x.Id).LessThan(0).WithMessage("Id inválido.");

//            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Nome inválido. Campo obrigatório.")
//                .MinimumLength(3).WithMessage("Nome inválido. Mínimo de 3 Caracteres.");

//            RuleFor(x => x.Description).NotNull().NotEmpty().WithMessage("Descrição inválida. Campo obrigatório.")
//                .MinimumLength(5).WithMessage("Descrição inválida. Mínimo de 5 Caracteres.");

//            RuleFor(x => x.Price).LessThan(0).WithMessage("Preço inválido.");

//            RuleFor(x => x.Stock).LessThan(0).WithMessage("Estoque inválido.");

//            RuleFor(x => x.Image).MinimumLength(250).WithMessage("Nome da imagem inválido, máximo de 250 Caracteres.");
//        }
//    }
//}