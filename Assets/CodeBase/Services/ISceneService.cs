using System;

namespace Assets.CodeBase.Services
{
    public interface ISceneService
    {
        void Load(string name, Action onLoaded);
    }
}