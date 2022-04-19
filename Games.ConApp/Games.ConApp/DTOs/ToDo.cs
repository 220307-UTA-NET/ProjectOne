using System;
using Games.ConApp;

namespace Games.ConApp.DTOs
{

	//DTO ( Data Transfer Objects)
	// values of an object


	public class ToDo
	{
		// Fields
		public int userId { get; set; }
		public int id { get; set; }
		public string title { get; set; }
		public bool completed { get; set; }
	}
}

