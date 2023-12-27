using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using htcssk.Models;
using System.Data;

namespace SucKhoe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BenhNhanController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public BenhNhanController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select IdBenhNhan,TenBenhNhan,DiaChi,BenhLi,PhotoFileName from dbo.benhnhan";
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
        public JsonResult Post(Benhnhan benhnhan)
        {
            string query = @"insert into dbo.benhnhan values( @TenBenhNhan,@DiaChi,@BenhLi,@PhotoFileName)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@TenBenhNhan", benhnhan.TenBenhNhan);
                    myCommand.Parameters.AddWithValue("@DiaChi", benhnhan.DiaChi);
                    myCommand.Parameters.AddWithValue("@BenhLi", benhnhan.BenhLi);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", benhnhan.PhotoFileName);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return new JsonResult("Thêm thành công");
        }


        [HttpPut]
        public JsonResult Put(Benhnhan benhnhan)
        {
            string query = @"update dbo.benhnhan set TenBenhNhan=@TenBenhNhan,
                DiaChi=@DiaChi,BenhLi=@BenhLi,PhotoFileName= @PhotoFileName 
                where IdBenhNhan=@IdBenhNhan";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdBenhNhan", benhnhan.IdBenhNhan);
                    myCommand.Parameters.AddWithValue("@TenBenhNhan", benhnhan.TenBenhNhan);
                    myCommand.Parameters.AddWithValue("@DiaChi", benhnhan.DiaChi);
                    myCommand.Parameters.AddWithValue("@BenhLi", benhnhan.BenhLi);
                    myCommand.Parameters.AddWithValue("@PhotoFileName", benhnhan.PhotoFileName);
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
            string query = @"delete from  dbo.benhnhan where IdBenhNhan=@IdBenhNhan ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Chamsocyte");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@IdBenhNhan", id);
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
