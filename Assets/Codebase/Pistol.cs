using UnityEngine;

namespace Codebase
{
    public class Pistol : MonoBehaviour, IWeapon
    {
        [SerializeField] private Camera _playerCamera;

        [SerializeField] private WeaponRecoil _weaponRecoil;
        public void Use()
        {
            print("Use pistol");
            _weaponRecoil.ApplyRecoil();
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