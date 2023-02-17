using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Registration.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceDataController : ControllerBase
    {
        SqlConnection conn = new SqlConnection("Server=DESKTOP-J08PL2V\\SQLEXPRESS;Database=ONtime_Att;User Id=krish;Password=123456789;TrustServerCertificate=True;");

        // GET: api/<DeviceDataController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            SqlCommand Countcmd = new SqlCommand("SELECT IDENT_CURRENT('Tran_DeviceAttRec')", conn);
            SqlDataAdapter Countadapter = new SqlDataAdapter(Countcmd);
            DataTable Countdt = new DataTable();
            Countadapter.Fill(Countdt);
            var CountArrey = Countdt.Rows[0].ItemArray.Select(x => x.ToString()).ToArray();
            var count = CountArrey[0];
            SqlCommand cmd = new SqlCommand("Select [Punch_month],[Emp_id],[Card_Number],[Att_PunchDownDate] ,[Att_PunchRecDate] ,[sno_id] from Tran_DeviceAttRec Where [sno_id] = " + count, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            return Ok(JsonConvert.SerializeObject(dt));

        }





    }
}
