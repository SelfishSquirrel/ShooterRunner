using System;
using UnityEngine;

namespace Codebase
{
    public class PlayerHealth : MonoBehaviour, IHealth
    {
        [field: SerializeField] public float CurrentHealth { get; set; }
        [field: SerializeField] public float MaxHealth { get; set; }

        private void Start()
        {
            CurrentHealth = MaxHealth;
        }

        public void ApplyDamage(float health)
        {
            if (CurrentHealth - health <= 0)
            {
                CurrentHealth = 0;
                Destroy(gameObject);
            }
            CurrentHealth -= health;
        }
    }
    
    
}