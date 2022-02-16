namespace ES.ProductService.Domain.Entities;

public class Agent
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Product[] Products { get; set; }

    public AgentContactInfo ContactInfo { get; set; }

    public Company Company { get; set; }
}