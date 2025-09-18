using UnityEngine;

namespace Codebase
{
    [CreateAssetMenu(menuName = "PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public GameObject PlayerPrefab;
        public float Speed;
        public float JumpForce;
    }
}