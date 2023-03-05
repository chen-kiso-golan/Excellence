namespace WebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int UnitsInStock { get; set; }
        public string DepartmentName { get; set; }
    }
}
