using Assets.CodeBase.App;
using Assets.CodeBase.Services;

namespace Assets.CodeBase.UI.Menu
{
    internal class MenuModel
    {
        private AudioController _audioController;
        private IPersistentDataService _persistentDataService;

        public MenuModel(AudioController audioController, IPersistentDataService persistentDataService)
        {
            _audioController = audioController;
            _persistentDataService = persistentDataService;
        }

        public void SetMusicVolume(float volume)
        {
            _audioController.SetMusicVolume(volume);
            _persistentDataService.Config.AudioSettings.MusicVolume = volume;
        }

        public void SetSoundsVolume(float volume)
        {
            _audioController.SetSoundsVolume(volume);
            _persistentDataService.Config.AudioSettings.SoundsVolume = volume;
        }

        public void SetMuteMusic(bool value)
        {
            _audioController.SetMusicMute(value);
            _persistentDataService.Config.AudioSettings.MisucMute = value;
        }

        public void SetMuteSounds(bool value)
        {
            _audioController.SetSoundsMute(value);
            _persistentDataService.Config.AudioSettings.SoundsMute = value;
        }

        public void SetIPAddress(string value)
        {
            _persistentDataService.Config.ServerSettings.ServerAddress = value;
        }

        public void SetPortAddress(string value)
        {
            _persistentDataService.Config.ServerSettings.ServerPort = value;
        }

        public void SetBroadcastAddress(string value)
        {
            _persistentDataService.Config.ServerSettings.BroadcastAddress = value;
        }
    }
}
