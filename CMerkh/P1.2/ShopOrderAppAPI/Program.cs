using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

[Route("api/[controller]")] //this goes on cliant.
[ApiController]

//HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri.ToString() + "Devices");
//request.Headers.Accept.Add(new(MediaTypeNames.Application.Json)); 
//This is making the request. The Accept.Add means it's ready for that. The next part awaits the response.
//frombody() decerialize json into list. 
public class Maincode
{
	async void Main()
	{
		

		string[,] allInfo = new string[9, 20];
		List<int> newInfo = new List<int>();

		allInfo = await ReadInfo();
		int storeNum = newInfo[0];
		//string[] newStoreQuantity = new string[20];
		//string[] newDCQuantity = new string[20];
		int[] quantityChange = new int[20];
		List<int> updatedItems = new List<int>();

		for (int i = 0; i < 20; i++)
		{
			quantityChange[i] = newInfo[(i+1)];
		}
		

			//do ordering.
			
			//string errorTracking = "";
			for (int i = 0; i < 20; i++)
			{
				int quantity = 0;
				int dcQuantity = 0;
				int storeQuantity = 0;
				int j = i + 1;
				if (quantityChange[i] != 0)
				{
					//MessageBox.Show("Starting amounts " + allQuantity[storeNum, i] + " in dc: " + allQuantity[0, i]);
					quantity = quantityChange[i];
					dcQuantity = int.Parse(allInfo[3, i]);
					storeQuantity = int.Parse(allInfo[storeNum, i]);
					storeQuantity = storeQuantity + quantity;
					dcQuantity = dcQuantity - quantity;
					allInfo[storeNum, i] = storeQuantity.ToString();
					allInfo[3, i] = dcQuantity.ToString();
					updatedItems.Add(j);
				}
			}
			
			sendInfo(allInfo, updatedItems, storeNum);

		//send notice
	}

	[HttpPost]
	public SomeAction(List<int> Integers)
	{
		// do some stuff
		if (success) return Ok(result);
		return ServerError("oopsie whoopsie");
	}
	public static async Task<string[,]> ReadInfo()
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
	public static async void sendInfo(string[,] newInfo, List<int> newones, int store)
	{
		string connectionString = "";
		string updateMessage = "";
		int storeRef = store - 3;

		for (int i = 1; i <= 20; i++)
		{
			int j = i - 1;
			if (newones.Contains(i))
			{
				updateMessage += "UPDATE ShopData.Inventory SET ";
				updateMessage += "StoreQuantity0 = " + newInfo[3, j] + ", StoreQuantity" + storeRef + " = " + newInfo[store, j] + " WHERE Item_ID = " + i + ";";
			}
		}
		//MessageBox.Show(updateMessage);

		SqlConnection connection = new SqlConnection(connectionString);
		connection.Open();
		using SqlCommand cmd = new SqlCommand(updateMessage, connection);
		cmd.ExecuteNonQuery();
		connection.Close();
	}

}

