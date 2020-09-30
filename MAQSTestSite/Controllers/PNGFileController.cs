using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MAQSTestSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PNGFileController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromQuery] string imageColor)
        {
            if (!string.IsNullOrEmpty(imageColor))
            {
                var color = Color.FromName(imageColor);
                if (color.A == 0 && color.B == 0 && color.G == 0 && color.R == 0)
                {
                    return NotFound();
                }

                MemoryStream ms = new MemoryStream();
                using (var bmp = new Bitmap(200, 200))
                {
                    using (Graphics g = Graphics.FromImage(bmp))
                    {
                        //Draw red rectangle to go behind cross
                        Rectangle rect = new Rectangle(0, 0, 200, 200);
                        g.FillRectangle(new SolidBrush(color), rect);
                    }

                    bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                }
                var byteArray = ms.ToArray();

                return File(byteArray, "image/png");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
