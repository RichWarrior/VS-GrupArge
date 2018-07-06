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
    public class DetailController : Controller
    {
        private string _connectionString = "Server=localhost;Database=document;Uid=root;Password=1234;Pooling=true";

        // GET: Detail
        public ActionResult Index()
        {
            var con = new MySqlConnection(_connectionString);
            DetailViewModel viewModel = new DetailViewModel();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM detail";
                cmd.Connection = con;
                MySqlDataReader reader = null;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.detailList.Add(new Detail { id = Convert.ToInt32(reader[0]), content = reader[1].ToString(), f_key = Convert.ToInt32(reader[2].ToString()) });
                }
                reader.Close();
                cmd.CommandText = "SELECT * FROM category";
                reader = cmd.ExecuteReader();
               // viewModel.categoryList.Add(new SelectListItem { Text = "Tümü", Value = "0" });
                while (reader.Read())
                {
                    viewModel.categoryList.Add(new SelectListItem {  Text=reader[1].ToString(),Value=reader[0].ToString()});
                }
            }
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Index(int id)
        {
            int value = id;
            var con = new MySqlConnection(_connectionString);
            DetailViewModel viewModel = new DetailViewModel();
            using (var cmd = new MySqlCommand())
            {
                cmd.CommandText = "SELECT * FROM detail WHERE f_key='"+value+"'";
                cmd.Connection = con;
                MySqlDataReader reader = null;
                con.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    viewModel.detailList.Add(new Detail { id = Convert.ToInt32(reader[0]), content = reader[1].ToString(), f_key = Convert.ToInt32(reader[2].ToString()) });
                }
                reader.Close();
                cmd.CommandText = "SELECT * FROM category";
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if(reader[0].ToString()==value.ToString())
                    {
                        viewModel.categoryList.Add(new SelectListItem { Text = reader[1].ToString(), Value = reader[0].ToString(),Selected=true });
                    }
                    else
                    {
                        viewModel.categoryList.Add(new SelectListItem { Text = reader[1].ToString(), Value = reader[0].ToString(),Selected = false });
                    }
                }
            }
            return View(viewModel);
        }

        // GET: Detail/Details/5
        public ActionResult Details(int id)
        {
            var con = new MySqlConnection(_connectionString);
            Detail detailsResult = new Detail();
            using (var cmd = new MySqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM detail WHERE id='" + id + "'";
                con.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    detailsResult.id = Convert.ToInt16(reader[0]);
                    detailsResult.content = reader[1].ToString();
                    detailsResult.f_key = Convert.ToInt16(reader[2].ToString());
                }
            }
            return View(detailsResult);
        }

        // GET: Detail/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Detail/Create
        [HttpPost]
        public ActionResult Create(Detail collection)
        {
            try
            {

                var con = new MySqlConnection(_connectionString);
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "INSERT INTO detail(id,content,f_key) VALUES('" + Convert.ToInt16(collection.id) + "','" + collection.content + "','" + Convert.ToInt16(collection.f_key) + "')";
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: Detail/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Detail/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Detail collection)
        {
            try
            {
                var con = new MySqlConnection(_connectionString);
                using (var cmd = new MySqlCommand())
                {
                    cmd.Connection = con;
                    cmd.CommandText = "UPDATE detail SET content='" + collection.content + "',f_key='" + Convert.ToInt16(collection.f_key) + "' WHERE id='" + collection.id + "'";
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Detail/Delete/5
        public ActionResult Delete(int id)
        {
            
            return View();
        }

        // POST: Detail/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                try
                {
                    var con = new MySqlConnection(_connectionString);
                    using (var cmd = new MySqlCommand())
                    {
                        cmd.Connection = con;
                        cmd.CommandText = "DELETE FROM detail WHERE id='" + id + "'";
                        con.Open();
                        cmd.ExecuteNonQuery();
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
