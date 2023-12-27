using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using htcssk.Models;
using System.Data;

namespace SucKhoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongTinThuocController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ThongTinThuocController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select IdThuoc,TenThuoc,SoLuong,GiaBan,NhaPhanPhoi from dbo.thongtinthuoc";
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
        public JsonResult Post(Thongtinthuoc thongtinthuoc)
        {
            string query = @"insert into dbo.thongtinthuoc values( @TenThuoc,@SoLuong,@GiaBan,@NhaPhanPhoi)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TenThuoc", thongtinthuoc.TenThuoc);
                    myCommand.Parameters.AddWithValue("@SoLuong", thongtinthuoc.SoLuong);
                    myCommand.Parameters.AddWithValue("@GiaBan", thongtinthuoc.GiaBan);
                    myCommand.Parameters.AddWithValue("@NhaPhanPhoi", thongtinthuoc.NhaPhanPhoi);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm thành công");
        }


        [HttpPut]
        public JsonResult Put(Thongtinthuoc thongtinthuoc)
        {
            string query = @"update dbo.thongtinthuoc set TenThuoc=@TenThuoc,SoLuong=@SoLuong,
                GiaBan=@GiaBan,NhaPhanPhoi= @NhaPhanPhoi 
                where IdThuoc=@IdThuoc ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdThuoc", thongtinthuoc.IdThuoc);
                    myCommand.Parameters.AddWithValue("@TenThuoc", thongtinthuoc.TenThuoc);
                    myCommand.Parameters.AddWithValue("@SoLuong", thongtinthuoc.SoLuong);
                    myCommand.Parameters.AddWithValue("@GiaBan", thongtinthuoc.GiaBan);
                    myCommand.Parameters.AddWithValue("@NhaPhanPhoi", thongtinthuoc.NhaPhanPhoi);
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
            string query = @"delete from  dbo.thongtinthuoc where IdThuoc=@IdThuoc ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdThuoc", id);
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
