namespace ES.ProductService.Infrastructure.Models;

public class AgentModel
{
    public Guid Id { get; set; }

    public string Name { get; set; }
    
    public AgentContactInfoModel ContactInfo { get; set; }

    public Guid CompanyId { get; set; }
    
    public CompanyModel Company { get; set; }
    
    public ICollection<ProductModel> Products { get; set; }

    public AgentModel()
    {
        Products = new List<ProductModel>();
    }
}