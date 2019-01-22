# <p align="center">岡山榮民之家資訊系統</p>

### 工作預定表　　　　　　　　　　　水電設備報修　　　　　　　　　資訊設備報修
  　· 線上填寫行程　　　　　　　　　　　　　　· 線上填寫報修　　　　　　　　　　　　· 線上填寫報修 <br>
  　· 查詢每日行程　　　　　　　　　　　　　　· 線上回報維修確認　　　　　　　　　　· 查詢維修進度 <br>
  　· 視覺化行程表　　　　　　　　　　　　　　· 查詢維修進度
  

  
### 管理 工作預定表　　　　　　　　　管理 水電設備報修　　　　　　　管理 資訊設備報修 
　· 過濾首長行程衝突　　　　　　　　　　　　· 線上更新維修進度　　　　　　　　　　· 線上更新維修進度 <br>
　· 自動產生每日工作表　　　　　　　　　　　· 隨時掌握各堂隊維修項目　　　　　　　· 隨時掌握各堂隊維修項目　<br>

## 首頁
![](img/index.jpg)

## 行程表填寫與行程過濾警告
<p align="center">
<img src ="img/新增每日工作預定表.jpg" width = 400>
</p>

## 行程表管理模式
<p align="center">
<img src ="img/行程管理模式.jpg" width = 400>
</p>

## 水電設備報修
<p align="center">
<img src ="img/報修.jpg" width = 400>
</p>

## 水電設備報修管理模式
<p align="center">
<img src ="img/水電報修.jpg" width = 400>
</p>

## 水電設備報修查詢
<p align="center">
<img src ="img/報修查詢.jpg" width = 400>
</p>

## 首長行程表程式碼

private List<Feed_Back> Chech_schedule_TorF(Dictionary<string, bool> TorF_Dictionary, string begin_time, string end_time, List<string> Schedule_time, List<Vaild_increment> List_Vaild)//interval_time 單位分鐘
        {
            List<Feed_Back> Feed_back = new List<Feed_Back>();
            Feed_Back FB = new Feed_Back();
            string str_Schedule_time = "";
            FB.List_Vaild = List_Vaild;
            for (int i = 0; i < Schedule_time.Count; i++)
            {
                str_Schedule_time += Schedule_time[i];
            }

            if (TorF_Dictionary[begin_time].Equals(true))
            {
                if (TorF_Dictionary[end_time].Equals(true))
                {
                    FB.Time_TorF = true;
                    FB.Advice_Time = begin_time + "~" + end_time;
                    FB.Not_Advice_Time = str_Schedule_time;
                    Feed_back.Add(FB);

                    return Feed_back;
                }
                else //結束時間為false
                {
                    FB.Time_TorF = false;
                    FB.Advice_Time = Available_time(TorF_Dictionary);
                    FB.Not_Advice_Time = str_Schedule_time;
                    Feed_back.Add(FB);
                    return Feed_back;
                }
            }
            else //開始時間為false
            {
                FB.Time_TorF = false;
                FB.Advice_Time = Available_time(TorF_Dictionary);
                FB.Not_Advice_Time = str_Schedule_time;
                Feed_back.Add(FB);

                return Feed_back;
            }
        }
        public string Available_time(Dictionary<string, bool> TorF_Dictionary)
        {
            string result = "";
            List<string> Available_begin_time = new List<string>();
            List<string> Available_end_time = new List<string>();
            for (int i = 0; i < TorF_Dictionary.Count; i++)
            {
                if (TorF_Dictionary.ElementAt(i).Value == true)//17:00 沒處理(加入17:05 false)
                {
                    if (Available_begin_time.Count == 0)
                    {
                        Available_begin_time.Add(TorF_Dictionary.ElementAt(i).Key);
                    }
                }
                else
                {
                    if (Available_end_time.Count == 0 && Available_begin_time.Count > 0)
                    {
                        Available_end_time.Add(TorF_Dictionary.ElementAt(i - 1).Key);
                        result += Available_begin_time[0] + " - " + Available_end_time[0] + "<br>";
                        Available_begin_time = new List<string>();
                        Available_end_time = new List<string>();
                    }
                }
            }

            //輸出有空的時間 建議使用者
            return result;
        }

