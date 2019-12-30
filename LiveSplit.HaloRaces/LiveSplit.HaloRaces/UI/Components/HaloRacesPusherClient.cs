using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PusherClient;

namespace LiveSplit.HaloRaces.UI.Components
{
    struct TestMessageData
    {
        public string Sender { get; set; }
        public string Message { get; set; }
    }

    struct RaceBegin
    {
        public int Delay { get; set; }
    }

    struct PusherMessage<T>
    {
        public string Channel { get; set; }
        public string Event { get; set; }
        public T Data { get; set; }
    }

    class HaloRacesPusherClient
    {
        private Pusher _pusher;
        private Channel _channel;

        public string InfoText = "";

        public HaloRacesPusherClient()
        {
            InitialisePusher();
        }

        private async Task InitialisePusher()
        {

            if (_pusher == null)
            {
                _pusher = new Pusher("c8ea67ed4ef975b89910", new PusherOptions()
                {
                    Cluster = "us2",
                    Encrypted = true
                });

                _pusher.Error += OnPusherOnError;
                _pusher.ConnectionStateChanged += PusherOnConnectionStateChanged;
                _pusher.Connected += PusherOnConnected;
                _channel = await _pusher.SubscribeAsync("my-channel");
                _channel.Subscribed += OnChannelOnSubscribed;

                _channel.Bind("my-event", (dynamic data) =>
                {
                    try
                    {
                        string s = Convert.ToString(data);
                        s = s.Replace("\\\"", "\"");
                        s = s.Replace("\"{", "{");
                        s = s.Replace("}\"", "}");

                        Console.WriteLine(s);

                        var e = JsonConvert.DeserializeObject<PusherMessage<RaceBegin>>(s);
                        InfoText = e.Data.Delay.ToString();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                });

                await _pusher.ConnectAsync();
            }
        }

        private void PusherOnConnected(object sender)
        {
            //MessageBox.Show("Connected");
        }

        private void PusherOnConnectionStateChanged(object sender, ConnectionState state)
        {
            //MessageBox.Show("Connection state changed");
        }

        private void OnPusherOnError(object s, PusherException e)
        {
            //MessageBox.Show("Errored");
        }

        private void OnChannelOnSubscribed(object s)
        {
            //MessageBox.Show("Subscribed");
        }

        async Task OnApplicationQuit()
        {
            if (_pusher != null)
            {
                await _pusher.DisconnectAsync();
            }
        }
    }
}
