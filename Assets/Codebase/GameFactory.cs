using UnityEngine;

namespace Codebase
{
    public class GameFactory : IGameFactory
    {
        public GameObject Player { get; set; }
        
        public GameObject CreatePlayer()
        {
            Player = Object.Instantiate(Resources.Load<GameObject>("Prefabs/Player"));
            return Player;
        }
    }
}