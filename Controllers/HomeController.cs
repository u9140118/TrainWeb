using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using transWEB.Models;

namespace transWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult  Index()
        {
            // await downloadfile();           
            #region 火車種類下拉選單
            List<CarClass> carclass = new List<CarClass>();
            carclass.Add(new CarClass() { carclassID = "0", carclassName = "全部" });
            carclass.Add(new CarClass() { carclassID="110",carclassName= "自強號" });
            carclass.Add(new CarClass() { carclassID = "111", carclassName = "莒光號" });
            carclass.Add(new CarClass() { carclassID = "112", carclassName = "復興號" });
            carclass.Add(new CarClass() { carclassID = "113", carclassName = "區間車" });
            ViewBag.CarClass = new SelectList(items: carclass,dataValueField: "carclassID",dataTextField:"carclassName");
            #endregion
            #region 車站下拉選單
            List<TrainInfo.TimeInfo> stationDL = new List<TrainInfo.TimeInfo>();
            stationDL.Add(new TrainInfo.TimeInfo() { Station="1008"});
            stationDL.Add(new TrainInfo.TimeInfo() { Station = "1712" });
            stationDL.Add(new TrainInfo.TimeInfo() { Station = "1715" });
            ViewBag.Station = new SelectList(items: stationDL, dataValueField: "Station", dataTextField: "StationName");
            #endregion
            
            #region POST
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/check_csearch.jsp");
            var postData = "person_id=U121474820";
            postData += "&from_station=054";
            postData += "&to_station=051";
            postData += "&getin_date=" + Server.UrlEncode("2016/09/26-00").ToUpper();
            postData += "&train_type=*1";
            postData += "&getin_start_dtime=" + Server.UrlEncode("09:00").ToUpper();
            postData += "&order_qty_str=1";
            postData += "&getin_end_dtime=" + Server.UrlEncode("17:00").ToUpper();
            postData += "&returnTicket=0";
           
            var data = Encoding.ASCII.GetBytes(postData);
            
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.CookieContainer = new CookieContainer();           
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();
            
            response.Cookies=request.CookieContainer.GetCookies(request.RequestUri);
            CookieCollection cook = response.Cookies;
            string jsessionStr=cook[0].Value.ToString();
            string strcrook = request.CookieContainer.GetCookieHeader(request.RequestUri);
            string Cookiesstr = strcrook;

            var responseString = new StreamReader(response.GetResponseStream(),Encoding.Default).ReadToEnd();    
            response.Close();
            //再POST一次
           /* HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/check_csearch.jsp");
            request2.Method = "POST";
            request2.ContentType = "application/x-www-form-urlencoded";
            request2.ContentLength = data.Length;
            Uri myUri = new Uri("http://railway1.hinet.net/");
            CookieContainer myCook = new CookieContainer();
            myCook.Add(myUri,cook);
            request2.CookieContainer = myCook;
            WebHeaderCollection myWebHeaderCollection = response.Headers;
            //Add the Accept-Language header (for Danish) in the request.
            myWebHeaderCollection.Add("Accept-Encoding:gzip,deflate\r\n");
            //Include English in the Accept-Langauge header. 
            myWebHeaderCollection.Add("Accept-Language", "zh-TW,zh;q=0.8,en-US;q=0.6;q=0.4\r\n");
            using (var stream = request2.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response2 = (HttpWebResponse)request2.GetResponse();

            string responseString2 = new StreamReader(response2.GetResponseStream(), Encoding.Default).ReadToEnd();*/

            #endregion
            #region GET
            /* HttpWebRequest request2 = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/csearch.htm");
             HttpWebResponse reponse = (HttpWebResponse)request2.GetResponse();
             Stream dataStream = reponse.GetResponseStream();
             StreamReader reader = new StreamReader(dataStream, Encoding.Default);

            

             string streamString = reader.ReadToEnd();*/
            #endregion
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
        public  async Task< bool> downloadfile(string datetring) {
            string targeturl = string.Format("http://163.29.3.98/json/{0}.zip",datetring);
            WebClient wc = new WebClient();
                           
            await  wc.DownloadFileTaskAsync(targeturl,"D:\\TEMP.ZIP");
            ZipFile.ExtractToDirectory("D:\\TEMP.ZIP", "D:\\TEMP");
            
            return true;
        }

        public async Task< ActionResult> GetDataJson(string seachtime,string carClass,string start,string end)
        {
            FileInfo file = new FileInfo(string.Format("D:\\TEMP\\{0}.json", seachtime));
            if (!file.Exists)
            {
                var downloadIsok=await  downloadfile(seachtime);
            }
            
            StreamReader sr = file.OpenText();
            var json = sr.ReadToEnd();
            var model = JsonConvert.DeserializeObject<TrainInfo.RootObject>(json);
            //區分車種
            var result1 = carClass=="0"? model.TrainInfos.ToList() : model.TrainInfos.Where(c => c.CarClass.Substring(0, 3) == carClass).ToList();
            //判斷起點站有沒有停
            var result2=result1.Where(c => c.TimeInfos.Where(b => b.Station == start).Count() != 0).ToList();
            //判斷終點站有沒有停
            var result3 = result2.Where(c => c.TimeInfos.Where(b => b.Station == end).Count() != 0).ToList();
            //區分南北向問題
            List<TrainInfo.TrainInfos> result4 = new List<TrainInfo.TrainInfos>();
            foreach(var item in result3)
            {
                bool canTake = false;
                int startOrder = 0;
                int endOrder = 0;
                foreach(var timeinfo in item.TimeInfos) 
                {
                    if(timeinfo.Station==start)
                    {
                        startOrder = Convert.ToInt32(timeinfo.Order);
                    }
                    if (timeinfo.Station == end)
                    {                                                                                                                   
                        endOrder = Convert.ToInt32(timeinfo.Order);
                    }
                }
                if(startOrder< endOrder)
                {
                    canTake = true;
                }

                if (canTake)
                {
                    result4.Add(item);
                }

            }
            //string x = "{ 'Type':'0','Train':'1033','BreastFeed':'N','Route':'','Package':'N','OverNightStn':'0','LineDir':'1','Line':'0','Dinning':'N','Cripple':'N','CarClass':'1131','Bike':'N','Note':'每日行駛。區間車(長編組)','NoteEng':'Runs Daily.','TimeInfos':[{'Route':'','Station':'1006','Order':'1','DepTime':'18:04:00','ArrTime':'18:02:00'},{'Route':'','Station':'1007','Order':'2','DepTime':'18:09:00','ArrTime':'18:08:00'},{'Route':'','Station':'1008','Order':'3','DepTime':'18:19:00','ArrTime':'18:16:00'},{'Route':'','Station':'1009','Order':'4','DepTime':'18:23:00','ArrTime':'18:23:00'},{'Route':'','Station':'1011','Order':'5','DepTime':'18:29:00','ArrTime':'18:28:00'},{'Route':'','Station':'1012','Order':'6','DepTime':'18:36:00','ArrTime':'18:35:00'},{'Route':'','Station':'1013','Order':'7','DepTime':'18:41:00','ArrTime':'18:40:00'},{'Route':'','Station':'1014','Order':'8','DepTime':'18:46:00','ArrTime':'18:45:00'},{'Route':'','Station':'1015','Order':'9','DepTime':'18:56:00','ArrTime':'18:54:00'},{'Route':'','Station':'1016','Order':'10','DepTime':'19:02:00','ArrTime':'19:01:00'},{'Route':'','Station':'1017','Order':'11','DepTime':'19:08:00','ArrTime':'19:06:00'},{'Route':'','Station':'1018','Order':'12','DepTime':'19:14:00','ArrTime':'19:13:00'},{'Route':'','Station':'1019','Order':'13','DepTime':'19:25:00','ArrTime':'19:19:00'},{'Route':'','Station':'1033','Order':'14','DepTime':'19:34:00','ArrTime':'19:33:00'},{'Route':'','Station':'1021','Order':'15','DepTime':'19:44:00','ArrTime':'19:38:00'},{'Route':'','Station':'1022','Order':'16','DepTime':'19:51:00','ArrTime':'19:50:00'},{'Route':'','Station':'1023','Order':'17','DepTime':'19:56:00','ArrTime':'19:55:00'},{'Route':'','Station':'1025','Order':'18','DepTime':'20:05:00','ArrTime':'20:03:00'}]}";

            //var js = new JavaScriptSerializer().Deserialize<Dictionary<string, object>>(x);
           // List<TrainInfo> TrainList = new List<TrainInfo>();


           
            //var array = js.ToList()[0];
            //List<TrainInfo.TrainInfos> data = array.Value as List<TrainInfo.TrainInfos>;
            //foreach (Dictionary<string, object> train in data)
            //{
            //    var test =train.Where(c => c.Key == "1098");


            //}



            return Json(result4);
        }

        public ActionResult CSearch(string imageNumber)
        {
            string URLDATA = "randInput="+imageNumber;
            URLDATA += "&person_id=U121474820&getin_date=2016%2F09%2F26-00&from_station=004&to_station=051&order_qty_str=1&train_type=*1&getin_start_dtime=09%3A00&getin_end_dtime=17%3A00&returnTicket=0";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://railway1.hinet.net/wait_order_search.jsp?"+ URLDATA);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default);

            string streamString = reader.ReadToEnd();
            return Json("success");
        }
    }
}

