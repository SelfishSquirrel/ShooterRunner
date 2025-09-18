using System;
using UnityEngine;
using Zenject;

namespace Codebase
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private PlayerConfig _playerConfig;

        private GameObject _player;
        private void Start()
        {
            InitWorld();
        }

        private void InitWorld()
        {
            PlayerSpawnPoint playerSpawnPoint = GameObject.FindFirstObjectByType<PlayerSpawnPoint>();
            _player = GameObject.Instantiate(_playerConfig.PlayerPrefab, playerSpawnPoint.transform.position, Quaternion.identity);
            _player.GetComponent<PlayerMovement>().Init(_playerConfig.Speed, _playerConfig.JumpForce);
        }
    }
}