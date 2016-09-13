using System.Xml.Linq;

namespace LeaveReadCard
{
	public abstract class iParser
	{
		protected XElement Message;
		public abstract bool Validate();
		public abstract XElement GetMessage(XElement Element=null);
	}
}
