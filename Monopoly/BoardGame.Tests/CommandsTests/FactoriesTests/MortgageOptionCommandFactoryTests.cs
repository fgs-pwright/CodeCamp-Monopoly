using BoardGame.Commands;
using BoardGame.Commands.Factories;
using BoardGame.RealEstate;

using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

using Tests.Support;
using Tests.Support.Extensions;

namespace BoardGame.Tests.CommandsTests.FactoriesTests
{
    public class MortgageOptionCommandFactoryTests : BaseTest
    {
        private IPlayer _player;
        private Mock<IProperty> _mockProperty;

        private MortgageOptionCommandFactory _commandFactory;

        [SetUp]
        public void SetUp()
        {
            _player = Fixture.Create<IPlayer>();
            _mockProperty = Fixture.Mock<IProperty>();

            _commandFactory = Fixture.Create<MortgageOptionCommandFactory>();
        }

        [Test]
        public void Create_GivenPropertyIsMortgaged_ReturnsUnmortgageOptionCommand()
        {
            Given_PropertyIsMortgaged();

            var command = _commandFactory.Create(_player, _mockProperty.Object);

            Assert.That(command, Is.TypeOf<UnmortgageOptionCommand>());
        }

        [Test]
        public void Create_GivenPropertyIsNotMortgaged_ReturnsMortgageOptionCommand()
        {
            Given_PropertyIsNotMortgaged();

            var command = _commandFactory.Create(_player, _mockProperty.Object);

            Assert.That(command, Is.TypeOf<MortgageOptionCommand>());
        }

        private void Given_PropertyIsMortgaged()
        {
            _mockProperty.Setup(p => p.IsMortgaged).Returns(true);
        }

        private void Given_PropertyIsNotMortgaged()
        {
            _mockProperty.Setup(p => p.IsMortgaged).Returns(false);
        }
    }
}
