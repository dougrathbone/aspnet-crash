using System.IO;
using System.Threading;
using System.Web.Mvc;
using System.Xml.Serialization;
using AspNetCrash.Web.Models;

namespace AspNetCrash.Web.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult hang()
        {
            chewUpThreads();
            return Content("Hang!");
        }

        public ActionResult sleep()
        {
            Thread.Sleep(300000);
            return Content("Sleep!");
        }

        public ActionResult memoryleak()
        {
            for (var x = 0; x <= 100; x++)
            {
                // serialize a model class, but forget to dispose it.
                var stream = new MemoryStream();
                var serialiser = new XmlSerializer(typeof(Product));
                serialiser.Serialize(stream, new Product());
                stream.Close();
            }

            return Content("Memory Leaked!");
        }

        private void chewUpThreads()
        {
            for (var x = 0; x<500; x++)
            {
                ThreadPool.QueueUserWorkItem(y => Thread.Sleep(60000));
            }
        }

        public ActionResult so()
        {
            stackOverflow();
            return Content("Crash!");
        }

        void stackOverflow()
        {
            stackOverflow();
        }
    }
}