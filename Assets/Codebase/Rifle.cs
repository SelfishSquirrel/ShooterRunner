using UnityEngine;

namespace Codebase
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] private Camera _playerCamera;

        [SerializeField] private WeaponRecoil _weaponRecoil;
        [field: SerializeField] public float FireRate { get; set; }
        [SerializeField] private float _castDistance;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _weaponDamage;
        [SerializeField] private ParticleSystem _shootVFX;

        private float _elapsedTime;


        private void Update()
        {
            _elapsedTime += Time.deltaTime;
        }

        public void Use()
        {
            if (_elapsedTime < FireRate) return; 
            _weaponRecoil.ApplyRecoil();
            TryHitEnemy();
            print("Use rifle");
            _elapsedTime = 0;
        }

        private void TryHitEnemy()
        {
            PlayVFX();
            if (Physics.Raycast(_playerCamera.transform.position, _playerCamera.transform.forward, out RaycastHit hit,
                    _castDistance, _layerMask))
            {
                if (hit.transform.TryGetComponent(out IHealth health))
                {
                    health.ApplyDamage(_weaponDamage);
                }
            }
        }

        private void PlayVFX()
        {
            _shootVFX.Play();
        }


        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}