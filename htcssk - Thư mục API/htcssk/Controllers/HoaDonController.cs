using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using htcssk.Models;
using System.Data;

namespace SucKhoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public HoaDonController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select IdHoaDon,IdDichVu,IdThuoc,TienThanhToan,ThoiGian,IdBenhNhan from dbo.hoadon";
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
        public JsonResult Post(Hoadon hoadon)
        {
            string query = @"insert into dbo.hoadon values( @IdDichVu,@IdThuoc,@TienThanhToan,@ThoiGian,@IdBenhNhan)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdDichVu", hoadon.IdDichVu);
                    myCommand.Parameters.AddWithValue("@IdThuoc", hoadon.IdThuoc);
                    myCommand.Parameters.AddWithValue("@TienThanhToan", hoadon.TienThanhToan);
                    myCommand.Parameters.AddWithValue("@ThoiGian", hoadon.ThoiGian);
                    myCommand.Parameters.AddWithValue("@IdBenhNhan", hoadon.IdBenhNhan);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm thành công");
        }


        [HttpPut]
        public JsonResult Put(Hoadon hoadon)
        {
            string query = @"update dbo.hoadon set IdDichVu=@IdDichVu,
                IdThuoc=@IdThuoc,TienThanhToan= @TienThanhToan ,ThoiGian= @ThoiGian,IdBenhNhan= @IdBenhNhan 
                where IdHoaDon=@IdHoaDon ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdHoaDon", hoadon.IdHoaDon);
                    myCommand.Parameters.AddWithValue("@IdDichVu", hoadon.IdDichVu);
                    myCommand.Parameters.AddWithValue("@IdThuoc", hoadon.IdThuoc);
                    myCommand.Parameters.AddWithValue("@TienThanhToan", hoadon.TienThanhToan);
                    myCommand.Parameters.AddWithValue("@ThoiGian", hoadon.ThoiGian);
                    myCommand.Parameters.AddWithValue("@IdBenhNhan", hoadon.IdBenhNhan);
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
            string query = @"delete from  dbo.hoadon where IdHoaDon=@IdHoaDon ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdHoaDon", id);
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
