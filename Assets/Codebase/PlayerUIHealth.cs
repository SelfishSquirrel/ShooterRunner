using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class PlayerUIHealth : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private PlayerHealth _playerHealth;

        private void Start()
        {
            UpdateHPBar();
            _playerHealth.OnHurt += UpdateHPBar;
        }

        private void OnDestroy()
        {
            _playerHealth.OnHurt -= UpdateHPBar;
        }

        private void UpdateHPBar()
        {
            _healthBar.fillAmount = _playerHealth.CurrentHealth;
            _healthText.text = $"{_playerHealth.CurrentHealth.ToString()}/{_playerHealth.MaxHealth.ToString()}";
        }
    }
}