using UnityEngine;

namespace Codebase
{
    public class Rifle : MonoBehaviour, IWeapon
    {
        [SerializeField] private Camera _playerCamera;

        [SerializeField] private WeaponRecoil _weaponRecoil;
        public void Use()
        {
            _weaponRecoil.ApplyRecoil();
            print("Use rifle");
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