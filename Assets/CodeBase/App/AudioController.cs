using Assets.CodeBase.App;
using UnityEngine;
using Zenject;

public class AudioController : MonoBehaviour
{
    IResourcesProvider _resourcesProvider;

    private AudioSource _musicSource;
    private AudioSource _soundSource;
    private AudioListener _listener;

    [Inject]
    public void Constructor(IResourcesProvider resourcesProvider)
    {
        _resourcesProvider = resourcesProvider;
    }   

    private void Awake()
    {
        _musicSource = gameObject.AddComponent<AudioSource>();
        _soundSource = gameObject.AddComponent<AudioSource>();
        _listener = gameObject.AddComponent<AudioListener>();

        _musicSource.loop = true;
        _soundSource.loop = false;
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
