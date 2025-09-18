using UnityEngine;
using Zenject;
using Zenject.SpaceFighter;

namespace Codebase
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _playerPrefab;
        public override void InstallBindings()
        {
            Container.Bind<GameObject>().WithId("PlayerPrefab").FromInstance(_playerPrefab).AsCached();
            
            Container.BindFactory<PlayerMarker, PlayerFactory>().AsSingle();
        }
    }
}