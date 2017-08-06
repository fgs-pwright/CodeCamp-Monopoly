using System.Collections.Generic;

using BoardGame.RealEstate;

namespace BoardGame.Commands.Factories
{
    public class OfferMortgageOptionCommandFactory : ICommandFactory
    {
        private readonly IEnumerable<IPropertyGroup> _propertyGroups;
        private readonly IMortgageOptionCommandFactory _mortgageOptionCommandFactory;

        public OfferMortgageOptionCommandFactory(IEnumerable<IPropertyGroup> propertyGroups, IMortgageOptionCommandFactory mortgageOptionCommandFactory)
        {
            _propertyGroups = propertyGroups;
            _mortgageOptionCommandFactory = mortgageOptionCommandFactory;
        }

        public ICommand CreateFor(IPlayer player)
        {
            return new OfferMortgageOptionCommand(player, _propertyGroups, _mortgageOptionCommandFactory);
        }
    }
}
