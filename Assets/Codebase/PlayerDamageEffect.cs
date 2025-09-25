using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Codebase
{
    public class PlayerDamageEffect : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _playerHealth;
        [SerializeField] private Image _hurtImage;
        [SerializeField] private bool _canPlayEffect = true;

        private void Start()
        {
            _playerHealth.OnHurt += PlayDamageEffect;
        }

        private void OnDestroy()
        {
            _playerHealth.OnHurt -= PlayDamageEffect;
        }

        private void PlayDamageEffect()
        {
            if (_canPlayEffect)
            {
                _canPlayEffect = false;
                _hurtImage.DOFade(0.5f, 0.3f).OnComplete(() =>
                {
                    _canPlayEffect = true;
                    _hurtImage.DOFade(0f, 0.3f);
                });
            }
        }
    }
}