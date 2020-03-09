namespace DI_Autofac_Test.Events
{
	public class SecondEvent : BaseEvent
	{
		public SecondEvent(MyObject myObject) { MyObject = myObject; }
		public MyObject MyObject { get; set; }
	}
}
