using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace transWEB.Models
{
    public class TrainInfo
    {
        public static string setStationName(string Station) {
            string Result = "";
            switch (Station.Substring(0,2))
            {
                case "10":
                    #region 北部
                    switch (Station.Substring(2, 2))
                    {
                        case "01":
                            Result = "基隆";
                            break;
                        case "02":
                            Result = "八堵";
                            break;
                        case "03":
                            Result = "七堵";
                            break;
                        case "04":
                            Result = "五堵";
                            break;
                        case "05":
                            Result = "汐止";
                            break;
                        case "06":
                            Result = "南港";
                            break;
                        case "07":
                            Result = "松山";
                            break;
                        case "08":
                            Result = "台北";
                            break;
                        case "09":
                            Result = "南華";
                            break;
                        case "11":
                            Result = "板橋";
                            break;
                        case "32":
                            Result = "浮洲";
                            break;
                        case "12":
                            Result = "樹林";
                            break;
                        case "13":
                            Result = "山桂";
                            break;
                        case "14":
                            Result = "鶯歌";
                            break;
                        case "15":
                            Result = "桃園";
                            break;
                        case "16":
                            Result = "內壢";
                            break;
                        case "17":
                            Result = "中壢";
                            break;
                        case "18":
                            Result = "埔心";
                            break;
                        case "19":
                            Result = "楊梅";
                            break;
                        case "20":
                            Result = "富岡";
                            break;
                        case "21":
                            Result = "湖口";
                            break;
                        case "22":
                            Result = "新豐";
                            break;
                        case "23":
                            Result = "竹北";
                            break;
                        case "24":
                            Result = "北新竹";
                            break;
                        case "25":
                            Result = "新竹";
                            break;
                        case "26":
                            Result = "香山";
                            break;
                        case "27":
                            Result = "崎頂";
                            break;
                        case "28":
                            Result = "竹南";
                            break;
                        case "29":
                            Result = "三坑";
                            break;
                        case "30":
                            Result = "百福";
                            break;
                        case "31":
                            Result = "汐科";
                            break;
                        case "34":
                            Result = "南樹林";
                            break;
                    }
                    #endregion
                    break;
                case "11":
                    #region 中部吧?
                    switch(Station.Substring(2,2))
                    {
                        case "02":
                            Result = "談文";
                            break;
                        case "03":
                            Result = "談文南";
                            break;
                        case "04":
                            Result = "大山";
                            break;
                        case "05":
                            Result = "後龍";
                            break;
                        case "06":
                            Result = "龍港";
                            break;
                        case "07":
                            Result = "白沙屯";
                            break;
                        case "08":
                            Result = "新埔";
                            break;
                        case "09":
                            Result = "通霄";
                            break;
                        case "10":
                            Result = "苑裡";
                            break;
                        case "11":
                            Result = "日南";
                            break;
                        case "12":
                            Result = "大甲";
                            break;
                        case "13":
                            Result = "台中港";
                            break;
                        case "14":
                            Result = "清水";
                            break;
                        case "15":
                            Result = "沙鹿";
                            break;
                        case "16":
                            Result = "龍井";
                            break;
                        case "17":
                            Result = "大肚";
                            break;
                        case "18":
                            Result = "追分";
                            break;
                        case "19":
                            Result = "大肚溪南";
                            break;
                        case "20":
                            Result = "彰化";
                            break;
                    }
                    #endregion
                    break;
                case "12":
                    #region 中部之雲南嘉高吧?
                    switch(Station.Substring(2,2))
                    {
                        case "02":
                            Result = "花壇";
                            break;
                        case "03":
                            Result = "員林";
                            break;
                        case "04":
                            Result = "永靖";
                            break;
                        case "05":
                            Result = "社頭";
                            break;
                        case "06":
                            Result = "田中";
                            break;
                        case "07":
                            Result = "二水";
                            break;
                        case "08":
                            Result = "林內";
                            break;
                        case "09":
                            Result = "石榴";
                            break;
                        case "10":
                            Result = "斗六";
                            break;
                        case "11":
                            Result = "斗南";
                            break;
                        case "12":
                            Result = "石龜";
                            break;
                        case "13":
                            Result = "大林";
                            break;
                        case "14":
                            Result = "民雄";
                            break;
                        case "15":
                            Result = "嘉義";
                            break;
                        case "17":
                            Result = "水上";
                            break;
                        case "18":
                            Result = "南靖";
                            break;
                        case "19":
                            Result = "後壁";
                            break;
                        case "20":
                            Result = "新營";
                            break;
                        case "21":
                            Result = "柳營";
                            break;
                        case "22":
                            Result = "林鳳營";
                            break;
                        case "23":
                            Result = "隆田";
                            break;
                        case "24":
                            Result = "拔林";
                            break;
                        case "25":
                            Result = "善化";
                            break;
                        case "26":
                            Result = "新市";
                            break;
                        case "27":
                            Result = "永康";
                            break;
                        case "28":
                            Result = "台南";
                            break;
                        case "29":
                            Result = "保安";
                            break;
                        case "30":
                            Result = "中洲";
                            break;
                        case "31":
                            Result = "大湖";
                            break;
                        case "32":
                            Result = "路竹";
                            break;
                        case "33":
                            Result = "岡山";
                            break;
                        case "34":
                            Result = "橋頭";
                            break;
                        case "35":
                            Result = "楠梓";
                            break;
                        case "36":
                            Result = "左營";
                            break;
                        case "37":
                            Result = "鼓山";
                            break;
                        case "38":
                            Result = "高雄";
                            break;
                        case "39":
                            Result = "大橋";
                            break;
                        case "40":
                            Result = "大村";
                            break;
                        case "41":
                            Result = "嘉北";
                            break;
                        case "42":
                            Result = "新左營";
                            break;


                    }
                    #endregion
                    break;
                case "17":
                    #region 蘇花
                    switch(Station.Substring(2,2))
                    {
                        case "03":
                            Result = "永樂";
                            break;
                        case "04":
                            Result = "東澳";
                            break;
                        case "05":
                            Result = "南澳";
                            break;
                        case "06":
                            Result = "武塔";
                            break;
                        case "08":
                            Result = "漢本";
                            break;
                        case "09":
                            Result = "和平";
                            break;
                        case "10":
                            Result = "和仁";
                            break;
                        case "11":
                            Result = "崇德";
                            break;
                        case "12":
                            Result = "新城";
                            break;
                        case "13":
                            Result = "景美";
                            break;
                        case "14":
                            Result = "北埔";
                            break;
                        case "15":
                            Result = "花蓮";
                            break;
                           

                    }
                    #endregion
                    break;
                case "16":
                    #region 花東
                    switch(Station.Substring(2,2))
                    {
                        case "02":
                            Result = "吉安";
                            break;
                        case "04":
                            Result = "志學";
                            break;
                        case "05":
                            Result = "平和";
                            break;
                        case "06":
                            Result = "壽豐";
                            break;
                        case "07":
                            Result = "豐田";
                            break;
                        case "08":
                            Result = "溪口";
                            break;
                        case "09":
                            Result = "南平";
                            break;
                        case "10":
                            Result = "鳳林";
                            break;
                        case "11":
                            Result = "萬榮";
                            break;
                        case "12":
                            Result = "光復";
                            break;
                        case "13":
                            Result = "大富";
                            break;
                        case "14":
                            Result = "富源";
                            break;
                        case "16":
                            Result = "瑞穗";
                            break;
                        case "17":
                            Result = "三民";
                            break;
                        case "19":
                            Result = "玉里";
                            break;
                        case "20":
                            Result = "安通";
                            break;
                        case "21":
                            Result = "東里";
                            break;
                        case "22":
                            Result = "東竹";
                            break;
                        case "23":
                            Result = "富里";
                            break;
                        case "24":
                            Result = "池上";
                            break;
                        case "25":
                            Result = "海端";
                            break;
                        case "26":
                            Result = "關山";
                            break;
                        case "27":
                            Result = "月美";
                            break;
                        case "28":
                            Result = "瑞和";
                            break;
                        case "29":
                            Result = "瑞源";
                            break;
                        case "30":
                            Result = "鹿野";
                            break;
                        case "31":
                            Result = "山里";
                            break;
                        case "32":
                            Result = "台東";
                            break;
                        case "35":
                            Result = "舞鶴";
                            break;                            
                    }
                    #endregion
                    break;
                case "18":
                    #region 北宜地區
                    switch(Station.Substring(2,2))
                    {
                        case "02":
                            Result = "暖暖";
                            break;
                        case "03":
                            Result = "四腳亭";
                            break;
                        case "04":
                            Result = "瑞芳";
                            break;
                        case "05":
                            Result = "侯硐";
                            break;
                        case "06":
                            Result = "三貂嶺";
                            break;
                        case "07":
                            Result = "牡丹";
                            break;
                        case "08":
                            Result = "雙溪";
                            break;
                        case "09":
                            Result = "貢寮";
                            break;
                        case "10":
                            Result = "福隆";
                            break;
                        case "11":
                            Result = "石城";
                            break;
                        case "12":
                            Result = "大里";
                            break;
                        case "13":
                            Result = "大溪";
                            break;
                        case "14":
                            Result = "龜山";
                            break;
                        case "15":
                            Result = "外澳";
                            break;
                        case "16":
                            Result = "頭城";
                            break;
                        case "17":
                            Result = "頂埔";
                            break;
                        case "18":
                            Result = "礁溪";
                            break;
                        case "19":
                            Result = "四城";
                            break;
                        case "20":
                            Result = "宜蘭";
                            break;
                        case "21":
                            Result = "二結";
                            break;
                        case "22":
                            Result = "中里";
                            break;
                        case "23":
                            Result = "羅東";
                            break;
                        case "24":
                            Result = "冬山";
                            break;
                        case "25":
                            Result = "新馬";
                            break;
                        case "26":
                            Result = "蘇澳新";
                            break;
                        case "27":
                            Result = "蘇澳";
                            break;                           

                    }
                    #endregion
                    break;
            };
            return Result;
        }
        public static string setCarClassName(string carclass)
        {
            var result = "";
            switch(carclass.Substring(0,3))
            {
                case "110":
                    #region 自強號系列
                    switch(carclass.Substring(3,1))
                    {
                        
                        case "2":
                            result = "太魯閣號";
                            break;
                        case "7":
                            result = "普悠瑪號";
                            break;
                        default:
                            result = "自強號";
                            break;
                        

                    }
                    #endregion
                    break;
                case "111":
                    result = "莒光號";
                    break;
                case "112":
                    result = "復興號";
                    break;
                case "113":
                    #region 區間
                    switch(carclass.Substring(3,1))
                    {
                        case "1":
                            result = "區間車";
                            break;
                        case "2":
                            result = "區間快";
                            break;
                    }
                    #endregion
                    break;                
                case "114":
                    result = "普快車";
                    break;
            }

            return result;
            
        }
        
        public class TimeInfo
        {
            public string Route { get; set; }
            public string Station { get; set; }
            public string StationName { get { return setStationName(Station); } set { } }
            public string Order { get; set; }
            public string DepTime { get; set; }
            public string ArrTime { get; set; }
        }

        public class TrainInfos
        {
            public string Type { get; set; }
            public string Train { get; set; }
            public string BreastFeed { get; set; }
            public string Route { get; set; }
            public string Package { get; set; }
            public string OverNightStn { get; set; }
            public string LineDir { get; set; }
            public string Line { get; set; }
            public string Dinning { get; set; }
            public string Cripple { get; set; }
            public string CarClass { get; set; }
            public string CarClassName { get { return setCarClassName(CarClass); } set { } }
            public string Bike { get; set; }
            public string Note { get; set; }
            public string NoteEng { get; set; }
            public List<TimeInfo> TimeInfos { get; set; }
        }

        public class RootObject
        {
            public List<TrainInfos> TrainInfos { get; set; }
        }

    }
}