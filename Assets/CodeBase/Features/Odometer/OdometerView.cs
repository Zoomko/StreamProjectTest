using Assets.CodeBase.Helper;
using System;
using UnityEngine;

namespace Assets.CodeBase.Odometer
{
    public class OdometerView : MonoBehaviour
    {
        private OdometerNumberPart[] _odometerNumberParts;      
        private void Awake()
        {
            _odometerNumberParts = GetComponentsInChildren<OdometerNumberPart>();
        }

        public void SetNumber(float number)
        {
            SetNumberParts(number,GetSmoothStepValue);
        }

        public void SetFinalNumber(float number)
        {
            SetNumberParts(number, GetIntegerValue);
        }
        
        private void SetNumberParts(float number, Func<float,float> func)
        {
            var value = number;
            foreach (var part in _odometerNumberParts)
            {
                float partNumber = func(value);
                part.SetRotationByNumber(partNumber);
                value /= 10;
            }
        }

        private float GetSmoothStepValue(float value)
        {
            var integerPartOfValue = GetIntegerValue(value);
            var decimalPartOfValue = value % 1;
            var partNumber = (float)integerPartOfValue + Functions.SmoothStep(decimalPartOfValue);
            return partNumber;
        }

        private float GetIntegerValue(float value)
        {
            var integerPartOfValue = Math.Floor(value % 10);
            return (float)integerPartOfValue;
        }
    }
}