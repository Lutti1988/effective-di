using System;
using System.ComponentModel.DataAnnotations;

namespace DI_Autofac_Test
{
	public class MyObject
	{
		[StringLength(255)]
		public string Name { get; set; }

		[Key]
		public Guid ID { get; set; }
	}
}
