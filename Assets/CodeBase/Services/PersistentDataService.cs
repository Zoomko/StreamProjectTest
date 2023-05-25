using Assets.CodeBase.App;
using Assets.CodeBase.Data;

namespace Assets.CodeBase.Services
{
    public class PersistentDataService : IPersistentDataService
    {
        private readonly ILoadSaveDataFormat _loadSaveDataFormat;
        private Config _config;
        public Config Config => _config;

        public PersistentDataService(ILoadSaveDataFormat loadSaveDataFormat)
        {
            _loadSaveDataFormat = loadSaveDataFormat;
        }

        public void Load()
        {
            _config = _loadSaveDataFormat.Load<Config>(Paths.ConfigPath);
        }

        public void Save()
        {
            _loadSaveDataFormat.Save(Paths.ConfigPath, _config);
        }
    }
}
