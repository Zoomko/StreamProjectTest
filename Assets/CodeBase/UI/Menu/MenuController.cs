using Assets.CodeBase.App;
using Assets.CodeBase.Services;
using Assets.CodeBase.UI.HUD;
using TMPro;
using UnityEngine;

namespace Assets.CodeBase.UI.Menu
{
    public class MenuController
    {
        private readonly GameFactory _gameFactory;   
        private readonly IPersistentDataService _persistentDataService;
        private readonly WebSocketClient _webSocketClient;
        private readonly HUDController _hudController;
        private MenuView _view;
        private MenuModel _model;

        public MenuController(GameFactory gameFactory,
                              AudioController audioController,
                              IPersistentDataService persistentDataService,
                              WebSocketClient webSocketClient,
                              HUDController hudController)
        {
            _gameFactory = gameFactory;           
            _persistentDataService = persistentDataService;
            _webSocketClient = webSocketClient;
            _hudController = hudController;
            _model = new MenuModel(audioController,persistentDataService);
        }

        public void OpenWindow()
        {
            _view = _gameFactory.CreateMenu();
            InitializeViewValues();
            SubscribeToEvents();           
        }

        public void CloseWindow()
        {    
            _view.Close();
        }

        public void OpenOrCloseWindow()
        {
            if (_view != null)
            {
                CloseWindow();
            }
            else
            {
                OpenWindow();
            }
        }

        private void InitializeViewValues()
        {
            _view.ServerIP.text = _persistentDataService.Config.ServerSettings.ServerAddress;
            _view.ServerPort.text = _persistentDataService.Config.ServerSettings.ServerPort;
            _view.BroadcastAddress.text = _persistentDataService.Config.ServerSettings.BroadcastAddress;

            _view.MusicVolume.value = _persistentDataService.Config.AudioSettings.MusicVolume;
            _view.SoundsVolume.value = _persistentDataService.Config.AudioSettings.SoundsVolume;

            _view.MuteMusic.isOn = _persistentDataService.Config.AudioSettings.MisucMute;
            _view.MuteSounds.isOn = _persistentDataService.Config.AudioSettings.SoundsMute;
        }

        private void SubscribeToEvents()
        {
            _view.ServerIP.onValueChanged.AddListener(_model.SetIPAddress);
            _view.ServerPort.onValueChanged.AddListener(_model.SetPortAddress);
            _view.BroadcastAddress.onValueChanged.AddListener(_model.SetBroadcastAddress);

            _view.MusicVolume.onValueChanged.AddListener(_model.SetMusicVolume);
            _view.SoundsVolume.onValueChanged.AddListener(_model.SetSoundsVolume);

            _view.MuteMusic.onValueChanged.AddListener(_model.SetMuteMusic);
            _view.MuteSounds.onValueChanged.AddListener(_model.SetMuteSounds);

            _view.SaveButton.onClick.AddListener(SaveChanges);
            _view.CloseButton.onClick.AddListener(CloseWindow);
        }

        private void SaveChanges()
        {
            _persistentDataService.Save();
            _webSocketClient.RecreateWebSocketWithNewAddress();            
            _hudController.StartAnotherBroadcastFromNewAddressIfPlayerIsPlaying();
        }
    }
}
