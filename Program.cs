using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FISCA;
using FISCA.Presentation;
using FISCA.Permission;
using System.Xml.Linq;

namespace LeaveReadCard
{
    public static class Program
    {
        public const string SetupFormCoode = "請假讀卡模組.請假讀卡設定";

        public const string ReadCardFormCode = "請假讀卡模組.請假讀卡";

        [MainMethod()]
        public static void Main()
        {
            RibbonBarItemManager ribbon = FISCA.Presentation.MotherForm.RibbonBarItems;

            ribbon["學務作業", "請假讀卡"]["設定"].Image = Properties.Resources.sandglass_unlock_64;

            MenuButton button = ribbon["學務作業", "請假讀卡"]["設定"]["讀卡設定"];
            button.Enable = UserAcl.Current[SetupFormCoode].Executable;
            button.Click += delegate
            {
                new SetupForm().ShowDialog();
            };

            button = ribbon["學務作業", "請假讀卡"]["讀卡"];
            button.Image = Properties.Resources.ReadCard;
            button.Enable = UserAcl.Current[ReadCardFormCode].Executable;
            button.Click += delegate
            {
                new ReadCardForm().ShowDialog();
            };

            Catalog catalog = RoleAclSource.Instance["學務作業"]["功能按鈕"];
            catalog.Add(new RibbonFeature(SetupFormCoode, "請假讀卡設定"));
            catalog.Add(new RibbonFeature(ReadCardFormCode, "請假讀卡"));


            InitCardSettingData();
        }

        // 2017/11/27，羿均，修改節次與假別的設定，動態讀取xml上所做的設定，讓讀卡模組更有彈性。

        /// <summary>
        /// 卡片上所提供的節次列表。
        /// </summary>
        public static string[] PeriodNameList = new string[] { };

        /// <summary>
        /// 卡片上所提供的假別列表。
        /// </summary>
        public static string[] LeaveNameList = new string[] { };

        public static void InitCardSettingData()
        {
            // 2017/11/29，羿均，新增LeaveCardSetting欄位在list Tabel，再透過中央管理系統update 讀卡解析設定xml
            K12.Data.Configuration.ConfigData _LeaveCardSetting = K12.Data.School.Configuration["LeaveCardSetting"];
            _LeaveCardSetting.Save();

            // 取得卡片解析設定
            XDocument LeaveCardSetting = XDocument.Parse(_LeaveCardSetting.PreviousData.InnerXml);
            //XDocument LeaveCardSetting = XDocument.Parse(LeaveReadCard.Properties.Resources.LeaveCardSetting);
            XElement period = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarPeriod");
            XElement absenceType = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceType");

            PeriodNameList = period.Descendants("Position").Select(element => element.Attribute("Value").Value).ToArray();

            LeaveNameList = absenceType.Descendants("Position").Select(element => element.Attribute("Value").Value).ToArray();
        }


        //2016/9/2 穎驊紀錄，下面這項不會再被用到，因為每張卡片每年都有可能會改起始年度，
        //起始年度將由UI給使用者自訂

        /// <summary>
        /// 卡片上的起始年度。
        /// </summary>
        //public static int StartYear = 104;
    }
}
