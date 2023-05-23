using Assets.CodeBase.App;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class GameFactory
    {
        private readonly IResourcesProvider _resourcesProvider;
        private readonly AudioController _audioController;

        private OdometerView _odometerView;
        private HUD _hud;    
            
        public GameFactory(IResourcesProvider resourcesProvider, AudioController audioController)
        {            
            _resourcesProvider = resourcesProvider;
            _audioController = audioController;
        }

        public OdometerView CreateOdometer()
        {
            var odometerGameObject = GameObject.Instantiate(_resourcesProvider.Odometer);
            var odometerView = odometerGameObject.GetComponent<OdometerView>();
            _odometerView = odometerView;
            return odometerView;
        }

        public HUD CreateHUD()
        {
            var hudGameObject = GameObject.Instantiate(_resourcesProvider.HUD);
            var hud = hudGameObject.GetComponent<HUD>();

            hud.GetCurrentOdometerValueButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.GetRandomOdometerValueButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.MenuButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.StartBroadcastButton.onClick.AddListener(_audioController.PlayButtonClick);
            
            _hud = hud; 
            return hud;
        }

        public void CreateMenu()
        {
            var menuGameObject = GameObject.Instantiate(_resourcesProvider.Menu);           
        }
    }
}
