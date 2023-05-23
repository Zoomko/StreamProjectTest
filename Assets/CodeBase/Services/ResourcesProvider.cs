using Assets.CodeBase.App;
using Assets.CodeBase.Data;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public class ResourcesProvider : IResourcesProvider
    {
        private readonly ILoadSaveDataFormat _loadSaveDataFormat;

        private GameObject _odometer;
        private Config _config;
        private AppSettings _appSettings;
        private GameObject _hud;

        public GameObject Odometer => _odometer;

        public Config Config  => _config;
        public AppSettings AppSettings => _appSettings;
        public GameObject HUD => _hud;

        public ResourcesProvider(ILoadSaveDataFormat loadSaveDataFormat)
        {
            _loadSaveDataFormat = loadSaveDataFormat;
        }

        public void Load()
        {
            LoadOdometer();
            LoadConfig();
            LoadAppSettings();
            LoadHUD();
        }

        private void LoadOdometer()
            => _odometer = Resources.Load<GameObject>(Paths.OdometerPath);
        private void LoadConfig()
            =>_config = _loadSaveDataFormat.Load<Config>(Paths.ConfigPath);
        private void LoadAppSettings()
            => _appSettings = Resources.Load<AppSettings>(Paths.AppSettingsPath);
        private void LoadHUD()
            => _hud = Resources.Load<GameObject>(Paths.HUDPath);
    }
}
