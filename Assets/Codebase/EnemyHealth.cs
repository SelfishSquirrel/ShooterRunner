using UnityEngine;

namespace Codebase
{
    public class EnemyHealth : MonoBehaviour, IHealth
    {
        [field: SerializeField] public float CurrentHealth { get; set; }
        [field: SerializeField] public float MaxHealth { get; set; }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void ApplyDamage(float health)
        {
            print($"Got {health} damage");
            if (CurrentHealth - health <= 0)
            {
                CurrentHealth = 0;
                Destroy(gameObject);
            }
            CurrentHealth -= health;
        }
    }
}