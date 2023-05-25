using Assets.CodeBase.Data;
using UnityEngine;

namespace Assets.CodeBase.Services
{
    public interface IResourcesProvider
    {
        GameObject Odometer { get; }
        AppSettings AppSettings { get; }
        GameObject HUD { get; }
        GameObject Menu { get; }
        SoundsData Sounds { get; }
        void Load();
    }
}