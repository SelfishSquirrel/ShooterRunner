using UnityEngine;
using Zenject;

namespace Codebase
{
    public class PlayerFactory : PlaceholderFactory<PlayerMarker>
    {
        private readonly DiContainer _container;
        private readonly GameObject _playerPrefab;

        [Inject]
        public PlayerFactory(DiContainer container, GameObject playerPrefab)
        {
            _container = container;
            _playerPrefab = playerPrefab;
        }

        public override PlayerMarker Create()
        {
            Debug.Log("Creating player marker");
            return _container.InstantiatePrefabForComponent<PlayerMarker>(_playerPrefab);
        }
    }
}