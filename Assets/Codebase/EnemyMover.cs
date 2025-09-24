using System.Collections;
using UnityEngine;

namespace Codebase
{
    public class EnemyMover : MonoBehaviour
    {
        [SerializeField] private ZombieAnimationController _zombieAnimationController;
        [SerializeField] private float _speed;
        [SerializeField] private float _attackDistance = 1f; // Дистанция для атаки
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
            if (!_isInitialized || _playerRef == null) return;

            // Вычисляем направление к игроку
            Vector3 directionToPlayer = _playerRef.transform.position - transform.position;
            directionToPlayer.y = 0; // Игнорируем Y для движения и поворота

            // Поворот зомби к игроку только по оси Y
            if (directionToPlayer.sqrMagnitude > 0.01f) // Проверяем, что направление не нулевое
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, Vector3.up);
                transform.rotation = Quaternion.Euler(0, targetRotation.eulerAngles.y, 0);
            }


            // Проверяем дистанцию для атаки
            if (directionToPlayer.sqrMagnitude <= _attackDistance * _attackDistance)
            {
                // Если зомби достаточно близко и может атаковать
                if (_zombieAnimationController.CanAttack())
                {
                    _zombieAnimationController.TriggerAttack();
                    _zombieAnimationController.StopWalking();
                }
            }
            else
            {
                // Двигаемся к игроку, только по XZ
                Vector3 targetPosition = _playerRef.transform.position;
                targetPosition.y = transform.position.y; // Фиксируем Y на текущей высоте зомби
                transform.position = Vector3.MoveTowards(
                    transform.position,
                    targetPosition,
                    Time.deltaTime * _speed);

                // Запускаем анимацию ходьбы
                _zombieAnimationController.StartWalking();
            }
        }

        private void OnDisable()
        {
            _playerRef = null;
            _isInitialized = false;
            _zombieAnimationController.StopWalking();
        }
    }
}