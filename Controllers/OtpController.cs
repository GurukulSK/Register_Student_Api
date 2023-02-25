using Microsoft.AspNetCore.Mvc;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi;
using Student_Registration.DbContexts;
using Student_Registration.Model;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Registration.Controllers
{
    public class otpresponce
    {
        public int verify_id { get; set; }
        public bool verify { get; set; } = false;
    }
    public class veryfyRss
    {
        public int verify_id { get; set; }
        public string? gid { get; set; }
        public string? error { get; set; }
        public bool verify { get; set; }
    }
    public class otprequest
    {
        [Required]
        public int id { get; set; }
        [Required]
        [MaxLength(5)]
        [MinLength(5)]
        public string? gid { get; set; }
        [Required]
        [MaxLength(6)]
        [MinLength(6)]
        public string? otp { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class OtpController : ControllerBase
    {
        // GET: api/<OtpController>
        private readonly RegistrationDbContext dbContext;
        HttpClient httpclient = new HttpClient();
       
        public OtpController(RegistrationDbContext _dbcontext)
        {
            dbContext = _dbcontext;
        }   
        // GET api/<OtpController>/5
        [HttpGet("{gid}")]
        public async Task<otpresponce> GetGanretOtp(string gid)
        {
            var random = new Random();
            int number = random.Next(100000, 999999);
            OtpModel model = new OtpModel();
            model.gid = gid;
            model.otp = number;
            dbContext.otp.Add(model);
            dbContext.SaveChanges();
            int id = dbContext.otp.Where(e => e.otp == number).Where(e => e.gid == gid).OrderBy(e=>e.Id).Last().Id;
            var bot = new TelegramBot("5851040555:AAFWjOGSBUgUyxuqZHqahNi6oBvueEo988o",httpclient);
            SendMessage sendMessage = new SendMessage(-1001873566418, "<b>" + gid + "</b>\n" + "OTP:" + number);
            sendMessage.ParseMode = SendMessage.ParseModeEnum.HTML;
            var me = await bot.MakeRequestAsync(sendMessage);
            return new otpresponce { verify_id = id, verify = false };
        }

        // POST api/<OtpController>
        [HttpPost]
        public async Task<veryfyRss> PostVerifyOtp(otprequest value)
        {
            OtpModel otp = await dbContext.otp.FindAsync(value.id);
            if (otp.verified == false)
            { 
                if (otp.gid == value.gid)
                {
                    if (otp.otp.ToString() == value.otp.ToString())
                    {
                        otp.verified = true;
                        dbContext.otp.Update(otp);
                        dbContext.SaveChanges();
                        return new veryfyRss { verify_id = value.id, gid = otp.gid, verify = true, error = "No Error" };
                    }
                }
        }
            return  new veryfyRss { verify_id = value.id, gid = otp.gid, verify = false, error = "Enter Valid Value" }; ;
        }
    }
}
