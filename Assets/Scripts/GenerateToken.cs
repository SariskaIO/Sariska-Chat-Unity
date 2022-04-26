using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.IO;
using System.Text;
using UnityEngine;

public class GenerateToken
{
    public static Token GetToken(string RoomName)
    {
        HttpWebRequest request;
        string data = "{\"apiKey\":\"27fd6f8080d512442a3694f461adb3986cda5ba39dbe368d75\"," +
				"\"user\":{\"id\":\"99266\"," +
				"\"name\":\"Dipak\"," +
				"\"email\":\"dipak.work.14@gmail.com\"," +
				"\"avatar\":\"null\"}}";
		byte[] dataBytes = Encoding.UTF8.GetBytes(data);
		Debug.Log("Creating request");
		request = (HttpWebRequest)(WebRequest.Create("https://api.sariska.io/api/v1/misc/generate-token"));
		Debug.Log(request);
		Debug.Log("Done Creating request");
		request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
		request.ContentLength = dataBytes.Length;
		request.ContentType = "application/json";
		request.Method = "POST";
		using (Stream requestBody = request.GetRequestStream())
		{
			requestBody.Write(dataBytes, 0, dataBytes.Length);
		}
		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		Debug.Log(response.StatusCode + "Response Code");
		StreamReader reader = new StreamReader(response.GetResponseStream());
		string json = reader.ReadToEnd();
		return JsonUtility.FromJson<Token>(json);
    }
}
