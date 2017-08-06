using BoardGame.RealEstate;
using UserInterface.Choices;

namespace BoardGame.Commands.Factories
{
    public class MortgageOptionCommandFactory : IMortgageOptionCommandFactory
    {
        private readonly ITransactionCommandFactory _withdrawalCommandFactory;
        private readonly ITransactionCommandFactory _depositCommandFactory;
        private readonly IOptionSelector _optionSelector;

        public MortgageOptionCommandFactory(
            ITransactionCommandFactory withdrawalCommandFactory,
            ITransactionCommandFactory depositCommandFactory,
            IOptionSelector optionSelector)
        {
            _withdrawalCommandFactory = withdrawalCommandFactory;
            _depositCommandFactory = depositCommandFactory;
            _optionSelector = optionSelector;
        }

        public ICommand Create(IPlayer player, IProperty property)
        {
            if (property.IsMortgaged)
                return new UnmortgageOptionCommand(player, property, _withdrawalCommandFactory, _optionSelector);
            return new MortgageOptionCommand(player, property, _depositCommandFactory, _optionSelector);
        }
    }
}
