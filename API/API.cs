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
			  .AddFile("apiStyle.css", "wwwroot/css/apiStyle.css")
			  //.AddFile("document", _resourceLocation + "document.pdf")		// possable usage for pdf, leave this commented for now
			  .AddFile("character.html", _resourceLocation + character.Name + ".html")
			  .AddParameter("instructions", new System.Text.Json.Nodes.JsonObject
			  {
				  ["parts"] = new System.Text.Json.Nodes.JsonArray
				{
					new System.Text.Json.Nodes.JsonObject
					{
						["html"] = "character.html",
						["assets"] = new System.Text.Json.Nodes.JsonArray
						{
							"style.css"
						}
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


			// the lines will have to be different <p></p> each so they can start on a new line
			string skills = "";
			for (int i = 0; i > character.CharacterSkills.Count; i++)
			{
				skills += "<p class= \"font6\">"+character.CharacterSkills[i].SkillName + " - " + character.CharacterSkills[i].SkillDescription + "</p>\r";
			}
			for (int i = 0; i > character.TempSkills.Count; i++)
			{
				if (i == 0) skills += "<p class= \"font6\"> TempSkills </p>";
				skills += "<p class= \"font6\">" + character.TempSkills[i].SkillName + " - " + character.CharacterSkills[i].SkillDescription + "</p>\r";
			}
			string qualities = "";
			for (int i = 0; i > character.CharacterSkills.Count; i++)
			{
				skills += character.Quality.QualityName + "\r";
			}


			string htmlString = "<!DOCTYPE html>\r\n<html class=\"bg\">\r\n<head>\r\n<link rel=\"stylesheet\" href=\"style.css\" />\r\n<meta charset=\"utf-8\" />\r\n" +
				"<title></title>\r\n</head>\r\n<body class=\"bodySpace\">\r\n<div class=\"bodySpace\">\r\n<div class=\"inline topSpace\">\r\n<div class=\"inline\">\r\n" +
				"<div class=\"nameBox inline\">\r\n<div>\r\n<p class=\"inline nameText\">Name: </p>\r\n<p type=\"text\" class=\"inline borderLow bg font6\">" + character.Name + "</p>\r\n" +
				"</div>\r\n</div>\r\n<div class=\"ageBox inline\">\r\n<div>\r\n<p class=\"inline nameText\">Age:</p>\r\n<p type=\"number\" class=\"inline noBorder borderLow bg ageInput font6\">" + character.Age + "</p>\r\n" +
				"</div>\r\n</div>\r\n<div class=\"genderBox inline\">\r\n<div>\r\n<p class=\"inline nameText\">Gender: </p>\r\n<p type=\"text\" class=\"inline noBorder borderLow bg genderInput font6\"> " + character.Gender + "</p>\r\n" +
				"</div>\r\n</div>\r\n</div>\r\n</div>\r\n<br />\r\n<div class=\"inline marginL20\">\r\n<div class=\"inline marginL20\">\r\n<div class=\"initBox\">\r\n" +
				"<div style=\"height: 30px;\">\r\n<p class=\"borderLow boxText\">Initiative</p>\r\n</div>\r\n<div class=\"borderLow marginL5\">\r\n<p class=\"inline\">1.</p>\r\n" +
				"<input class=\"inline bg initInput\" />\r\n</div>\r\n<div class=\"borderLow marginL5\">\r\n<p class=\"inline\">2.</p>\r\n<input class=\"inline bg initInput\" />\r\n" +
				"</div>\r\n<div class=\"borderLow marginL5\">\r\n<p class=\"inline\">3.</p>\r\n<input class=\"inline bg initInput\" />\r\n</div>\r\n<div class=\"borderLow marginL5\">\r\n" +
				"<p class=\"inline\">3.</p>\r\n<input class=\"inline bg initInput\" />\r\n</div>\r\n</div>\r\n<div class=\"equipmintBox\">\r\n<p class=\"centerText height30 borderLow\">Equipment</p>\r\n" +
				"<p></p>\r\n</div>\r\n<span class=\"inline\">\r\n</span>\r\n</div>\r\n<div class=\"inline marginL20\">\r\n<div class=\"initBox\">\r\n<p class=\"borderLow boxText\">Filler</p>\r\n" +
				"</div>\r\n<div class=\"equipmintBox\">\r\n<p class=\"centerText height30 borderLow\">Weapons</p>\r\n<p></p>\r\n</div>\r\n<span class=\"inline\"></span>\r\n</div>\r\n" +
				"<div class=\"inline\">\r\n<div class=\"skillBox marginL20\">\r\n<p class=\"centerText height30 borderLow\">Skill</p>\r\n" + skills + 
				"</div>\r\n<br />\r\n</div>\r\n</div>\r\n<br />\r\n<div class=\"marginL20\">\r\n<div class=\"marginL20 grid\">\r\n<div class=\"inventoryBox item1\">\r\n" +
				"<p class=\"centerText height30 borderLow\">Notes</p>\r\n<p class=\"font6\"> Notes: </p>\r\n<p></p>\r\n</div>\r\n<div class=\"qualitiesBox\">\r\n<p class=\"centerText height30 borderLow\">Qualities</p>\r\n" + qualities +
				" \r\n</div>\r\n</div>\r\n</div>\r\n<br />\r\n<div>\r\n<div class=\"backStoryBox\">\r\n<p class=\"centerText height30 borderLow\">Backstory</p>\r\n" +
				"<p class=\"font6\">" + character.Backstory + "</p>\r\n</div>\r\n</div>\r\n<br />\r\n</div>\r\n</body>\r\n</html>";

			File.WriteAllText( _resourceLocation + "character.html", htmlString);
		}


	}
}
