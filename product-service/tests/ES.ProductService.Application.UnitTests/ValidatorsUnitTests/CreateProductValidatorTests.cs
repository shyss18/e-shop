using AutoFixture;
using ES.ProductService.Application.Commands.CreateProduct;
using ES.ProductService.Application.Validators;
using NUnit.Framework;

namespace ES.ProductService.Application.UnitTests.ValidatorsUnitTests;

public class CreateProductValidatorTests
{
    private Fixture _fixture;

    [SetUp]
    public void Setup()
    {
        _fixture = new Fixture();
    }

    [Test]
    public void Validate_WhenValidModel_ShouldNotReturnsFailure()
    {
        // Arrange
        var request = _fixture.Create<CreateProductCommand>();
        var validator = new CreateProductValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
        Assert.IsEmpty(result.Errors);
    }

    [Test]
    public void Validate_WhenNotValidModel_ShouldReturnsFailure()
    {
        // Arrange
        var request = new CreateProductCommand();
        var validator = new CreateProductValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.False(result.IsValid);
        Assert.IsNotEmpty(result.Errors);
    }
}