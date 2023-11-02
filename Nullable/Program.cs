using System.Threading.Channels;

Product product = null;

var a = product.Name;

public class Product
{
    public string Name { get; set; }
    public long Price { get; set; }
    public Category? Category { get; set; }
}

public class Category
{
    public string CategoryName { get; set; }
}