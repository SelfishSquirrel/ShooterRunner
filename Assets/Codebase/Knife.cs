using System;
using DG.Tweening;
using UnityEngine;

namespace Codebase
{
    public class Knife : MonoBehaviour, IWeapon
    {
        [SerializeField] private Camera _playerCamera;
        [SerializeField] private WeaponAnimation _weaponAnimation;
        [SerializeField] private Vector3 _forwardVector;
        [SerializeField] private Vector3 _rotationVector;
        [SerializeField] private float _raycastDistance = 1.6f;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _knifeDamage;
        private Sequence _sequence;
        private bool _canHit = true;
        private Vector3 _origin;
        private Vector3 _rotation;

        private void Start()
        {
            _origin = transform.localPosition;
            _rotation = transform.rotation.eulerAngles;
        }

        public void Use()
        {
            if (!_canHit) return;

            _weaponAnimation.Hit();
            TryDamage();
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }

        private void TryDamage()
        {
            _canHit = false;
            
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit hit,
                    _raycastDistance, _layerMask))
            {
                if (hit.transform.gameObject.TryGetComponent(out IHealth health))
                {
                    health.ApplyDamage(_knifeDamage);
                }
            }

            _canHit = true;
        }
        
    }
}