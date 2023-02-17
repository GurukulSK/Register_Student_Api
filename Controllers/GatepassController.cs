using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Areas;
using Newtonsoft.Json.Linq;
using NuGet.Protocol;
using Student_Registration.DbContexts;
/*using Student_Registration.Migrations;*/
using Student_Registration.Model;
using System.ComponentModel.DataAnnotations;
using System.Drawing.Drawing2D;
using System.Globalization;
using static Microsoft.AspNetCore.Razor.Language.TagHelperMetadata;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Registration.Controllers

{
    public class responce {
        public string? message { get; set; }

        public SpecialEntryModel data { get; set; }

    }
    public class cheakgid
    {
        public string? message { get; set; }
        public int? late { get; set; }
    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GatepassController : ControllerBase
    {
        private readonly RegistrationDbContext dbContext;
        public GatepassController(RegistrationDbContext _dbcontext) {
            dbContext = _dbcontext;
        }
        // GET: api/<GatepassController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await dbContext.Gatepass.ToListAsync());
        }

        // GET api/<GatepassController>/5
        [HttpGet("{gid}")]
        public IActionResult Get([MinLength(5)][MaxLength(5)] string gid)
        {

            return Ok(dbContext.Gatepass.Where(e => e.gid.Equals(gid)).OrderBy(e => e.id).AsQueryable().LastAsync().Result);
        }

        [HttpGet("{gid}")]
        public cheakgid ChekReturn([MinLength(5)][MaxLength(5)] string gid)
        {
            if (int.TryParse(gid, out int numValue))
            {
                try
                {

                    var gate = dbContext.Gatepass.Where(e => e.gid.Equals(gid)).OrderBy(e => e.id).AsQueryable().LastAsync().Result;
                    DateTime curtime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "hh:mm tt", CultureInfo.CurrentCulture);
                    DateTime commitedTime = DateTime.ParseExact(gate.commited_time, "hh:mm tt", CultureInfo.CurrentCulture);
                    cheakgid message = new cheakgid();
                    message.message = gate.returned.ToString();
                    message.late = TimeSpan.Compare(commitedTime.TimeOfDay, curtime.TimeOfDay);
                    return message;
                }
                catch
                {
                    cheakgid message = new cheakgid();
                    message.message = "True";
                    message.late = 0;
                    return message;
                }
            }
            else
            {
                cheakgid message = new cheakgid();
                message.message = "Enter Valid Gid";
                message.late = 0;
                return message;
            }
        }

        // POST api/<GatepassController>
        [HttpPost]
        public async Task<IActionResult> Entry([FromBody] EntryGatepass value)
        { int gid_count = value.gid.Count();

            for (var i = 0; i < gid_count; i++)
            {
                cheakgid returnd = ChekReturn(value.gid[i]);
                if (returnd.message == "True")
                {
                    string gid = value.gid[i];
                    Console.WriteLine(gid);
                    try
                    {
                        ValueTask<Student_data> students = dbContext.students.FindAsync(value.gid[i]);
                        Gatepass gatepass = new Gatepass();
                        gatepass.gid = students.Result.gid;
                        gatepass.name = students.Result.name;
                        gatepass.surname = students.Result.surname;
                        gatepass.reason = value.reason;
                        gatepass.father = students.Result.father;
                        gatepass.standard = students.Result.stndard;
                        gatepass.room = students.Result.room;
                        gatepass.group = gid_count < 1 ? false : true;
                        gatepass.monitar = i == 0 ? true : false;
                        gatepass.going_time = DateTime.Now.ToString("hh:mm tt", CultureInfo.CurrentCulture);
                        gatepass.commited_time = value.commited_time;
                        gatepass.with = value.with;
                        gatepass.with_number = value.with_number;
                        gatepass.with_name = value.with_name;
                        gatepass.group_id = value.group_id;
                        gatepass.place = value.place;
                        gatepass.area = value.area;
                        gatepass.permission = value.permission;
                        gatepass.comming_time = "";
                        gatepass.returned = false;
                        gatepass.late = false;
                        gatepass.late_permission = "";
                        gatepass.late_reason = "";
                        gatepass.date = DateTime.Now;
                        dbContext.Gatepass.Add(gatepass);
                        await dbContext.SaveChangesAsync();
                    }
                    catch
                    {
                        return Ok("Gid is not valid");
                    }
                }
                else
                {
                    return Ok(returnd);
                }
            }
            return Ok();

        }

        // PUT api/<GatepassController>/5
        [HttpPut]
        public async Task<IActionResult> Return([FromBody] ReturnGatepass value)
        {

            cheakgid returnd = ChekReturn(value.gid);
            if (returnd.message == "False")
            {
                int id = dbContext.Gatepass.Where(e => e.gid.Equals(value.gid)).OrderBy(e => e.id).LastAsync().Result.id;
                Gatepass gatepass = await dbContext.Gatepass.FindAsync(id);
                DateTime curtime = DateTime.ParseExact(DateTime.Now.ToString("hh:mm tt"), "hh:mm tt", CultureInfo.CurrentCulture);
                DateTime commitedTime = DateTime.ParseExact(gatepass.commited_time, "hh:mm tt", CultureInfo.CurrentCulture);
                int compare = TimeSpan.Compare(commitedTime.TimeOfDay, curtime.TimeOfDay);
                if (compare == -1)
                {
                    gatepass.late = true;
                    gatepass.late_permission = value.late_permission;
                    gatepass.late_reason = value.late_reason;

                }
                else
                {
                    gatepass.late = false;
                    gatepass.late_permission = "";
                    gatepass.late_reason += "";
                }
                gatepass.returned = true;
                gatepass.comming_time = DateTime.Now.ToString("hh:mm tt", CultureInfo.CurrentCulture);
                dbContext.Gatepass.Update(gatepass);
                return Ok(dbContext.SaveChanges());
            }
            else
            {
                return Ok(returnd);
            }


        }
        [HttpGet("{gid}")]
        public responce GetRegularList(string gid)
        {
            responce responce = new responce();
            try
            {
                SpecialEntryModel specialentrydata = dbContext.specialmodel.Where(e => e.gid == gid).OrderBy(e => e.Id).Last();
                responce.message = "Success";
                responce.data = specialentrydata;
                return responce;
            }
            catch (Exception ex)
            {
                responce.message = "Error Ouccer";
                responce.data = new SpecialEntryModel();
                return responce;
            }
        }
        [HttpGet]
        public IActionResult GetAreas()
        {
            return Ok(dbContext.area);
        }
        [HttpGet]
        public IActionResult GetPlaces()
        {
            return Ok(dbContext.place);
        }
        [HttpGet]
        public IActionResult GetReason()
        {
            return Ok(dbContext.reasons);
        }
    }
}
