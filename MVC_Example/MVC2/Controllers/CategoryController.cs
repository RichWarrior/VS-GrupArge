using MVC2.Models;
using MVC2.ViewModel;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC2.Controllers
{
    public class CategoryController : Controller
    {
        private string _connectionString = "Server=localhost;Database=document;Uid=root;Password=1234;Pooling=true";

        // GET: Category
        public ActionResult Index()
        {
            var con = new MySqlConnection(_connectionString);
            CategoryViewModel viewModel = new CategoryViewModel();
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM category";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.categoryList.Add(new Category { id = Convert.ToInt32(reader[0].ToString()), category_name = reader[1].ToString()});
                }
            }
            return View(viewModel);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            var con = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand("SELECT * FROM category Where id='"+id+"'",con);
            con.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            Category viewModel = new Category();
            while (reader.Read())
            {
                viewModel.id = Convert.ToInt32(reader[0].ToString());
                viewModel.category_name = reader[1].ToString();
            }
            reader.Close();
            return View(viewModel);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category collection)
        {
            try
            {
                var con = new MySqlConnection(_connectionString);
                var cmd = new MySqlCommand("INSERT INTO category(category_name,f_key) VALUES('"+collection.category_name+"','"+Convert.ToInt16(collection.f_key)+"')",con);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Category collection)
        {
            try
            {

                var con = new MySqlConnection(_connectionString);
                var cmd = new MySqlCommand("UPDATE category SET category_name='"+collection.category_name+"',f_key='"+collection.f_key+"' WHERE id='"+id+"'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var con = new MySqlConnection(_connectionString);
                var cmd = new MySqlCommand("DELETE FROM category WHERE id='"+id+"'",con);
                con.Open();
                cmd.ExecuteNonQuery();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
