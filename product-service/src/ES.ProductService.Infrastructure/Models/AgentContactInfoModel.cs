namespace ES.ProductService.Infrastructure.Models;

public class AgentContactInfoModel
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Zip { get; set; }

    public Guid AgentId { get; set; }
    
    public AgentModel Agent { get; set; }
}