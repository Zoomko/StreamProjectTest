﻿using Assets.CodeBase.App;
using Assets.CodeBase.Services;
using Zenject;

namespace Assets.CodeBase.UI.HUD
{
    public class HUDController : ITickable
    {
        private readonly IPersistentDataService _persistentDataService;
        private readonly AudioController _audioController;
        private HUDView _view;
        private VLCPlayerExample _player;

        private bool _playerStateIsPlaying = false;

        public HUDController(IPersistentDataService persistentDataService, AudioController audioController)
        {
            _persistentDataService = persistentDataService;
            _audioController = audioController;
        }

        public void SetView(HUDView view)
        {
            _view = view;
            _player = _view.PlayerExample;
            SetPath();
        }

        public void StartBroadcast()
        {
            _player.Open();
        }

        public void StartAnotherBroadcastFromNewAddressIfPlayerIsPlaying()
        {
            var newPath = _persistentDataService.Config.ServerSettings.BroadcastAddress;
            if (_player.path != newPath)
            {
                SetPath();
                if (_player.IsPlaying)
                {
                    StartBroadcast();
                }
            }
        }

        public void SetPath()
        {
            _player.path = _persistentDataService.Config.ServerSettings.BroadcastAddress;
        }

        public void SetToggle(bool value)
        {
            if (value)
            {
                _view.TrueToggle.isOn = true;
                _view.FalseToggle.isOn = false;
            }
            else
            {
                _view.FalseToggle.isOn = true;
                _view.TrueToggle.isOn = false;
            }
        }

        public void Tick()
        {
            if (_player != null)
            {
                if (_playerStateIsPlaying != _player.IsPlaying)
                {
                    MuteMusicWhilePlaying(_player.IsPlaying);
                    _playerStateIsPlaying = _player.IsPlaying;
                }
            }
        }

        private void MuteMusicWhilePlaying(bool value)
        {
            _audioController.SetMusicMute(value);
        }
    }
}
