using htcssk.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace htcssk.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotlineController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _env;
        public HotlineController(IConfiguration configuration, IWebHostEnvironment env)
        {
            _configuration = configuration;
            _env = env;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select id,phong,sohotline,trangthai from dbo.hotline";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult(table);

        }

        [HttpPost]
        public JsonResult Post(Hotline hotline)
        {
            string query = @"insert into dbo.users values( @Id,@Phong,@SoHotLine,@TrangThai)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", hotline.Id);
                    myCommand.Parameters.AddWithValue("@Phong", hotline.Phong);
                    myCommand.Parameters.AddWithValue("@SoHotLine", hotline.Sohotline);
                    myCommand.Parameters.AddWithValue("@TrangThai", hotline.Trangthai);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm người dùng thành công");
        }


        [HttpPut]
        public JsonResult Put(Hotline hotline)
        {
            string query = @"update dbo.hotline set phong=@phong,
                sohotline=@sohotline,trangthai= @trangthai 
                where id=@id";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@id", hotline.Id);
                    myCommand.Parameters.AddWithValue("@phong", hotline.Phong);
                    myCommand.Parameters.AddWithValue("@sohotline", hotline.Sohotline);
                    myCommand.Parameters.AddWithValue("@trangthai", hotline.Trangthai);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Cập nhật thành công");
        }

        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"delete from  dbo.hotline where id=@Id ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@Id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Xóa thành công");
        }
    }
}
