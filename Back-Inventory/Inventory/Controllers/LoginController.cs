using Dapper;
using Inventory.Helps;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        ConnectionDB db_instance = new ConnectionDB();

        [HttpPost]
        public IActionResult LoginUser(string email, string password)
        {
            try 
            {
                IEnumerable<Models.Entities.Login> listUsers = null;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"SELECT * FROM Users WHERE email='{email}' AND password = '{Encrypt.GetSHA256(password)}'";
                    listUsers = db.Query<Models.Entities.Login>(sql);
                }
                return Ok(listUsers);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}