using UnityEngine;

namespace Assets.CodeBase.Helper
{
    public static class Functions
    {
        public static float SmoothStep(float value) => Mathf.Min(1, Mathf.Tan(value * 1.5f) / 20);
    }
}
