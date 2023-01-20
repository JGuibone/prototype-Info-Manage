using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace prototype_Info_Manage
{
	internal class Dashboard_data
	{
		private static readonly Regex _regex = new Regex("[^0-9]+");

		
		public string ID_barcode { get; set; }
		public string? ID_course { get; set; }
		public string? FirstName { get ; set; }
		public string? MiddleName { get; set; }
		public string? LastName { get; set;}
		public string Age { get; set; }
		public string StudentCell { get; set; }
		public string? StuPGname { get; set;}
		public string StuPGCell { get; set; }

		public bool CheckValue()
		{
			if (_regex.IsMatch(ID_barcode) | (_regex.IsMatch(Age) && Age.Length < 3) | _regex.IsMatch(StudentCell) | _regex.IsMatch(StuPGCell))
			{
				return false;
			}
			else return true;
		}
	}
}
