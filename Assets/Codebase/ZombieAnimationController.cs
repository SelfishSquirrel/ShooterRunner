using UnityEngine;

namespace Codebase
{
    [RequireComponent(typeof(Animator))]
    public class ZombieAnimationController : MonoBehaviour
    {
        private static readonly int IsWalkingHash = Animator.StringToHash("IsWalking");
        private static readonly int AttackTriggerHash = Animator.StringToHash("Attack"); // Триггер для атаки
        private static readonly int HitTriggerHash = Animator.StringToHash("Hit"); // Триггер для получения удара
        private static readonly int DieTriggerHash = Animator.StringToHash("Die"); // Триггер для смерти

        private static readonly int
            SpeedHash = Animator.StringToHash("Speed"); // Float для скорости анимации (опционально)

        [SerializeField] private Animator _animator;


        private void Awake()
        {
            _animator = GetComponent<Animator>();
            if (_animator == null)
            {
                Debug.LogError("Animator component not found on " + gameObject.name);
            }
        }

        public void StartWalking(float speed = 1f)
        {
            _animator.SetBool(IsWalkingHash, true);
        }

        public void StopWalking()
        {
            _animator.SetBool(IsWalkingHash, false);
        }

        public void TriggerAttack()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dead") ||
                _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit"))
            {
                return; 
            }
            _animator.SetTrigger(AttackTriggerHash);
        }

        public void StopAttacking()
        {
            _animator.ResetTrigger(AttackTriggerHash);
        }

        public void TriggerHit()
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Dead"))
            {
                return;
            }

            _animator.SetTrigger(HitTriggerHash);
        }

        
        public void TriggerDie()
        {
            _animator.SetTrigger(DieTriggerHash);
        }

        public bool CanAttack()
        {
            var state = _animator.GetCurrentAnimatorStateInfo(0);
            return (state.IsName("Idle") || state.IsName("Walk")) && !state.IsName("Attack") && !state.IsName("Hit") &&
                   !state.IsName("Dead");
        }

        public bool IsHitted()
        {
            return _animator.GetCurrentAnimatorStateInfo(0).IsName("Hit");
        }
    }
}