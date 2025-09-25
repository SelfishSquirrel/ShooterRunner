using System;
using UnityEngine;

namespace Codebase
{
    public class WeaponHand : MonoBehaviour
    {
        [SerializeField] private Rifle _rifle;
        [SerializeField] private Pistol _pistol;
        [SerializeField] private Knife _knife;
        private IWeapon _currentWeapon;

        private void Start()
        {
            _currentWeapon = _rifle;
        }

        private void Update()
        {
            if (Input.GetMouseButton(0))
            {
                if (_currentWeapon == null) return;

                _currentWeapon.Use();
            }

            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                SwapWeapon(0);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                SwapWeapon(1);
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                SwapWeapon(2);
            }
        }

        private void SwapWeapon(int index)
        {
            switch (index)
            {
                case 0:
                    SelectWeapon(_rifle);
                    break;
                case 1:
                    SelectWeapon(_pistol);
                    break;
                case 2:
                    SelectWeapon(_knife);
                    break;
            }
        }

        private void SelectWeapon(IWeapon weapon)
        {
            _currentWeapon.Deactivate();
            _currentWeapon = weapon;
            _currentWeapon.Activate();
        }
    }
}