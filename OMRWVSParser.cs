using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Campus.Configuration;

namespace LeaveReadCard
{
    /// <summary>
    /// 請假卡資料解析。
    /// </summary>
    public class WVSOMRParser
    {
        // 2017/11/30 羿均 將出勤點名卡的程式碼刪除。讓點名讀卡、請假讀卡拆解成兩個獨立的模組。
		private sealed class LeaveStudentNumberParser : Decorator
		{
            //	請假卡「學號」之畫記的絕對位置：10列6行
            //private readonly List<List<int>> Position = new List<List<int>> ();

            //public LeaveStudentNumberParser()
            //{
            //	for(int i=0; i<6; i++)
            //	{
            //		List<int> position = new List<int>();
            //		for(int j=0; j<321; j+=35)
            //		{
            //			position.Add(j+i);
            //		}
            //		Position.Add(position);
            //	}
            //}

            //2017/11/29 羿均 修改 已將讀卡解析設定儲存到list table，透過config讀取設定
            static K12.Data.Configuration.ConfigData _LeaveCardSetting = K12.Data.School.Configuration["LeaveCardSetting"];
            static XDocument LeaveCardSetting = XDocument.Parse(_LeaveCardSetting.PreviousData.InnerXml);
            //static XDocument LeaveCardSetting = XDocument.Parse(LeaveReadCard.Properties.Resources.LeaveCardSetting);
            List<XElement> studentNumberPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("StudentNumber").Elements("Position").ToList();

			public override bool Validate()
			{
                //List<int> mark_count = Enumerable.Repeat(0, 6).ToList();
                //List<int> mark_no = Enumerable.Repeat(0, 6).ToList();
                //for (int j = 0; j < 6; j++)
                //{
                //	for (int i = 0; i < this.Position.ElementAt(j).Count(); i++)
                //	{
                //		if (this.Source.ElementAt(this.Position.ElementAt(j).ElementAt(i)) >= this.Level)
                //		{
                //			mark_count[j] += 1;
                //			mark_no[j] = i;
                //		}
                //	}
                //}

                int mark_count = 0;
                string mark_no = "";

                foreach (XElement position in studentNumberPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        mark_count += 1;
                        mark_no += position.Attribute("Value").Value;
                    }
                }
                
				if (mark_count == 6)
				{
					this.Message.Element("Success").Add(new XElement("StudentNumber", string.Join("", mark_no)));

					return base.Validate();
				}
				else
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「學號」畫記錯誤。"));

					return false & base.Validate();
				}
			}
		}
		
		private sealed class LeaveAttendanceTypeParser : Decorator
		{
            //	節次對照
            //private readonly string[] TypeMappings = new string[] { "事", "病", "第一節", "第二節", "第三節", "第四節", "午休", "第五節", "第六節", "第七節", "第八節", "第九節"}; 
            //	請假卡「假別」之畫記的絕對位置
            //private readonly List<int> Position = new List<int> { 7, 77, 147, 217, 287 };

            //2017/11/29 羿均 修改 已將讀卡解析設定儲存到list table，透過config讀取設定
            static K12.Data.Configuration.ConfigData _LeaveCardSetting = K12.Data.School.Configuration["LeaveCardSetting"];
            static XDocument LeaveCardSetting = XDocument.Parse(_LeaveCardSetting.PreviousData.InnerXml);

            //static XDocument LeaveCardSetting = XDocument.Parse(LeaveReadCard.Properties.Resources.LeaveCardSetting);
            List<XElement> absenceTypePositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceType").Elements("Position").ToList();

            public override bool Validate()
			{
				int mark_count = 0;
				string mark_no = "";
                //for (int j = 0; j < 5; j++)
                //{
                //	if (this.Source.ElementAt(this.Position.ElementAt(j)) >= this.Level)
                //	{
                //		mark_count += 1;
                //		mark_no = j;
                //	}
                //}

                foreach (XElement position in absenceTypePositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        mark_count += 1;
                        mark_no = position.Attribute("Value").Value;
                    }
                }

				if (mark_count == 1)
				{
                    //this.Message.Element("Success").Add(new XElement("AttendanceType", TypeMappings[mark_no]));
                    //this.Message.Element("Success").Add(new XElement("AttendanceType", Program.LeaveNameList[mark_no]));

                    this.Message.Element("Success").Add(new XElement("AttendanceType", mark_no));

                    return base.Validate();
				}
				else
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「假別」畫記錯誤。"));

					return false & base.Validate();
				}
			}
		}

        private sealed class LeaveRangeParser : Decorator
        {
            //2017/11/29 羿均 修改 已將讀卡解析設定儲存到list table，透過config讀取設定
            static K12.Data.Configuration.ConfigData _LeaveCardSetting = K12.Data.School.Configuration["LeaveCardSetting"];
            static XDocument LeaveCardSetting = XDocument.Parse(_LeaveCardSetting.PreviousData.InnerXml);

            // 2017/11/27，羿均，讀取xml起始年設定
            //static XDocument LeaveCardSetting = XDocument.Parse(LeaveReadCard.Properties.Resources.LeaveCardSetting);
            static XElement starYear = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarYear").Elements("Position").First();
            int _starYear = int.Parse(starYear.Attribute("Value").Value);

            //2016/8/31  穎驊 新增動態依據讀卡上的起始年，使用者可以調整設定
            //ConfigData Config { get; set; }

            //	請假卡「請假日期--年(自)」之畫記的絕對位置
            List<XElement> starYearPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarYear").Elements("Position").ToList();
			//private readonly List<int> BeginYearPosition = new List<int> { 9, 44, 79, 114, 149, 184, 219, 254, 289, 324, 359, 394 };

            //	請假卡「請假日期--月(自)」之畫記的絕對位置
            List<XElement> starMonthPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarMonth").Elements("Position").ToList();
			//private readonly List<int> BeginMonthPosition = new List<int> { 10, 45, 80, 115, 150, 185, 220, 255, 290, 325, 360, 395 };

            //	請假卡「請假日期--日(自)」之畫記的絕對位置
            List<XElement> starDayPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarDay").Elements("Position").ToList();
			//private readonly List<int> BeginDayPosition = new List<int> 
			//{ 
			//	11, 46, 81, 116, 151, 186, 221, 256, 291, 326,
			//    12, 47, 82, 117, 152, 187, 222, 257, 292, 327,
			//	13, 48, 83, 118, 153, 188, 223, 258, 293, 328, 363
			//};

            //	請假卡「請假日期--年(至)」之畫記的絕對位置
            List<XElement> endYearPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("EndYear").Elements("Position").ToList();
			//private readonly List<int> EndYearPosition = new List<int> { 15, 50, 85, 120, 155, 190, 225, 260, 295, 330, 365, 400 };

            //	請假卡「請假日期--月(至)」之畫記的絕對位置
            List<XElement> endMonthPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("EndMonth").Elements("Position").ToList();
			//private readonly List<int> EndMonthPosition = new List<int> { 16, 51, 86, 121, 156, 191, 226, 261, 296, 331, 366, 401 };

            //	請假卡「請假日期--日(至)」之畫記的絕對位置
            List<XElement> endDayPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("EndDay").Elements("Position").ToList();
			//private readonly List<int> EndDayPosition = new List<int> 
			//{ 
			//	17, 52, 87, 122, 157, 192, 227, 262, 297, 332, 
			//	18, 53, 88, 123, 158, 193, 228, 263, 298, 333, 
			//	19, 54, 89, 124, 159, 194, 229, 264, 299, 334, 369
			//};

            //	請假卡「請假日期--節(自)」之畫記的絕對位置
            List<XElement> starPeriodPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("StarPeriod").Elements("Position").ToList();
			//private readonly List<int> BeginPeriodPosition = new List<int> { 14, 49, 84, 119, 154, 189, 224, 259, 294, 329, 364, 399 };

            //	請假卡「請假日期--節(至)」之畫記的絕對位置
            List<XElement> endPeriodPositionList = LeaveCardSetting.Element("LeaveCardSetting").Element("AbsenceDate").Element("EndPeriod").Elements("Position").ToList();
			//private readonly List<int> EndPeriodPosition = new List<int> { 20, 55, 90, 125, 160, 195, 230, 265, 300, 335, 370, 405 };

			public override bool Validate()
			{
				int begin_year_mark_count = 0;
				int begin_year_mark_no = 0;
				int begin_month_mark_count = 0;
				int begin_month_mark_no = 0;
				int begin_day_mark_count = 0;
				int begin_day_mark_no = 0;
				int begin_period_mark_count = 0;
				List<string> begin_period_mark_no = new List<string>();

				int end_year_mark_count = 0;
				int end_year_mark_no = 0;
				int end_month_mark_count = 0;
				int end_month_mark_no = 0;
				int end_day_mark_count = 0;
				int end_day_mark_no = 0;
				int end_period_mark_count = 0;
				List<string> end_period_mark_no = new List<string>();

				bool result = true;
                // 讀卡--(自)年
                foreach (XElement position in starYearPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        begin_year_mark_count += 1;
                        begin_year_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(自)月
                foreach (XElement position in starMonthPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        begin_month_mark_count += 1;
                        begin_month_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(至)年
                foreach (XElement position in endYearPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        end_year_mark_count += 1;
                        end_year_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(至)月
                foreach (XElement position in endMonthPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        end_month_mark_count += 1;
                        end_month_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(自)節 
                foreach (XElement position in starPeriodPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        begin_period_mark_count += 1;
                        begin_period_mark_no.Add(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(至)節
                foreach (XElement position in endPeriodPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        end_period_mark_count += 1;
                        end_period_mark_no.Add(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(自)日
                foreach (XElement position in starDayPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        begin_day_mark_count += 1;
                        begin_day_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }
                // 讀卡--(至)日
                foreach (XElement position in endDayPositionList)
                {
                    int index = int.Parse(position.Attribute("Row").Value) * 35 + int.Parse(position.Attribute("Col").Value);

                    if (this.Source.ElementAt(index) >= this.Level)
                    {
                        end_day_mark_count += 1;
                        end_day_mark_no = int.Parse(position.Attribute("Value").Value);
                    }
                }

                //for (int i = 0; i < 12; i++)
                //{
                //	//	請假日期--年(自)
                //	if (this.Source.ElementAt(this.BeginYearPosition.ElementAt(i)) >= this.Level)
                //	{

                //                    begin_year_mark_count += 1;
                //                    begin_year_mark_no = _starYear + i;
                //                    //2016/8/31  穎驊 新增動態依據讀卡上的起始年，使用者可以調整設定，目前有104年、105年 可以在"設定"中改變
                //                    //Config = Campus.Configuration.Config.App["學生出缺席讀卡設定"];

                //                    //begin_year_mark_no = Program.StartYear + i;
                //                    //begin_year_mark_no = int.Parse(Config["讀卡起始年--請假卡"])+i;
                //                }
                //	//	請假日期--月(自)
                //	if (this.Source.ElementAt(this.BeginMonthPosition.ElementAt(i)) >= this.Level)
                //	{
                //		begin_month_mark_count += 1;
                //		begin_month_mark_no = 1 + i;
                //	}
                //	//	請假日期--年(至)
                //	if (this.Source.ElementAt(this.EndYearPosition.ElementAt(i)) >= this.Level)
                //	{

                //                    end_year_mark_count += 1;
                //                    end_year_mark_no = _starYear + i;
                //                    //2016/8/31  穎驊 新增動態依據讀卡上的起始年，使用者可以調整設定，目前有104年、105年 可以在"設定"中改變
                //                    //Config = Campus.Configuration.Config.App["學生出缺席讀卡設定"];

                //                    //end_year_mark_no = Program.StartYear + i;
                //                    // end_year_mark_no = int.Parse(Config["讀卡起始年--請假卡"]) + i;
                //                }
                //	//	請假日期--月(至)
                //	if (this.Source.ElementAt(this.EndMonthPosition.ElementAt(i)) >= this.Level)
                //	{
                //		end_month_mark_count += 1;
                //		end_month_mark_no = 1 + i;
                //	}
                //}
                //for (int i = 0; i <= 11; i++)
                //{
                //	//	請假日期--節(自)
                //	if (this.Source.ElementAt(this.BeginPeriodPosition.ElementAt(i)) >= this.Level)
                //	{
                //		begin_period_mark_count += 1;
                //		begin_period_mark_no.Add(i);
                //	}
                //	//	請假日期--節(至)
                //	if (this.Source.ElementAt(this.EndPeriodPosition.ElementAt(i)) >= this.Level)
                //	{
                //		end_period_mark_count += 1;
                //		end_period_mark_no.Add(i);
                //	}
                //}
                //            for (int i = 0; i < 31; i++)
                //{
                //	//	請假日期--日(自)
                //	if (this.Source.ElementAt(this.BeginDayPosition.ElementAt(i)) >= this.Level)
                //	{
                //		begin_day_mark_count += 1;
                //		begin_day_mark_no = i+1;
                //	}
                //	//	請假日期--日(至)
                //	if (this.Source.ElementAt(this.EndDayPosition.ElementAt(i)) >= this.Level)
                //	{
                //		end_day_mark_count += 1;
                //		end_day_mark_no = i+1;
                //	}
                //}

                if (begin_year_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--年(自)」畫記錯誤。"));
					result = false;
				}
				if (end_year_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--年(至)」畫記錯誤。"));
					result = false;
				}
				if (begin_month_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--月(自)」畫記錯誤。"));
					result = false;
				}
				if (end_month_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--月(至)」畫記錯誤。"));
					result = false;
				}
				if (begin_day_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--日(自)」畫記錯誤。"));
					result = false;
				}
				if (end_day_mark_count > 1)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--日(至)」畫記錯誤。"));
					result = false;
				}
				if ((begin_year_mark_count + end_year_mark_count) == 0)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--年」畫記錯誤。"));
					result = false;
				}
				if ((begin_month_mark_count + end_month_mark_count) == 0)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--月」畫記錯誤。"));
					result = false;
				}
				if ((begin_day_mark_count + end_day_mark_count) == 0)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--日」畫記錯誤。"));
					result = false;
				}
				if ((begin_year_mark_count + begin_month_mark_count + begin_day_mark_count) > 0)
				{
					if (begin_period_mark_count == 0)
					{
						this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--節(自)」畫記錯誤。"));
						result = false;
					}
					DateTime begin_date;
					if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", begin_year_mark_no + 1911, begin_month_mark_no, begin_day_mark_no), out begin_date))
					{
						this.Message.Element("Failure").Add(new XElement("Message", "「請假日期(自)」畫記錯誤。"));
						result = false;
					}
				}
				if ((end_year_mark_count + end_month_mark_count + end_day_mark_count) > 0)
				{
					if (end_period_mark_count == 0)
					{
						this.Message.Element("Failure").Add(new XElement("Message", "「請假日期--節(至)」畫記錯誤。"));
						result = false;
					}
					DateTime end_date;
					if (!DateTime.TryParse(string.Format("{0}/{1}/{2}", end_year_mark_no + 1911, end_month_mark_no, end_day_mark_no), out end_date))
					{
						this.Message.Element("Failure").Add(new XElement("Message", "「請假日期(至)」畫記錯誤。"));
						result = false;
					}
				}
				//	請假日期只允許「只填自、只填至、都填」
				int total_count = begin_year_mark_count + end_year_mark_count + begin_month_mark_count + end_month_mark_count + begin_day_mark_count + end_day_mark_count;
				if (total_count != 3 && total_count != 6)
				{
					this.Message.Element("Failure").Add(new XElement("Message", "「請假日期」畫記錯誤。"));
					result = false;
				}
				if (result)
				{
					DateTime begin_date = DateTime.Now;
					DateTime end_date = DateTime.Now;

					if (DateTime.TryParse(string.Format("{0}/{1}/{2}", begin_year_mark_no + 1911, begin_month_mark_no, begin_day_mark_no), out begin_date))
					{
						XElement Discipline = new XElement("Discipline", new XAttribute("SeatNo", ""), new XAttribute("DateTime", ""));
						this.Message.Element("Success").Add(Discipline);
						Discipline.Attribute("DateTime").SetValue(begin_date.ToShortDateString());
                        // 2017/11/8 羿均，因為xml已經定義好每個點的位置以及資料所以 將舊有的mapping作法改寫。
                        foreach (string _period in begin_period_mark_no)
						{
							XElement Period = new XElement("Period", new XAttribute("Name", "" + _period));
                            //XElement Period = new XElement("Period", new XAttribute("Name", PeriodMappings[i]));
                            Discipline.Add(Period);

							//Period.Add(new XElement("Reason", "假"));
						}
					}
					if (DateTime.TryParse(string.Format("{0}/{1}/{2}", end_year_mark_no + 1911, end_month_mark_no, end_day_mark_no), out end_date))
					{
						XElement Discipline = new XElement("Discipline", new XAttribute("SeatNo", ""), new XAttribute("DateTime", ""));
						this.Message.Element("Success").Add(Discipline);
						Discipline.Attribute("DateTime").SetValue(end_date.ToShortDateString());
                        // 2017/11/8 羿均，因為xml已經定義好每個點的位置以及資料所以 將舊有的mapping作法改寫。
                        foreach (string _period in end_period_mark_no)
						{
                            XElement Period = new XElement("Period", new XAttribute("Name", _period));
                            //XElement Period = new XElement("Period", new XAttribute("Name", PeriodMappings[i]));
                            Discipline.Add(Period);

							//Period.Add(new XElement("Reason", "假"));
						}
					}
				}

				return result & base.Validate();
			}
		}
		
		private static readonly WVSOMRParser instance = new WVSOMRParser();
		
		public static WVSOMRParser Instance { get { return instance; } }

		/// <summary>
		/// 解析請假卡片資料。
		/// </summary>
		/// <param name="source">資料來源</param>
		/// <param name="level">畫卡濃度,預設為3。</param>
		/// <returns></returns>
		public XElement LeaveParser(byte[] source, int level, int source_length)
		{
			if (source.Length != source_length)
				throw new ArgumentException("卡片格式不正確，請確認卡片為「請假卡」。");

			iParser Parser = new ConcreteParser();	
			
			//	學號
			Decorator Decorator = new LeaveStudentNumberParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	假別
			Decorator = new LeaveAttendanceTypeParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;
			//	請假日期
			Decorator = new LeaveRangeParser();
			Decorator.SetParser(Parser);
			Decorator.SetParams(source, level);
			Parser = Decorator;

			bool result1 = Parser.Validate();
			XElement Element = Parser.GetMessage();

			return Element;
		}

		//<Failure>
		//	<Message>「點名日期--日」畫記錯誤。</Message>
		//	<Message>「點名日期--月」畫記錯誤。</Message>
		//	<Message>「點名日期--年」畫記錯誤。</Message>
		//	<Message>「班級」畫記錯誤。</Message>
		//	<Message>「年級」畫記錯誤。</Message>
		//</Failure>
		public bool IsValidated(XElement disciplineContent, out XElement errorMessages)
		{
			errorMessages = new XElement("Messages");
			XElement em = errorMessages;

			em.Add(disciplineContent.Element("Failure").Nodes());

			return em.Elements("Message").Count() <= 0;
		}
    }
}
