using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Media3D;
using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;

namespace prototype_Info_Manage
{
    class DBTest
    {
		private static readonly Regex _regex = new Regex("[^0-9]+");
		private const string myConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=info_management;";

		public List<string> ID_Check(string ID_barcode)
		{
			MySqlConnection conn = new()
			{
				ConnectionString = myConnectionString
			};
			List<string> rowList = new List<string>();
			string queryString = $"SELECT FirstName, LastName, ID_Course FROM id_information WHERE ID_BarCode = {ID_barcode};";
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
				
			}
			else
			{
				MessageBox.Show("No Student with that ID Number!");

			}
			conn.Close();
			return rowList;
		}
		public string[] Previlages(string Access_Perm)
		{
			MySqlConnection conn = new()
			{
				ConnectionString = myConnectionString
			};
			string[] previlages = new string[2];
			string queryString = $"SELECT FirstName, AccessLevel FROM access_privileges WHERE ID_BarCode = {Access_Perm};";
			conn.Open();
			MySqlCommand cmd = new(queryString, conn);
			MySqlDataReader rdr = cmd.ExecuteReader();
			if (rdr.HasRows)
			{
				
				//MessageBox.Show($"{rdr.FieldCount}");
				while (rdr.Read())
				{
					previlages[0] = rdr.GetString(0);
					previlages[1] = rdr.GetString(1);
				}
				conn.Close();
				rdr.Close();
			}
			else conn.Close();
			return previlages;
		}
		public bool NumOnly(string CheckInput)
		{
			return !_regex.IsMatch(CheckInput);
		}
		public void MySQLinsert(Dashboard_data data)
		{
			MySqlConnection conn = new()
			{
				ConnectionString = myConnectionString
			};
			try
			{
				string queryString = $"INSERT INTO `id_information` (`ID_BarCode`, `FirstName`, `MiddleName`, `LastName`, `Age`, `ID_CellContact`, `ID_EmergName`, `ID_EmergContact`) VALUES ('{data.ID_barcode}', '{data.FirstName}', '{data.MiddleName}', '{data.LastName}', '{data.Age}', '{data.StudentCell}', '{data.StuPGname}', '{data.StuPGCell}');";
				MySqlCommand comm = new MySqlCommand(queryString, conn);
				MySqlDataReader rdr;
				conn.Open();
				rdr = comm.ExecuteReader();
				MessageBox.Show("saving.");
				while (rdr.Read())
				{

				}
				conn.Close();
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}
		}
		//public Dashboard_data MySQLedit(string ID_Value)
		//{
		//	Dashboard_data DD = new Dashboard_data();
		//	string queryString = $"SELECT * FROM `id_information` WHERE ID_BarCode = {ID_Value};";
		//	conn.Open();
		//	MySqlCommand cmd = new(queryString, conn);
		//	MySqlDataReader rdr = cmd.ExecuteReader();
		//	if (rdr.HasRows)
		//	{
		//		//MessageBox.Show($"{rdr.FieldCount}");
		//		while (rdr.Read())
		//		{
		//			DD.ID_barcode = rdr.GetString(0);
		//			DD.ID_course= rdr.GetString(1);
		//			DD.FirstName = rdr.GetString(2);
		//			DD.MiddleName = rdr.GetString(3);
		//			DD.LastName = rdr.GetString(4);
		//			DD.Age = rdr.GetString(5);
		//			DD.StudentCell = rdr.GetString(6);
		//			DD.StuPGname= rdr.GetString(7);
		//			DD.StuPGCell= rdr.GetString(8);

		//		}
		//		rdr.Close();
				
		//	}
		//	else
		//	{
		//		MessageBox.Show("No Student with that ID Number!");

		//	}
		//	conn.Close();
		//	return DD;
		//}
		public bool MySQLdelete(string ID_Value)
		{
			//string queryString = $"DELETE FROM id_information WHERE `id_information`.`ID_BarCode` = {ID_Value}";
			//"FROM id_information WHERE `id_information`.`ID_BarCode` = 000000172381723";
			return false;
		}

		public List<string> GatePassage(string ID_Value)
		{
			List<string> gatepassage =	new List<string>();
			MySqlConnection conn = new()
			{
				ConnectionString = myConnectionString
			};
			string queryString = $"SELECT * FROM gate_passage WHERE ID_BarCode = {ID_Value} ORDER by Passage_tracker DESC LIMIT 0,1 ;";
			conn.Open();
			MySqlCommand cmd = new(queryString, conn);
			MySqlDataReader rdr = cmd.ExecuteReader();
			while (rdr.Read())
			{
				if (rdr.IsDBNull(3))
				{
					gatepassage.Add("true");
					gatepassage.Add(rdr.GetString(0));
					return gatepassage;
				}
				else
				{
					gatepassage.Add("false");
					gatepassage.Add(rdr.GetString(0));
					return gatepassage;
				}
			}
			conn.Close();
			return gatepassage;
		}
		public void GateUpdate(List<string> Value, string ID_Value)
		{

			MySqlConnection conn = new()
			{
				ConnectionString = myConnectionString
			};
			if (Value[0] == "true")
			{
				MessageBox.Show("TRUE");
				string queryString = $"UPDATE `gate_passage` SET `Passage_Exit` = current_timestamp() WHERE `gate_passage`.`Passage_tracker` = {Value[1]};";
				conn.Open();
				MySqlCommand cmd = new(queryString, conn);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{

				}
				conn.Close();

			}
			else
			{
				MessageBox.Show("False");
				string queryString = $"INSERT INTO `gate_passage` (`Passage_tracker`, `ID_BarCode`, `Passage_Entry`, `Passage_Exit`) VALUES (NULL, '{ID_Value}', current_timestamp(), NULL);";
				conn.Open();
				MySqlCommand cmd = new(queryString, conn);
				MySqlDataReader rdr = cmd.ExecuteReader();
				while (rdr.Read())
				{

				}
				conn.Close();
			}

		}
	}
}
