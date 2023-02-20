using Microsoft.AspNetCore.Html;
using CharacterCreator.Models;
using RestSharp;
using System.Net;

namespace CharacterCreator.API
{
	public static class API
	{
		private static string _apiKey = "Bearer pdf_live_gptUUxkz5Su8CvVAS7B5bfbbeENrEOagRuPCbECgSP9";
		private static string _outputLocation = "wwwroot/APIFiles/APIOutput/";
		private static string _resourceLocation = "wwwroot/APIFiles/APIResource/";

		// change the string value to something that contains the info of character
		public static void runApiHtml (Character character, string filename)
		{
			//api call
			var client = new RestClient("https://api.pspdfkit.com/build");

			//create base html file
			createHTMLBase(character);

			// add file to phe pdf to use
			var request = new RestRequest(Method.POST)
			  .AddHeader("Authorization", _apiKey)
			  //.AddFile("document", _resourceLocation + "document.pdf")		// possable usage for pdf, leave this commented for now
			  .AddFile("sample.html", _resourceLocation + "sample.html")
			  .AddParameter("instructions", new System.Text.Json.Nodes.JsonObject
			  {
				  ["parts"] = new System.Text.Json.Nodes.JsonArray
				{
					new System.Text.Json.Nodes.JsonObject
					{
						["html"] = "sample.html"
					}
				}
			  }.ToString());

			request.AdvancedResponseWriter = (responseStream, response) =>
			{
				if (response.StatusCode == HttpStatusCode.OK)
				{
					using (responseStream)
					{
						using var outputFileWriter = File.OpenWrite(_outputLocation + filename + ".pdf");
						responseStream.CopyTo(outputFileWriter);
					}
				}
				else
				{
					var responseStreamReader = new StreamReader(responseStream);
					Console.Write(responseStreamReader.ReadToEnd());
				}
			};

			//
			client.Execute(request);
		}

		private static void createHTMLBase(Character character)
		{
			// once the charecter stats are finished and outline of final page is ready
			string htmlString = 
				"<h1>This a test page</h1>" +
				"<p>----------------------------------------------------------</p>" +
				"<p>subject to change</p><!DOCTYPE html>\r\n<html class=\"bg\">\r\n<head>\r\n    <meta charset=\"utf-8\" />\r\n    <title></title>\r\n    " +
				"<h3>" + character + "</h3>"
				;
			// do not run fuction. currenty making pdf template
			//File.WriteAllText( _resourceLocation + character.Name, htmlString);
		}


	}
}
