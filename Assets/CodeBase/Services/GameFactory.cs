using Assets.CodeBase.App;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.UI;
using Assets.CodeBase.UI.Menu;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class GameFactory
    {
        private readonly IResourcesProvider _resourcesProvider;
        private readonly AudioController _audioController;

        private OdometerView _odometerView;
        private HUDView _hud;

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

        public HUDView CreateHUD()
        {
            var hudGameObject = GameObject.Instantiate(_resourcesProvider.HUD);
            var hud = hudGameObject.GetComponent<HUDView>();

            hud.GetCurrentOdometerValueButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.GetRandomOdometerValueButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.MenuButton.onClick.AddListener(_audioController.PlayButtonClick);
            hud.StartBroadcastButton.onClick.AddListener(_audioController.PlayButtonClick);

            _hud = hud;
            return hud;
        }

        public MenuView CreateMenu()
        {
            var menuGameObject = GameObject.Instantiate(_resourcesProvider.Menu);
            var menuView = menuGameObject.GetComponent<MenuView>();

            menuView.CloseButton.onClick.AddListener(_audioController.PlayButtonClick);
            menuView.SaveButton.onClick.AddListener(_audioController.PlayButtonClick);
            return menuView;
        }
    }
}
