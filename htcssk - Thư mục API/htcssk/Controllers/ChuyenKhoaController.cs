using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using htcssk.Models;
using System.Data;

namespace SucKhoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChuyenKhoaController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ChuyenKhoaController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select IdChuyenKhoa,TenChuyenKhoa from dbo.chuyenkhoa";
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
        public JsonResult Post(Chuyenkhoa chuyenkhoa)
        {
            string query = @"insert into dbo.chuyenkhoa values( @TenChuyenKhoa)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TenChuyenKhoa", chuyenkhoa.TenChuyenKhoa);;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm thành công");
        }


        [HttpPut]
        public JsonResult Put(Chuyenkhoa chuyenkhoa)
        {
            string query = @"update dbo.chuyenkhoa set TenChuyenKhoa=@TenChuyenKhoa 
                where IdChuyenKhoa=@IdChuyenKhoa ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdChuyenKhoa", chuyenkhoa.IdChuyenKhoa);
                    myCommand.Parameters.AddWithValue("@TenChuyenKhoa", chuyenkhoa.TenChuyenKhoa);
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
            string query = @"delete from  dbo.chuyenkhoa where IdChuyenKhoa=@IdChuyenKhoa ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdChuyenKhoa", id);
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
