using Assets.CodeBase.App;
using Assets.CodeBase.Odometer;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class GameFactory
    {
        private readonly IResourcesProvider _resourcesProvider;

        private OdometerView _odometerView;
        private HUD _hud;
        public GameFactory(IResourcesProvider resourcesProvider)
        {            
            _resourcesProvider = resourcesProvider;
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
            _hud = hud; 
            return hud;
        }
    }
}
