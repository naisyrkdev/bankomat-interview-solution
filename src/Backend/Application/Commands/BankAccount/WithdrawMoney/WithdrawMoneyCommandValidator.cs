using Application.Commands.BankAccounts.WithdrawMoney;
using FluentValidation;

namespace Application.Commands.BankAccount.WithdrawMoney
{
    public class WithdrawMoneyCommandValidator : AbstractValidator<WithdrawMoneyCommand>
    {
        public WithdrawMoneyCommandValidator()
        {
            RuleFor(v => v.BankomatId)
            .NotNull();

            RuleFor(v => v.BankAccountId)
            .NotNull();

            RuleFor(v => v.AmountOfMoney)
            .NotNull();
        }
    }
}
