namespace Assets.CodeBase.Data
{
    public class Config
    {
        public ServerSettings ServerSettings { get; set; }
        public AudioSettings AudioSettings { get; set; }
    }

    public class AudioSettings
    {
        public float MusicVolume { get; set; }
        public float SoundsVolume { get; set; }
        public bool MisucMute { get; set; }
        public bool SoundsMute { get; set; }
    }

    public class ServerSettings
    {
        public string ServerAddress { get; set; }
        public string ServerPort { get; set; }
        public string BroadcastAddress { get; set; }
        public override string ToString()
        {
            return ServerAddress + ":" + ServerPort;
        }
    }

}
