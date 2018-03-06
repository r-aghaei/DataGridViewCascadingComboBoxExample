using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridViewCascadingComboBoxExample
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }
    public class OrderItem
    {
        public int? CategoryId { get; set; }
        public int? ProductId { get; set; }
        public int Quantity { get; set; }
    }

    public class Repository
    {
        private static List<Category> categories;
        private static List<Product> products;
        private static List<OrderItem> orderItems;
        public static List<Category> GetCategories()
        {
            if (categories == null)
                categories = new List<Category> {
                    new Category(){Id=1, Name="C1"},
                    new Category(){Id=2, Name="C2"}
                };
            return categories;
        }
        public static List<Product> GetProducts()
        {
            if (products == null)
                products = new List<Product> {
                    new Product(){Id=1, Name="P1", CategoryId= 1},
                    new Product(){Id=2, Name="P2", CategoryId= 1},
                    new Product(){Id=3, Name="P3", CategoryId= 2},
                    new Product(){Id=4, Name="P4", CategoryId= 2}
                };
            return products;
        }
        public static List<OrderItem> GetOrderItems()
        {
            if (orderItems == null)
                orderItems = new List<OrderItem> {
                    new OrderItem(){ CategoryId=2, ProductId=3, Quantity=10},
                    new OrderItem(){ CategoryId=1, ProductId=1, Quantity=10},
                };
            return orderItems;
        }
    }
}
