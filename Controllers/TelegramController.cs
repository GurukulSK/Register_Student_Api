using Microsoft.AspNetCore.Mvc;
using NetTelegramBotApi.Requests;
using NetTelegramBotApi;
using System.Net.Http;
using System.Net;
using System;
using System.Security.Policy;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Student_Registration.Controllers
{
    public class request
    {
        public string? url { get; set; }
        public string? message { get; set; }
    }
    [Route("api/[controller]")]
    [ApiController]
    public class TelegramController : ControllerBase
    {
        private HttpClient httpclient = new HttpClient();

        // GET: api/<TelegramController>

        // POST api/<TelegramController>
        [HttpPost]
        public async Task<IActionResult> PostSendMessage([FromBody] request res)
        {
            var bot = new TelegramBot("5851040555:AAFWjOGSBUgUyxuqZHqahNi6oBvueEo988o", httpclient);
            try
            {
                
                var uri = new Uri(res.url);

                using (WebClient webClient = new WebClient())
                {
                    using (Stream stream = webClient.OpenRead(uri))
                    {
                        SendPhoto sendphoto = new SendPhoto(-1001493712763, new FileToSend(stream, res.url));
                        sendphoto.Caption = res.message;
                        return Ok(await bot.MakeRequestAsync(sendphoto));
                    }
                }

            }
            catch (Exception ex)
            {
                return Ok(ex);

            }
        }

    }
}
