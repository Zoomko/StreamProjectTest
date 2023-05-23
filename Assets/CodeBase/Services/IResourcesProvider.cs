using Assets.CodeBase.Data;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.App
{
    public interface IResourcesProvider
    {
        GameObject Odometer { get; }
        Config Config { get; }
        AppSettings AppSettings { get; }
        GameObject HUD { get; }
        void Load(); 
    }
}