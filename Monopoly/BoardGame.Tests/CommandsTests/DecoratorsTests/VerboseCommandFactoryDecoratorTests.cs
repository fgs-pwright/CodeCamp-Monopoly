using BoardGame.Commands.Decorators;

using NUnit.Framework;
using Ploeh.AutoFixture;

using Tests.Support;

namespace BoardGame.Tests.CommandsTests.DecoratorsTests
{
    public class VerboseCommandFactoryDecoratorTests : BaseTest
    {
        [Test]
        public void Create_GivenDecoratedCommandFactory_ReturnsDecoratedCommand()
        {
            var factory = Fixture.Create<VerboseCommandFactoryDecorator>();
            var player = Fixture.Create<IPlayer>();

            var command = factory.CreateFor(player);

            Assert.That(command, Is.TypeOf<VerboseCommandDecorator>());
        }
    }
}