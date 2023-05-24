using Assets.CodeBase.Data;
using Assets.CodeBase.UI;
using UnityEngine;

namespace Assets.CodeBase.App
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