using BoardGame.Commands.Factories;
using UserInterface;

namespace BoardGame.Commands.Decorators
{
    public class VerboseCommandFactoryDecorator : ICommandFactory
    {
        private readonly ICommandFactory _decoratedCommandFactory;
        private readonly ITextWriter _textWriter;

        public VerboseCommandFactoryDecorator(ICommandFactory decoratedCommandFactory, ITextWriter textWriter)
        {
            _decoratedCommandFactory = decoratedCommandFactory;
            _textWriter = textWriter;
        }

        public ICommand CreateFor(IPlayer player)
        {
            var decoratedCommand = _decoratedCommandFactory.CreateFor(player);
            return new VerboseCommandDecorator(decoratedCommand, _textWriter);
        }
    }
}