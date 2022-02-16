namespace ES.ProductService.Domain.Entities;

public class AgentContactInfo
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Zip { get; set; }

    public Agent Agent { get; set; }
}