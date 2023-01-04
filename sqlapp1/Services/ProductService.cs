using sqlapp1.Models;
using System.Data.SqlClient;

namespace sqlapp1.Services
{
    public class ProductService : IProductService
    {
        private readonly IConfiguration _config;

        public ProductService(IConfiguration config)
        {
            _config = config;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_config.GetConnectionString("SqlConnection"));
        }


        public List<Product> GetProducts()
        {
            SqlConnection conn = GetConnection();
            List<Product> products = new List<Product>();

            string statement = "SELECT ProductID, ProductName, Quantity FROM Products";

            conn.Open();

            SqlCommand cmd = new SqlCommand(statement, conn);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    Product product = new Product
                    {
                        ProductID = reader.GetInt32(0),
                        ProductName = reader.GetString(1),
                        Quantity = reader.GetInt32(2)
                    };
                    products.Add(product);
                }
            }
            conn.Close();
            return products;
        }
    }
}
