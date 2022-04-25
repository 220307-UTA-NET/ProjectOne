using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Net.Mime;


namespace StoreOrderApp
{

	public class IO
	{
		//I'm pretty sure this is needed?
		private readonly Uri uri;
		public IO(Uri uri)
		{
			this.uri = uri;
		}
		// https://dcshippingtostorestry6.azurewebsites.net
	}

	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			TextBox[] DCtextBoxes = new TextBox[20] { DCInventory1, DCInventory2, DCInventory3, DCInventory4, DCInventory5, DCInventory6, DCInventory7, DCInventory8, DCInventory9, DCInventory10, DCInventory11, DCInventory12, DCInventory13, DCInventory14, DCInventory15, DCInventory16, DCInventory17, DCInventory18, DCInventory19, DCInventory20 };
			TextBox[] dcqtyBoxes = new TextBox[20] { DCQuantity1, DCQuantity2, DCQuantity3, DCQuantity4, DCQuantity5, DCQuantity6, DCQuantity7, DCQuantity8, DCQuantity9, DCQuantity10, DCQuantity11, DCQuantity12, DCQuantity13, DCQuantity14, DCQuantity15, DCQuantity16, DCQuantity17, DCQuantity18, DCQuantity19, DCQuantity20 };
			for (int i = 0; i < 20; i++)
			{
				//MessageBox.Show("Setting Text.");
				DCtextBoxes[i].IsReadOnly = true;
				dcqtyBoxes[i].Text = "";
			}
			//Main(DCtextBoxes);
		}

		async void OnLoad(object sender, RoutedEventArgs e)
		{
			TextBox[] DCtextBoxes = new TextBox[20] { DCInventory1, DCInventory2, DCInventory3, DCInventory4, DCInventory5, DCInventory6, DCInventory7, DCInventory8, DCInventory9, DCInventory10, DCInventory11, DCInventory12, DCInventory13, DCInventory14, DCInventory15, DCInventory16, DCInventory17, DCInventory18, DCInventory19, DCInventory20 };
			string[,] allInfo = new string[9, 20];
			allInfo = await loadData(DCtextBoxes);
			//MessageBox.Show("Errors:\n " + errors);
			//MessageBox.Show("Order entered. Inventories adjusted.\n ");
			Uri uri = new Uri("https://localhost:49157/");
			IO io = new IO(uri);
		}
		public static async Task<string[,]> loadData(TextBox[] info)
		{

			//MessageBox.Show("Reading.");
			string connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			string[,] temp = new string[9, 20];
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			for (int k = 0; k < 20; k++)
			{
				int l = k + 1;
				using SqlCommand cmd = new SqlCommand(
						"SELECT * FROM ShopData.Inventory " +
						"WHERE Item_ID = " + l, connection);
				using SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					//MessageBox.Show(reader.GetInt32(0).ToString());
					temp[0, k] = reader.GetInt32(0).ToString();
					temp[1, k] = reader.GetString(1);
					temp[2, k] = reader.GetString(2);
					temp[3, k] = reader.GetInt32(3).ToString();
					temp[4, k] = reader.GetInt32(4).ToString();
					temp[5, k] = reader.GetInt32(5).ToString();
					temp[6, k] = reader.GetInt32(6).ToString();
					temp[7, k] = reader.GetInt32(7).ToString();
					temp[8, k] = reader.GetSqlMoney(8).ToString();

				}
			}
			for (int i = 0; i < 20; i++)
			{
				string itemInfo = (temp[1, i].ToString() + " | " + temp[2, i].ToString() + " | " + temp[3, i] + " | $" + temp[8, i]);
				info[i].Text = itemInfo;
			}
			connection.Close();
			return temp;
		}
		public readonly Uri uri;
		public static readonly HttpClient httpClient = new HttpClient();


		private async void PlaceOrderButtonClick(object sender, RoutedEventArgs e)
		{
			TextBox[] dcqtyBoxes = new TextBox[20] { DCQuantity1, DCQuantity2, DCQuantity3, DCQuantity4, DCQuantity5, DCQuantity6, DCQuantity7, DCQuantity8, DCQuantity9, DCQuantity10, DCQuantity11, DCQuantity12, DCQuantity13, DCQuantity14, DCQuantity15, DCQuantity16, DCQuantity17, DCQuantity18, DCQuantity19, DCQuantity20 };
			TextBox[] DCtextBoxes = new TextBox[20] { DCInventory1, DCInventory2, DCInventory3, DCInventory4, DCInventory5, DCInventory6, DCInventory7, DCInventory8, DCInventory9, DCInventory10, DCInventory11, DCInventory12, DCInventory13, DCInventory14, DCInventory15, DCInventory16, DCInventory17, DCInventory18, DCInventory19, DCInventory20 };
			string store = StoreSendSelector.Text;
			string errors = "";
			int errorCount = 0;
			int storeNum = 0;
			string[,] allInfo = new string[9, 20];
			allInfo = await readInfo();
			//to update this to API, I'll keep it simple.  This end will send store nums and quantity nums in each box to the API, and the API will do everything else then send a 'all done' message.
			if (!String.IsNullOrEmpty(store))
			{
				if (store == "147th St (New York)")
				{
					storeNum = 4;
				}
				else if (store == "Delancy St AKA Canal St (New York)")
				{
					storeNum = 5;
				}
				else if (store == "95th St (New York)")
				{
					storeNum = 6;
				}
				else if (store == "Cicero Ave (Chicago)")
				{
					storeNum = 7;
				}
				else
				{
					errors += "Something went wrong, invalid store somehow selected.\n";
					errorCount++;
				}
			}
			else
			{
				errors += "You must choose a store to send from\n";
				errorCount++;
			}
			int errorCount2 = 0;
			for (int i = 0; i < 20; i++)
			{
				int quantity;
				if (!String.IsNullOrEmpty(dcqtyBoxes[i].Text))
				{
					if (!int.TryParse(dcqtyBoxes[i].Text, out quantity)) //check for valid quantities
					{
						int j = i + 1;
						errors += "Invalid quantity for item: " + j + "\n";
						errorCount++;
					}
					else
					{
						quantity = int.Parse(dcqtyBoxes[i].Text);
						int dcQuantity = int.Parse(allInfo[3, i]);
						int j = i + 1;
						if (quantity > dcQuantity)
						{
							errors += "Quantiy for item: " + j + " exceeds DC quantity.\n";
							errorCount++;
						}
					}

				}
				else
				{
					errorCount2++;
				}
			}
			if (errorCount2 == 20)
			{
				errorCount++;
				errors += "You must order something.";
			}
			if (errorCount == 0)
			{
				List<int> sending = new List<int>();
				sending.Add(storeNum);
				int zero = 0;
				for (int i = 0; i < 20; i++)
				{
					if (!String.IsNullOrEmpty(dcqtyBoxes[i].Text))
					{
						sending.Add(int.Parse(dcqtyBoxes[i].Text));
					}
					else 
					{
						sending.Add(zero);
					}

				}
				//call API here
				//This is where the 'magic' needs to happen please.
				//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "/transfer");
				string url = "https://dcshippingtostorestry6.azurewebsites.net/api/transfer";
				HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
				request.Headers.Accept.Add(new(MediaTypeNames.Application.Json));

				using (HttpResponseMessage response = await httpClient.SendAsync(request))
				{
					//url = "https://dcshippingtostorestry6.azurewebsites.net/api/transfer";
					string message = (String.Join(".", sending));
					var data = new System.Net.Http.StringContent(message);
					HttpClient client = new HttpClient();
					bool answer = false;
					if (response.IsSuccessStatusCode)
					{
						//answer = Convert.ToBoolean(client.GetStringAsync(url));
						
						client.PostAsync(url, data);
						//answer = Convert.ToBoolean(response.Content.ReadAsStringAsync());
						answer = true;
					}
					MessageBox.Show(response.ToString());
					//send list to file, get back bool
					//post message
					//MessageBox.Show(String.Join(".", sending));
					if (answer == true)
					{
						MessageBox.Show("Order placed");
					}
					else 
					{
						MessageBox.Show("Something went wrong");
					}

					allInfo = await updateInfo(DCtextBoxes);
				}
			}
			else 
			{
				MessageBox.Show(errors);
			}
		}
		public static async Task<string[,]> readInfo()
		{
			string connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			string[,] temp = new string[9, 20];
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			for (int k = 0; k < 20; k++)
			{
				int l = k + 1;
				using SqlCommand cmd = new SqlCommand(
						"SELECT * FROM ShopData.Inventory " +
						"WHERE Item_ID = " + l, connection);
				using SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					//MessageBox.Show(reader.GetInt32(0).ToString());
					temp[0, k] = reader.GetInt32(0).ToString();
					temp[1, k] = reader.GetString(1);
					temp[2, k] = reader.GetString(2);
					temp[3, k] = reader.GetInt32(3).ToString();
					temp[4, k] = reader.GetInt32(4).ToString();
					temp[5, k] = reader.GetInt32(5).ToString();
					temp[6, k] = reader.GetInt32(6).ToString();
					temp[7, k] = reader.GetInt32(7).ToString();
					temp[8, k] = reader.GetSqlMoney(8).ToString();

				}
			}
			return temp;
		}
		public static async void sendInfo(string [,] newInfo, List<int> newones, int store)
		{
			string connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			string updateMessage = "";
			int storeRef = store - 3;
			
			for (int i = 1; i <= 20; i++)
			{
				int j = i - 1;
				if (newones.Contains(i))
				{
					updateMessage += "UPDATE ShopData.Inventory SET ";
					updateMessage += "StoreQuantity0 = " + newInfo[3,j] + ", StoreQuantity" + storeRef + " = " + newInfo[store,j] + " WHERE Item_ID = " + i + ";";
				}
			}
			MessageBox.Show(updateMessage);

			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();
			using SqlCommand cmd = new SqlCommand(updateMessage , connection);
			cmd.ExecuteNonQuery();
			connection.Close();
		}
		public static async Task<string[,]> updateInfo(TextBox[] info)
		{

			//MessageBox.Show("Reading.");
			string connectionString = "Server=tcp:firsttryserver.database.windows.net,1433;Initial Catalog=FirstTryResourceGroupDatabase;Persist Security Info=False;User ID=Mechsrule1;Password=ed3MxmE23EKEsed;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
			string[,] temp = new string[9, 20];
			SqlConnection connection = new SqlConnection(connectionString);
			connection.Open();

			for (int k = 0; k < 20; k++)
			{
				int l = k + 1;
				using SqlCommand cmd = new SqlCommand(
						"SELECT * FROM ShopData.Inventory " +
						"WHERE Item_ID = " + l, connection);
				using SqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					//MessageBox.Show(reader.GetInt32(0).ToString());
					temp[0, k] = reader.GetInt32(0).ToString();
					temp[1, k] = reader.GetString(1);
					temp[2, k] = reader.GetString(2);
					temp[3, k] = reader.GetInt32(3).ToString();
					temp[4, k] = reader.GetInt32(4).ToString();
					temp[5, k] = reader.GetInt32(5).ToString();
					temp[6, k] = reader.GetInt32(6).ToString();
					temp[7, k] = reader.GetInt32(7).ToString();
					temp[8, k] = reader.GetSqlMoney(8).ToString();

				}
			}
			for (int i = 0; i < 20; i++)
			{
				string itemInfo = (temp[1, i].ToString() + " | " + temp[2, i].ToString() + " | " + temp[3, i] + " | $" + temp[8, i]);
				info[i].Text = itemInfo;
			}
			connection.Close();
			return temp;
		}


	}
}
