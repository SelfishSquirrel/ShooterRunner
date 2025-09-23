using DG.Tweening;
using UnityEngine;

namespace Codebase
{
    public class WeaponAnimation : MonoBehaviour
    {
        [SerializeField] private Vector3 _forwardVector = new Vector3(0f, 0f, 0.5f);
        [SerializeField] private Vector3 _rotationVector = new Vector3(10f, 0f, 0f); 
        [SerializeField] private float hitDuration = 0.2f; 
        [SerializeField] private float returnDuration = 0.2f; 

        private Vector3 _origin;
        private Quaternion _originRotation; 
        private bool _canHit = true; 
        private Sequence _sequence; 

        private void Start()
        {
            _origin = transform.localPosition;
            _originRotation = transform.localRotation;
        }

        public void Hit()
        {
            if (!_canHit) return; 

            if (_sequence != null)
            {
                _sequence.Kill();
                _sequence = null;
            }

            _canHit = false;

            _sequence = DOTween.Sequence();

            _sequence.Append(transform.DOLocalMove(_origin + _forwardVector, hitDuration).SetEase(Ease.OutQuad));
            _sequence.Join(transform.DOLocalRotateQuaternion(
                _originRotation * Quaternion.Euler(_rotationVector), hitDuration).SetEase(Ease.OutQuad));

            _sequence.Append(transform.DOLocalMove(_origin, returnDuration).SetEase(Ease.InOutSine));
            _sequence.Join(transform.DOLocalRotateQuaternion(_originRotation, returnDuration).SetEase(Ease.InOutSine));

            _sequence.OnComplete(() =>
            {
                _canHit = true;
                _sequence = null;
            });

            _sequence.Play();
        }
    }
}