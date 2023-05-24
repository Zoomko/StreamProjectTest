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
        private AppSettings _appSettings;
        private GameObject _hud;
        private GameObject _menu;
        private SoundsData _sounds;

        public GameObject Odometer => _odometer;
        public AppSettings AppSettings => _appSettings;
        public GameObject HUD => _hud;
        public GameObject Menu => _menu;

        public SoundsData Sounds  => _sounds;

        public ResourcesProvider(ILoadSaveDataFormat loadSaveDataFormat)
        {
            _loadSaveDataFormat = loadSaveDataFormat;
        }

        public void Load()
        {
            LoadOdometer();            
            LoadAppSettings();
            LoadHUD();
            LoadMenu();
            LoadSounds();
        }

        private void LoadOdometer()
            => _odometer = Resources.Load<GameObject>(Paths.OdometerPath);
        private void LoadAppSettings()
            => _appSettings = Resources.Load<AppSettings>(Paths.AppSettingsPath);
        private void LoadHUD()
            => _hud = Resources.Load<GameObject>(Paths.HUDPath);
        private void LoadMenu() 
            => _menu = Resources.Load<GameObject>(Paths.MenuPath);
        private void LoadSounds()
            => _sounds = Resources.Load<SoundsData>(Paths.SoundsPath);
    }
}
