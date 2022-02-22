using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using ES.ProductService.Application.Contracts.Repositories;
using ES.ProductService.Application.Queries.Products;
using ES.ProductService.Domain.Entities;
using Moq;
using NUnit.Framework;

namespace ES.ProductService.Application.UnitTests.QueriesUnitTests;

public class ProductQueryTests
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
    public async Task Handle_WhenThereAreProducts_ShouldReturnsProducts()
    {
        // Arrange
        var query = new ProductsQuery();
        var products = _fixture
            .Build<Product>()
            .Without(x => x.Agent)
            .Without(x => x.Images)
            .CreateMany()
            .ToArray();

        _mockRepository
            .Setup(_ => _.GetRangeAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        var queryHandler = new ProductsQueryHandler(_mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, new CancellationToken());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotEmpty(result);
        Assert.AreEqual(products, result);
    }

    [Test]
    public async Task Handle_WhenThereAreNotProducts_ShouldReturnsEmptyArray()
    {
        // Arrange
        var query = new ProductsQuery();
        var products = Array.Empty<Product>();

        _mockRepository
            .Setup(_ => _.GetRangeAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(products);

        var queryHandler = new ProductsQueryHandler(_mockRepository.Object);

        // Act
        var result = await queryHandler.Handle(query, new CancellationToken());

        // Assert
        Assert.IsNotNull(result);
        Assert.IsEmpty(result);
        Assert.AreEqual(products, result);
    }
}