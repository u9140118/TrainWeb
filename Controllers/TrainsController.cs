using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace transWEB.Controllers
{
    public class TrainsController : Controller
    {
        // GET: Trains
        public ActionResult Index()
        {
            ////HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/ctno1.htm");
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/csearch.htm");
            //HttpWebResponse reponse = (HttpWebResponse)request.GetResponse();
            //Stream dataStream = reponse.GetResponseStream();
            //StreamReader reader = new StreamReader(dataStream, Encoding.Default);
            //string streamString = reader.ReadToEnd();
            //ViewBag.TrainsHtml = streamString;
            ////return RedirectPermanent("http://railway1.hinet.net/csearch.htm");
            ////return Redirect("http://railway1.hinet.net/csearch.htm");
            return View();
        }
    }
}