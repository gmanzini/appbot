using BOTapp.Model;
using Discord;
using Discord.Audio;
using Discord.Commands;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;


namespace BOTapp.Modules
{




    [NamedArgumentType]
    public class NamableArguments
    {
        public string T { get; set; }
        public string B { get; set; }
    }
    public class Commands : ModuleBase<SocketCommandContext>
    {

        private readonly AudioService _service;

        // Remember to add an instance of the AudioService
        // to your IServiceCollection when you initialize your bot

        public Commands(AudioService service)
        {
            _service = service;
        }
        public static List<KeyValuePair<string, string>> Participants = new List<KeyValuePair<string, string>>();
        public static List<string> Roles = new List<string>() { "Carry", "Hard Support", "Support", "Offlane", "Mid" };
        public static List<int> auxiliar = new List<int>();


        // You *MUST* mark these commands with 'RunMode.Async'
        // otherwise the bot will not respond until the Task times out.
        [Command("join", RunMode = RunMode.Async)]
        public async Task JoinCmd()
        {
            await _service.JoinAudio(Context.Guild, (Context.User as IVoiceState).VoiceChannel);
        }

        // Remember to add preconditions to your commands,
        // this is merely the minimal amount necessary.
        // Adding more commands of your own is also encouraged.
        [Command("leave", RunMode = RunMode.Async)]
        public async Task LeaveCmd()
        {
            await _service.LeaveAudio(Context.Guild);
        }

        [Command("wow", RunMode = RunMode.Async)]
        public async Task PlayCmd()
        {

            var emoji = new Emoji("😮");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\wow.mp3");
        }
        [Command("haha", RunMode = RunMode.Async)]
        public async Task Haha()
        {

            var emoji = new Emoji("🤣");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\haha.mp3");
        }
        [Command("stfu", RunMode = RunMode.Async)]
        public async Task Stfu()
        {

            var emoji = new Emoji("🖕");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\stfu.mp3");
        }
        [Command("eta", RunMode = RunMode.Async)]
        public async Task Eta()
        {

            var emoji = new Emoji("🥊");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\eta.mp3");
        }
        [Command("freshmeat", RunMode = RunMode.Async)]
        public async Task Freshmeat()
        {

            var emoji = new Emoji("🥊");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\freshmeat.mp3");
        }
        [Command("fight", RunMode = RunMode.Async)]
        public async Task Fight()
        {

            var emoji = new Emoji("🥊");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\fight.mp3");
        }
        [Command("alan", RunMode = RunMode.Async)]
        public async Task PlayAlan()
        {
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\VaiAlan.mp3");
        }
        [Command("fail", RunMode = RunMode.Async)]
        public async Task PlayAlanFail()
        {
            var emoji = new Emoji("❌");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\fail.mp3");
        }
        [Command("room26", RunMode = RunMode.Async)]
        public async Task Room26()
        {
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\Room_26.mp3");
        }
        [Command("tabperiodic", RunMode = RunMode.Async)]
        public async Task TabPeriodic()
        {
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\TabPeriodic.mp3");
        }
        [Command("spooky", RunMode = RunMode.Async)]
        public async Task Spooky()
        {
            var emoji = new Emoji("👻");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\spooky.wav");
        }
        [Command("levelup", RunMode = RunMode.Async)]
        public async Task LevelUp()
        {

            var emoji = new Emoji("⬆️");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\levelup.mp3");
        }
        [Command("drum", RunMode = RunMode.Async)]
        public async Task Drum()
        {
            var emoji = new Emoji("🥁");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\drum.mp3");
        }
        [Command("calaboca", RunMode = RunMode.Async)]
        public async Task CalaBoca()
        {
            var emoji = new Emoji("🙉");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\macaco.mp3");
        }
        [Command("yay", RunMode = RunMode.Async)]
        public async Task Yay()
        {
            var emoji = new Emoji("👏");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\yay.mp3");
        }
        [Command("bye", RunMode = RunMode.Async)]
        public async Task Bye()
        {
            var emoji = new Emoji("👏");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\bye.mp3");
        }
        [Command("toc", RunMode = RunMode.Async)]
        public async Task Toc()
        {
            var emoji = new Emoji("✊");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\toc.mp3");
        }

        [Command("shave", RunMode = RunMode.Async)]
        public async Task Shave()
        {
            var emoji = new Emoji("🪒");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\shave.mp3");
        }
        [Command("bag", RunMode = RunMode.Async)]
        public async Task Bag()
        {
            var emoji = new Emoji("🛍️");
            await Context.Message.AddReactionAsync(emoji);
            await _service.SendAudioAsync(Context.Guild, Context.Channel, @"C:\Users\Gabriel\Downloads\bag.mp3");
        }


        [Command("role")]
        public async Task RandomRole()
        {
        start:
            if (Participants.Count == 5)
            {
                await Context.Channel.SendMessageAsync("Lista de participantes está cheia!");
            }
            else
            {
                Random random = new Random();
                int index = random.Next(Roles.Count);
                if (auxiliar.Contains(index)) goto start;

                auxiliar.Add(index);
                Participants.Add(new KeyValuePair<string, string>(Context.User.Mention, Roles[index]));
                await Context.Channel.SendMessageAsync(Context.User.Mention + " está participando!");
            }
        }
        [Command("roll")]
        public async Task Roll()
        {
            List<string> verbs = new List<string>() { "vai ter que ir de ", "não queria, mas vai de ", "tirou a sorte grande e vai de ", "lambeu a caceta do bot e vai de ", ", sua mãe não aprova, mas terá que ir de " };

            string retorno = string.Empty;
            foreach (var participant in Participants)
            {
                Random random = new Random();
                int index = random.Next(verbs.Count);
                retorno += 
                    Environment.NewLine + participant.Key + " > " + participant.Value + ". " + Environment.NewLine;

            }
            Participants.Clear();
            auxiliar.Clear();
            await Context.Channel.SendMessageAsync(retorno);
        }
        [Command("img")]
        public async Task UploadImage(NamableArguments namedArgs)
        {

        start:
            string topclear = string.IsNullOrEmpty(namedArgs.T) ? "  " : RemoveAccents(namedArgs.T);
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
            if (nomeImg.Contains("MyMeme")) goto start;
            //POST no Discord
            var client2 = new RestClient("https://ronreiter-meme-generator.p.rapidapi.com/meme?font=Impact&meme=" + nomeImg + "&top=" + topclear + "&bottom=" + bottomclear);
            var request2 = new RestRequest(Method.GET);
            request2.AddHeader("x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com");
            request2.AddHeader("x-rapidapi-key", "56ed7b918bmsh736bb11a5f6f181p1c14d3jsn962f642280e5");
            IRestResponse response2 = client2.Execute(request);
            System.Drawing.Image imageIn = ConvertByteArrayToImage(response2.RawBytes);
            File.WriteAllBytes("C:\\Users\\Gabriel\\Pictures\\imgmeme\\img.jpg", response2.RawBytes);
            await Context.Channel.SendFileAsync("C:\\Users\\Gabriel\\Pictures\\imgmeme\\img.jpg");

        }
        [Command("mp4")]
        public async Task PostMP4([Remainder]string text)
        {
            string json = string.Empty;
            using (HttpClient httpC = new HttpClient() { BaseAddress = new Uri("https://api.tenor.com") })
            {
                var result = httpC.GetAsync("v1/random?key=DO5TZDWSVHYH&q=" + text).Result;
                json = result.Content.ReadAsStringAsync().Result;
            }

            RootObject response = JsonDeserialize<RootObject>(json);
            var random = new Random();
            int index = random.Next(response.results.Count);

            using (WebClient client = new WebClient())
            {
                client.DownloadFile(response.results[index].media.First().mp4.url, "C:\\Users\\Gabriel\\Pictures\\imgmeme\\BOTConf.mp4");
            }


            await Context.Channel.SendFileAsync("C:\\Users\\Gabriel\\Pictures\\imgmeme\\BOTConf.mp4");
        }
        [Command("gif")]
        public async Task PostGif([Remainder]string text)
        {
            string json = string.Empty;
            using (HttpClient httpC = new HttpClient() { BaseAddress = new Uri("https://api.tenor.com") })
            {
                var result = httpC.GetAsync("v1/random?key=DO5TZDWSVHYH&q=" + text).Result;
                json = result.Content.ReadAsStringAsync().Result;
            }

            RootObject response = JsonDeserialize<RootObject>(json);
            var random = new Random();
            int index = random.Next(response.results.Count);
            if (response.results.Count == 0)
            {
                await Context.Channel.SendMessageAsync("Luan Burroman, nosso escravo oficial, não encontrou nada com esse texto.");
            }
            else
            {
                try
                {
                    using (WebClient client = new WebClient())
                    {
                        client.DownloadFile(response.results[index].media.First().mediumgif.url, "C:\\Users\\Gabriel\\Pictures\\imgmeme\\tenor.gif");
                    }
                }
                catch (Exception ex)
                {
                    await Context.Channel.SendMessageAsync("Deu erro porra. Você conseguiu quebrar meu bot, panaca!");
                }

                if (response.results.Count > 0) await Context.Channel.SendFileAsync("C:\\Users\\Gabriel\\Pictures\\imgmeme\\tenor.gif");
            }


        }

        static public byte[] GetBytesFromUrl(string url)
        {
            byte[] b;
            HttpWebRequest myReq = (HttpWebRequest)WebRequest.Create(url);
            WebResponse myResp = myReq.GetResponse();

            Stream stream = myResp.GetResponseStream();
            //int i;
            using (BinaryReader br = new BinaryReader(stream))
            {
                //i = (int)(stream.Length);
                b = br.ReadBytes(500000);
                br.Close();
            }
            myResp.Close();
            return b;
        }

        static public void WriteBytesToFile(string fileName, byte[] content)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            BinaryWriter w = new BinaryWriter(fs);
            try
            {
                w.Write(content);
            }
            finally
            {
                fs.Close();
                w.Close();
            }
        }

        public System.Drawing.Image DownloadImageFromUrl(string imageUrl)
        {
            System.Drawing.Image image = null;

            try
            {
                System.Net.HttpWebRequest webRequest = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(imageUrl);
                webRequest.AllowWriteStreamBuffering = true;
                webRequest.Timeout = 30000;

                System.Net.WebResponse webResponse = webRequest.GetResponse();

                System.IO.Stream stream = webResponse.GetResponseStream();

                image = System.Drawing.Image.FromStream(stream);

                webResponse.Close();
            }
            catch (Exception ex)
            {
                return null;
            }

            return image;
        }
        public static T JsonDeserialize<T>(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }

        [Command("imgf")]
        public async Task UploadImageFont(NamableArguments namedArgs)
        {
        start:
            var client3 = new RestClient("https://ronreiter-meme-generator.p.rapidapi.com/fonts");
            var request3 = new RestRequest(Method.GET);
            request3.AddHeader("x-rapidapi-host", "ronreiter-meme-generator.p.rapidapi.com");
            request3.AddHeader("x-rapidapi-key", "56ed7b918bmsh736bb11a5f6f181p1c14d3jsn962f642280e5");
            IRestResponse response3 = client3.Execute(request3);
            List<string> fonts = JsonConvert.DeserializeObject<List<string>>(response3.Content);
            var randomf = new Random();
            int count = fonts.Count;
            int randomFont = randomf.Next(count);
            string nomefont = fonts[randomFont];
            string topclear = string.IsNullOrEmpty(namedArgs.T) ? "  " : RemoveAccents(namedArgs.T);
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
            if (nomeImg.Contains("MyMeme")) goto start;
            //POST no Discord
            var client2 = new RestClient("https://ronreiter-meme-generator.p.rapidapi.com/meme?font=" + nomefont + "&meme=" + nomeImg + "&top=" + topclear + "&bottom=" + bottomclear);
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
            await Context.Channel.SendMessageAsync("=mp4 <searchtext>");
            await Context.Channel.SendMessageAsync("=gif <searchtext>");
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

    public class AudioService
    {
        private readonly ConcurrentDictionary<ulong, IAudioClient> ConnectedChannels = new ConcurrentDictionary<ulong, IAudioClient>();

        public async Task JoinAudio(IGuild guild, IVoiceChannel target)
        {
            IAudioClient client;
            if (ConnectedChannels.TryGetValue(guild.Id, out client))
            {
                return;
            }
            if (target.Guild.Id != guild.Id)
            {
                return;
            }
            try
            {
                var audioClient = await target.ConnectAsync();
                if (ConnectedChannels.TryAdd(guild.Id, audioClient))
                {
                    // If you add a method to log happenings from this service,
                    // you can uncomment these commented lines to make use of that.
                    //await Log(LogSeverity.Info, $"Connected to voice on {guild.Name}.");
                }
            }
            catch(Exception e)
            {
                string msg = e.Message;
            }
           
        }

        public async Task LeaveAudio(IGuild guild)
        {
            IAudioClient client;
            if (ConnectedChannels.TryRemove(guild.Id, out client))
            {
                await client.StopAsync();
                //await Log(LogSeverity.Info, $"Disconnected from voice on {guild.Name}.");
            }
        }

        public async Task SendAudioAsync(IGuild guild, IMessageChannel channel, string path)
        {
            // Your task: Get a full path to the file if the value of 'path' is only a filename.
            if (!File.Exists(path))
            {
                await channel.SendMessageAsync("File does not exist.");
                return;
            }
            IAudioClient client;
            if (ConnectedChannels.TryGetValue(guild.Id, out client))
            {
                //await Log(LogSeverity.Debug, $"Starting playback of {path} in {guild.Name}");
                using (var ffmpeg = CreateProcess(path))
                using (var stream = client.CreatePCMStream(AudioApplication.Music))
                {
                    try { await ffmpeg.StandardOutput.BaseStream.CopyToAsync(stream); }
                    finally { await stream.FlushAsync(); }
                }
            }
        }

        private Process CreateProcess(string path)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = "ffmpeg.exe",
                Arguments = $"-hide_banner -loglevel panic -i \"{path}\" -ac 2 -f s16le -ar 48000 pipe:1",
                UseShellExecute = false,
                RedirectStandardOutput = true
            });
        }
    }
}
