using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Application.Queries.AgentProducts;
using ES.ProductService.Domain.Entities;
using Moq;
using NUnit.Framework;
using static ES.ProductService.Application.UnitTests.Helpers.ExpressionExtensions;

namespace ES.ProductService.Application.UnitTests.QueriesUnitTests;

public class AgentProductsQueryTests
{
    private Fixture _fixture;
    private Mock<IGenericRepository<Product>> _mockRepository;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
        _mockRepository = new Mock<IGenericRepository<Product>>();
    }

    [Test]
    public async Task Handle_WhenThereAreProductsForAgent_ShouldReturnsAgentProducts()
    {
        // Arrange
        var agent = _fixture
            .Build<Agent>()
            .With(x => x.Id, Guid.NewGuid)
            .Without(x => x.Company)
            .Without(x => x.Products)
            .Without(x => x.ContactInfo)
            .Create();

        var products = _fixture
            .Build<Product>()
            .With(x => x.Agent, agent)
            .Without(x => x.Images)
            .CreateMany()
            .ToArray();

        var request = new AgentProductsQuery
        {
            AgentId = agent.Id
        };

        Expression<Func<Product, bool>> expression = p => p.Agent.Id == request.AgentId;

        _mockRepository
            .Setup(_ => _.GetRangeAsync(It.Is<Expression<Func<Product, bool>>>(exp => exp.EqualsTo(expression)),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        var queryHandler = new AgentProductsQueryHandler(_mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(new AgentProductsQuery(), new CancellationToken());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
        Assert.AreEqual(products, result);
    }

    [Test]
    public async Task Handle_WhenThereAreNotProductsForAgent_ShouldReturnsEmptyArray()
    {
        // Arrange
        var agent = _fixture
            .Build<Agent>()
            .With(x => x.Id, Guid.NewGuid)
            .Without(x => x.Company)
            .Without(x => x.Products)
            .Without(x => x.ContactInfo)
            .Create();

        var products = Array.Empty<Product>();

        var request = new AgentProductsQuery
        {
            AgentId = agent.Id
        };

        Expression<Func<Product, bool>> expression = p => p.Agent.Id == request.AgentId;

        _mockRepository
            .Setup(_ => _.GetRangeAsync(It.Is<Expression<Func<Product, bool>>>(exp => exp.EqualsTo(expression)),
                It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        var queryHandler = new AgentProductsQueryHandler(_mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(request, new CancellationToken());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
        Assert.AreEqual(products, result);
    }
}