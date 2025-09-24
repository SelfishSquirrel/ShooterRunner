using System;
using System.Collections;
using UnityEngine;

namespace Codebase
{
    public class EnemyRotator : MonoBehaviour
    {
        private GameObject _playerRef;
        private bool _isInitialized;

        private void Awake()
        {
            if (PlayerMarker.Instance != null)
            {
                _playerRef = PlayerMarker.Instance.gameObject;
                _isInitialized = true;
            }
            else
            {
                StartCoroutine(WaitForPlayer());
            }
        }

        private IEnumerator WaitForPlayer()
        {
            yield return new WaitUntil(() => PlayerMarker.Instance != null);

            _playerRef = PlayerMarker.Instance.gameObject;
            _isInitialized = true;
        }

        private void Update()
        {
            if (_playerRef != null)
            {
                Vector3 directionToPlayer = _playerRef.transform.position - transform.position;

                if (directionToPlayer != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);

                    transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
                }
                
                directionToPlayer.y = 0;
            }
        }
    }
}