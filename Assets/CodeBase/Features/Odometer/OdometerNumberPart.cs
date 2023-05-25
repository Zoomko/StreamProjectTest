using Assets.CodeBase.App;
using UnityEngine;

namespace Assets.CodeBase.Odometer
{
    public class OdometerNumberPart : MonoBehaviour
    {
        private const float DecimalAngleValue = 36f;

        private readonly Vector3 _rotateAxis = new Vector3(0, 0, 1f);
        private Quaternion _startRotation;

        private float _lastIntagerNumber = 0;
        private AudioController _audioController;

        public void Constructor(AudioController audioController)
        {
            _audioController = audioController;
        }

        private void Awake()
        {
            _startRotation = transform.localRotation;
        }

        public void SetRotationByNumber(float number)
        {
            MakeTickSound(number);
            transform.localRotation = _startRotation * Quaternion.Euler(_rotateAxis * DecimalAngleValue * number);
        }

        private void MakeTickSound(float number)
        {
            var currentIntegerNumber = Mathf.Floor(number);
            if (currentIntegerNumber != _lastIntagerNumber)
            {
                _audioController.PlayOdometerTick();
            }
            _lastIntagerNumber = currentIntegerNumber;
        }
    }
}