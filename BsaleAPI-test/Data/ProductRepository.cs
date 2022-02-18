using BsaleAPI_test.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BsaleAPI_test.Data
{
    public class ProductRepository : IProductRepository
    {
        private MySQLConfiguration _connectionString;
        public ProductRepository(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString;
        }

        protected MySqlConnection dbConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }
        public async Task<bool> DeleteProduct(int id)
        {
            var db = dbConnection();

            var sql = @"
                        DELETE
                        FROM product
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { Id = id });
            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, name, url_image, price, discount, category
                        FROM product";

            return await db.QueryAsync<Product>(sql, new { });
        }

        public async Task<Product> GetProductDetails(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, name, url_image, price, discount, category
                        FROM product
                        WHERE id = @Id";

            return await db.QueryFirstOrDefaultAsync<Product>(sql, new { Id = id });
        }

        public async Task<bool> InsertProduct(Product product)
        {
            var db = dbConnection();

            var sql = @"
                        INSERT INTO product (name, url_image, price, discount, category)
                        VALUES (@Name, @Url_image, @Price, @Discount, @Category)";

            var result = await db.ExecuteAsync(sql, new { product.Name, product.Url_Image, product.Price, product.Discount, product.Category });

            return result > 0;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var db = dbConnection();

            var sql = @"
                        UPDATE product 
                        SET name = @Name, url_image = @Url_image, price = @Price, discount = @Discount, category = @Category
                        WHERE id = @Id";

            var result = await db.ExecuteAsync(sql, new { product.Name, product.Url_Image, product.Price, product.Discount, product.Category, product.Id });

            return result > 0;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(int id)
        {
            var db = dbConnection();

            var sql = @"
                        SELECT id, name, url_image, price, discount, category
                        FROM product
                        WHERE category = @Id";

            return await db.QueryAsync<Product>(sql, new { Id = id });
        }
    }
}
