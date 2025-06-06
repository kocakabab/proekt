
using Microsoft.AspNetCore.Mvc;
using BariApp.Models;
using System.Collections.Generic;
using System.Data.SQLite;

namespace BariApp.Controllers
{
    public class DogsController : Controller
    {
        public IActionResult Index()
        {
            var dogs = new List<Dog>();

            using (var connection = new SQLiteConnection("Data Source=App_Data/BariApp.db"))
            {
                connection.Open();
                var command = new SQLiteCommand("SELECT * FROM Dog", connection);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dogs.Add(new Dog
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(2),
                        Breed = reader.GetString(3),
                        Country = reader.GetString(4),
                        Description = reader.GetString(5),
                        PhotoUrl = reader.GetString(6)
                    });
                }
            }

            return View(dogs);
        }
    }
}
