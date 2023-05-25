using Assets.CodeBase.Services;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.CodeBase.Odometer
{
    public class OdometerModel
    {
        public event Action<float> ValueChanged;
        public event Action<float> FinalValueSet;

        private readonly CoroutineRunner _coroutineRunner;
        private readonly IResourcesProvider _resourceProvider;
        private float _currentValue = 0f;
        private Coroutine _coroutine;

        public OdometerModel(CoroutineRunner coroutineRunner, IResourcesProvider resourceProvider)
        {
            _coroutineRunner = coroutineRunner;
            _resourceProvider = resourceProvider;
        }

        public void SetValue(float value)
        {
            if (_coroutine != null)
            {
                _coroutineRunner.StopCoroutine(_coroutine);
            }
            _coroutine = _coroutineRunner.StartCoroutine(SettingValue(value));
        }

        private IEnumerator SettingValue(float value)
        {
            var startValue = _currentValue;
            var timeValue = 0f;
            var timeToSetOdometer = _resourceProvider.AppSettings.TimeToSetOdometer;
            while (timeValue < timeToSetOdometer)
            {
                _currentValue = Mathf.Lerp(startValue, value, timeValue / timeToSetOdometer);
                ValueChanged?.Invoke(_currentValue);
                timeValue += Time.deltaTime;
                yield return null;
            }
            _currentValue = value;
            FinalValueSet?.Invoke(value);
        }
    }
}
