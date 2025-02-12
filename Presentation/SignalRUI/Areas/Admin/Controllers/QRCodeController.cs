using System.Drawing.Imaging;
using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using QRCoder;

namespace SignalR.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class QRCodeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(string value)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                QRCodeGenerator codeGenerator = new QRCodeGenerator();

                QRCodeGenerator.QRCode squareCode = codeGenerator.CreateQrCode(value, QRCodeGenerator.ECCLevel.Q);

                using (Bitmap image = squareCode.GetGraphic(10))
                {
                    image.Save(stream, ImageFormat.Png);
                    ViewBag.QRCodeImage = "data:image/png;base64," + Convert.ToBase64String(stream.ToArray());
                }
            }

            return View();
        }
    }
}
