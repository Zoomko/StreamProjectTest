using Assets.CodeBase.Services;
using UnityEngine;
using Zenject;

namespace Assets.CodeBase.App
{
    public class AudioController : MonoBehaviour
    {
        private IResourcesProvider _resourcesProvider;
        private IPersistentDataService _persistentDataService;

        private AudioSource _musicSource;
        private AudioSource _soundSource;
        private AudioListener _listener;

        [Inject]
        public void Constructor(IResourcesProvider resourcesProvider, IPersistentDataService persistentDataService)
        {
            _resourcesProvider = resourcesProvider;
            _persistentDataService = persistentDataService;
        }

        private void Awake()
        {
            _musicSource = gameObject.AddComponent<AudioSource>();
            _soundSource = gameObject.AddComponent<AudioSource>();
            _listener = gameObject.AddComponent<AudioListener>();

            _musicSource.loop = true;
            _soundSource.loop = false;
        }

        public void InitializeValues()
        {
            SetSoundsVolume(_persistentDataService.Config.AudioSettings.SoundsVolume);
            SetMusicVolume(_persistentDataService.Config.AudioSettings.MusicVolume);

            SetSoundsMute(_persistentDataService.Config.AudioSettings.SoundsMute);
            SetMusicMute(_persistentDataService.Config.AudioSettings.MisucMute);
        }

        public void PlayMusic()
        {
            _musicSource.clip = _resourcesProvider.Sounds.SoundsCollection["BackgroundMusic"];
            _musicSource.Play();
        }

        public void PlayButtonClick()
        {
            _soundSource.clip = _resourcesProvider.Sounds.SoundsCollection["ButtonClick"];
            _soundSource.Play();
        }

        public void PlayOdometerTick()
        {
            _soundSource.clip = _resourcesProvider.Sounds.SoundsCollection["RollTick"];
            _soundSource.Play();
        }

        public void SetSoundsVolume(float value)
        {
            _soundSource.volume = value;
        }

        public void SetMusicVolume(float value)
        {
            _musicSource.volume = value;
        }

        public void SetSoundsMute(bool value)
        {
            _soundSource.mute = value;
        }

        public void SetMusicMute(bool value)
        {
            _musicSource.mute = value;
        }
    }
}