using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using AutoMapper;
using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace ES.ProductService.Application.UnitTests.CommandsUnitTests;

public class CreateProductCommandTests
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
    public async Task Handle_WhenRequestReceived_ShouldInvokesCreateOnce_And_MapOnce()
    {
        // Arrange
        var request = _fixture
            .Create<CreateProductCommand>();

        var product = _fixture
            .Build<Product>()
            .With(x => x.Description, request.Description)
            .With(x => x.Name, request.Name)
            .With(x => x.Price, request.Price)
            .With(x => x.Images, request.Images)
            .With(x => x.Agent, new Agent
            {
                Id = request.AgentId
            })
            .Without(x => x.Id)
            .Create();

        _mockMapper
            .Setup(_ => _.Map<Product>(It.Is<CreateProductCommand>(x => x.Equals(request))))
            .Returns(product);

        _mockRepository
            .Setup(_ => _.CreateAsync(It.Is<Product>(x => x.Equals(product)), It.IsAny<CancellationToken>()))
            .Returns(Task.CompletedTask);

        var handler = new CreateProductCommandHandler(_mockMapper.Object, _mockRepository.Object);

        // Act
        await handler.Handle(request, CancellationToken.None);

        // Assert
        _mockMapper.Verify(_ => _.Map<Product>(request), Times.Once);
        _mockRepository.Verify(_ => _.CreateAsync(product, CancellationToken.None), Times.Once);
    }
}