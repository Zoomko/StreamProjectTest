using Assets.CodeBase.Data;

namespace Assets.CodeBase.Services
{
    public interface IPersistentDataService
    {
        Config Config { get; }

        void Load();
        void Save();
    }
}