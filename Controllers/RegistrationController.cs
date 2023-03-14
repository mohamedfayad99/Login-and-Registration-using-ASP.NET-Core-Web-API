using LoginRegistration.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LoginRegistration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {

        private readonly IConfiguration _configuration;
        public RegistrationController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [Route("registration")]
        public string registration(Registration registration)
        {
            SqlConnection con= new SqlConnection(_configuration.GetConnectionString("toyscon").ToString());
            SqlCommand cmd = new SqlCommand("INSERT INTO Registration(UserName,Password,ConfirmPassword,PhoneNumber,BPhoneNumber) VALUES('" + registration.UserName+"','"+registration.Password+"','"+registration.ConfirmPassword+"','"+registration.PhoneNumber+"','"+registration.BPhoneNumber+"')", con);
            con.Open();
            int i= cmd.ExecuteNonQuery();
            con.Close();
            if (registration.Password != registration.ConfirmPassword)
            {
                return "please inter correct password";
            }
            if (i > 0)
            {
                return "Data inserted";
            }
            else
            {
                return "Error";
            }
            
        }
        [HttpPost]
        [Route("Login")]
        public string login(Registration registration)
        {
            SqlConnection con = new SqlConnection(_configuration.GetConnectionString("toyscon").ToString());
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Registration WHERE PhoneNumber ='"+registration.PhoneNumber+"' AND Password ='"+registration.Password+"' ", con);
            DataTable dt= new DataTable();
            da.Fill(dt);
            
            if (dt.Rows.Count > 0)
            {
                return "Data Found";
            }
            else
            {
                return "InValid User";
            }


           
        }
    }

   
   
}
