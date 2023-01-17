using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MySql.Data.MySqlClient;

namespace prototype_Info_Manage
{
    class DBTest
    {
		private const string myConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=info_management;";
		MySqlConnection conn = new()
		{
			ConnectionString = myConnectionString
		};
		public List<string> ID_Check(string ID_barcode)
		{
			List<string> rowList = new List<string>();
			string queryString = $"SELECT test_Fname, test_Lname, test_course FROM test_table WHERE test_id = {ID_barcode};";
			conn.Open();
			MySqlCommand cmd = new(queryString, conn);
			MySqlDataReader rdr = cmd.ExecuteReader();
			if (rdr.HasRows)
			{
				//MessageBox.Show($"{rdr.FieldCount}");
				int numCount = rdr.FieldCount;
				while (rdr.Read())
				{
					for (int i = 0; i < numCount; i++)
					{
						rowList.Add(rdr.GetString(i));
					}
					
				}
				rdr.Close();
				conn.Close();
			}
			else
			{
				MessageBox.Show("No Student with that ID Number!");

			}
			return rowList;
		}
		string Previlages()
		{
			return string.Empty;
		}
	}
}
