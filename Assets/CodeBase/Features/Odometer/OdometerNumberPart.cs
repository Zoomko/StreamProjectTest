using System;
using UnityEngine;

namespace Assets.CodeBase.Odometer
{
    public class OdometerNumberPart : MonoBehaviour
    {
        private const float DecimalAngleValue = 36f;
        private readonly Vector3 _rotateAxis = new Vector3(0, 0, 1f);
        private Quaternion _startRotation;

        private void Awake()
        {
            _startRotation = transform.localRotation;
        }        
        public void SetRotationByNumber(float number)
        {
            transform.localRotation = _startRotation * Quaternion.Euler(_rotateAxis * DecimalAngleValue * number);
        }
    }
}