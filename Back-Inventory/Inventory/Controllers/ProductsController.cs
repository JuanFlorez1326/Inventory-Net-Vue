using Dapper;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ConnectionDB db_instance = new ConnectionDB();

        [HttpGet("Products")]
        public IActionResult GetProduct()
        {
            try
            {
                IEnumerable<Models.Entities.Products> listProducts = null;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"SELECT * FROM Products";
                    listProducts = db.Query<Models.Entities.Products>(sql);
                }
                return Ok(listProducts);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpGet("Product")]
        public IActionResult GetProducts(int id_user)
        {
            try
            {
                IEnumerable<Models.Entities.Products> listProducts = null;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"SELECT p.* FROM Products p JOIN Users u ON " +
                        $"p.user_product = u.document_id WHERE p.user_product = {id_user};";

                    listProducts = db.Query<Models.Entities.Products>(sql);
                }
                return Ok(listProducts);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertProduct(Models.Entities.Products products)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"INSERT INTO Products (user_product, name_product, description, tickets, departures, total, seller, image_url, price)" +
                        $" VALUES (@user_productId, @name_product, @description, @tickets, @departures, @total, @seller, @image_url, @price)";

                    result = db.Execute(sql, products);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditProduct(Models.Entities.Products products)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"UPDATE Products SET name_product=@name_product, description=@description, tickets=@tickets, departures=@departures, " +
                        $"total=@total, seller=@seller, image_url=@image_url, price=@price  WHERE id_product = @id_product";

                    result = db.Execute(sql, products);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteProducts(int id_product)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"DELETE FROM Products WHERE id_product = {id_product}";

                    result = db.Execute(sql, id_product);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}