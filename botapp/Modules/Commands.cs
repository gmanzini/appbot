using Discord;
using Discord.Commands;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BOTapp.Modules
{

    [NamedArgumentType]
    public  class NamableArguments
    {
        public  string T { get; set; }
        public  string B { get; set; }
    }
    public class Commands : ModuleBase<SocketCommandContext>
    {
        [Command("img")]
        public async Task UploadImage (NamableArguments namedArgs)
        {


            string topclear = string.IsNullOrEmpty(namedArgs.T) ?  "  ":  RemoveAccents(namedArgs.T) ;
            string bottomclear = string.IsNullOrEmpty(namedArgs.B) ? "%20" : RemoveAccents(namedArgs.B);
            //GET de imagens de memes
            var client = new RestClient("https://ronreiter-meme-generator.p.rapidapi.com/images");
            var request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "56ed7b918bmsh736bb11a5f6f181p1c14d3jsn962f642280e5");
            IRestResponse response = client.Execute(request);
            List<string> imgs = JsonConvert.DeserializeObject<List<string>>(response.Content);
            var random = new Random();
            int imgRandom = random.Next(imgs.Count);
            string nomeImg = imgs[imgRandom];
            //POST no Discord
            var client2 = new RestClient("https://ronreiter-meme-generator.p.rapidapi.com/meme?font=Impact&meme="+nomeImg+"&top=" + topclear + "&bottom="+ bottomclear);
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com");
            request2.AddHeader("x-rapidapi-key", "56ed7b918bmsh736bb11a5f6f181p1c14d3jsn962f642280e5");
            IRestResponse response2 = client2.Execute(request);
            System.Drawing.Image imageIn = ConvertByteArrayToImage(response2.RawBytes);
            File.WriteAllBytes("C:\\Users\\Gabriel\\Pictures\\imgmeme\\img.jpg", response2.RawBytes);
            await Context.Channel.SendFileAsync("C:\\Users\\Gabriel\\Pictures\\imgmeme\\img.jpg");
            
        }
        [Command("help")]
        public async Task Help()
        {
            await Context.Channel.SendMessageAsync("=img t:\"insira aqui\" b:\"insira aqui\"");
        }
        public string RemoveAccents(string text)
        {
            StringBuilder sbReturn = new StringBuilder();
            var arrayText = text.Normalize(NormalizationForm.FormD).ToCharArray();
            foreach (char letter in arrayText)
            {
                if (CharUnicodeInfo.GetUnicodeCategory(letter) != UnicodeCategory.NonSpacingMark)
                    sbReturn.Append(letter);
            }
            return sbReturn.ToString();
        }

        public System.Drawing.Image ConvertByteArrayToImage(byte[] byteArrayIn)
        {
            using (MemoryStream ms = new MemoryStream(byteArrayIn))
            {
                return System.Drawing.Image.FromStream(ms);
            }
        }
    }
    
}
