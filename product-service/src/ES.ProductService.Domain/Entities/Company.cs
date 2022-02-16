namespace ES.ProductService.Domain.Entities;

public class Company
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public CompanyContactInfo ContactInfo { get; set; }

    public Agent[] Agents { get; set; }
}