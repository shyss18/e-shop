using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using ES.ProductService.Application.Commands.ChangeProduct;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace ES.ProductService.Application.UnitTests.CommandsUnitTests;

public class ChangeProductCommandTests
{
    private Fixture _fixture;
    private Mock<IMapper> _mockMapper;
    private Mock<IGenericRepository<Product>> _mockRepository;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        _mockMapper = new Mock<IMapper>();
        _mockRepository = new Mock<IGenericRepository<Product>>();
    }

    [Test]
    public async Task Handle_WhenRequestReceived_ShouldInvokesChangeOnce_And_MapOnce()
    {
        // Arrange
        var request = _fixture
            .Create<ChangeProductCommand>();

        var product = _fixture
            .Build<Product>()
            .With(x => x.Id, request.Id)
            .With(x => x.Description, request.Description)
            .With(x => x.Name, request.Name)
            .With(x => x.Price, request.Price)
            .Without(x => x.Agent)
            .Without(x => x.Images)
            .Create();

        _mockMapper
            .Setup(_ => _.Map<Product>(It.Is<ChangeProductCommand>(x => x.Equals(request))))
            .Returns(product);

        _mockRepository
            .Setup(_ => _.ChangeAsync(It.Is<Product>(x => x.Equals(product)), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new ChangeProductCommandHandler(_mockMapper.Object, _mockRepository.Object);

        // Act
        await handler.Handle(request, CancellationToken.None);

        // Assert
        _mockMapper.Verify(_ => _.Map<Product>(request), Times.Once);
        _mockRepository.Verify(_ => _.ChangeAsync(product, CancellationToken.None), Times.Once);
    }
}