using Assets.CodeBase.App;

namespace Assets.CodeBase.Services
{
    public interface IPersistentDataService
    {
        Config Config { get; }

        void Load();
        void Save();
    }
}