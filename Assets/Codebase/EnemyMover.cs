using System.Collections;
using UnityEngine;

namespace Codebase
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private float _speed;
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
            if (_isInitialized && _playerRef != null)
            {
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    _playerRef.transform.position,
                    Time.deltaTime * _speed);
            }
        }

        private void OnDisable()
        {
            _playerRef = null;
            _isInitialized = false;
        }
    }
}