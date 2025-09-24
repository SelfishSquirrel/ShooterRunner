using System;
using UnityEngine;

namespace Codebase
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private Transform _hitPosition;
        [SerializeField] private float _radius;
        [SerializeField] private LayerMask _layerMask;
        [SerializeField] private float _damage;
        
        private Collider[] _colliders = new Collider[8];

        private void OnDrawGizmos()
        {
            Gizmos.DrawSphere(_hitPosition.position, _radius);
        }

        public void OnAttack()
        {
            print("OnAttack");
            int hitCount = Physics.OverlapSphereNonAlloc(transform.position, _radius, _colliders, _layerMask);

            if (hitCount > 0)
            {
                for (int i = 0; i < hitCount; i++)
                {
                    if (_colliders[i].TryGetComponent(out IHealth health))
                    {
                        health.ApplyDamage(_damage);
                    }
                }
            }
        }
    }
}