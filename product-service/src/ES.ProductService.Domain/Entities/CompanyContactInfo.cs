namespace ES.ProductService.Domain.Entities;

public class CompanyContactInfo
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string Address { get; set; }

    public string Zip { get; set; }

    public Company Company { get; set; }
}