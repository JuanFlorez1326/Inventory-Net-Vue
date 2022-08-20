using Dapper;
using Inventory.Helps;
using Inventory.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {
        ConnectionDB db_instance = new ConnectionDB();

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                IEnumerable<Models.Entities.Users> listUsers = null;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"SELECT document_id, name, lastname, phone, age FROM Users";
                    listUsers = db.Query<Models.Entities.Users>(sql);
                }
                return Ok(listUsers);
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPost]
        public IActionResult InsertUser(Models.Entities.Users users)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"INSERT INTO Users (name, lastname, email, password, phone, age)" +
                        $" VALUES (@name, @lastname, @email, '{Encrypt.GetSHA256(users.password)}', @phone, @age)";

                    result = db.Execute(sql, users);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpPut]
        public IActionResult EditUser(Models.Entities.Users users)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"UPDATE Users SET name=@name, lastname=@lastname, phone=@phone, age=@age " +
                        $"WHERE document_id = @document_id";

                    result = db.Execute(sql, users);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeleteUser(int id_user)
        {
            try
            {
                int result = 0;
                using (var db = new SqlConnection(db_instance.connection))
                {
                    var sql = $"DELETE FROM Users WHERE document_id = {id_user}";

                    result = db.Execute(sql, id_user);
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }
    }
}