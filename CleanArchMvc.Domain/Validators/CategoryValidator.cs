//using CleanArchMvc.Domain.Entities;
//using FluentValidation;
//using FluentValidation.Results;

//namespace CleanArchMvc.Domain.Validation
//{
//    public class CategoryValidator : AbstractValidator<Category>
//    {
//        public CategoryValidator()
//        {
//            RuleFor(x => x.Id).NotNull().NotEmpty().WithMessage("Id inválido.");

//            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("Nome inválido. Campo obrigatório.")
//                .MinimumLength(3).WithMessage("Nome inválido. Mínimo de 3 Caracteres.");
//        }
//    }
//}