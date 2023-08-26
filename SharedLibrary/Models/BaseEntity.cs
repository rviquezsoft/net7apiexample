using System;
namespace SharedLibrary.Models
{
	public class BaseEntity
	{
		public int id { get; set; }
		public string descripcion { get; set; }
		public bool activo { get; set; }
		public DateTime fechaNacimiento { get; set; }
	}
}

