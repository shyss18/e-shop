namespace ES.ProductService.Infrastructure.Models;

public class CompanyContactInfoModel
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Zip { get; set; }

    public Guid CompanyId { get; set; }
    
    public CompanyModel Company { get; set; }
}