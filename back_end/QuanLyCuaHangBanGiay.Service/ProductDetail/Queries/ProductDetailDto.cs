namespace QuanLySinhVien.Model.ProductDetail.Queries;

public class ProductDetailDto
{
    public Guid Id { get; set; }
    public string NameProduct { get; set; }
    public string NameBrand { get; set; }
    public string NameCategory { get; set; }
    public string NameColor { get; set; }
    public string Image { get; set; }
    public string NameMaterial { get; set; }
    public string NameSize { get; set; }
    public string Price { get; set; }
    public string Quantity { get; set; }
}