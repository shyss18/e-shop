namespace ES.ProductService.Infrastructure.Models;

public class CompanyModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
    
    public CompanyContactInfoModel ContactInfo { get; set; }

    public ICollection<AgentModel> Agents { get; set; }

    public CompanyModel()
    {
        Agents = new List<AgentModel>();
    }
}