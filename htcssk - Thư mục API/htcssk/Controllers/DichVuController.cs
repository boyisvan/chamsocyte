using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using htcssk.Models;
using System.Data;

namespace SucKhoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DichVuController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DichVuController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select IdDichVu,TenDichVu,Gia,mota from dbo.dichvu"; // câu lệnh truy vấn đến database
            DataTable table = new DataTable(); //tạo một bảng mới
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte"); // kết nối với cơ sở dữ liệu
            SqlDataReader myReader; //tạo một bảng đọc
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open(); //mở kết nối
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader(); //thưc hiện truy vấn
                    table.Load(myReader); //điền truy vấn vào bảng vừa tạo bên trên
                    myReader.Close(); //dừng ghi
                    myCon.Close();//đóng kết nối
                }
            }
            return new JsonResult(table); // trả về dữ liệu JSON là table vừa ghi 
        }

        [HttpPost]
        public JsonResult Post(Dichvu dichvu)
        {
            string query = @"insert into dbo.dichvu values( @TenDichVu,@Gia,@MoTa)"; //Câu lệnh thêm mới
            DataTable table = new DataTable(); //tạo một bảng mới
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader; //tạo bản ghi
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();//mở kết nối
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TenDichVu", dichvu.TenDichVu); //thêm các biến dữ liệu thu được vào các biến truy vấn 
                    myCommand.Parameters.AddWithValue("@Gia", dichvu.Gia);
                    myCommand.Parameters.AddWithValue("@MoTa", dichvu.MoTa);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); //tải dữ liệu vào bảng
                    myReader.Close();//dừng ghi
                    myCon.Close();//đóng kết nối
                }
            }
            return new JsonResult("Thêm thành công"); //trả về thông báo thêm thành công
        }


        [HttpPut]
        public JsonResult Put(Dichvu dichvu)
        {
            string query = @"update dbo.dichvu set TenDichVu=@TenDichVu,
                Gia=@Gia,MoTa= @MoTa 
                where IdDichVu=@IdDichVu ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdDichVu", dichvu.IdDichVu);
                    myCommand.Parameters.AddWithValue("@TenDichVu", dichvu.TenDichVu);
                    myCommand.Parameters.AddWithValue("@Gia", dichvu.Gia);
                    myCommand.Parameters.AddWithValue("@MoTa", dichvu.MoTa);
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
            string query = @"delete from  dbo.dichvu where IdDichVu=@IdDichVu ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdDichVu", id);
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
