using UnityEngine;

namespace Codebase
{
    public class WeaponRecoil : MonoBehaviour
    {
        [SerializeField]
        private Vector3 recoilAmount = new Vector3(0f, 0f, -0.5f); // Величина отдачи (напр., назад по Z)

        [SerializeField] private float recoilSpeed = 0.1f; // Скорость отдачи
        [SerializeField] private float returnSpeed = 0.2f; // Скорость возврата

        private Vector3 initialPosition; // Исходная позиция оружия
        private Vector3 targetPosition; // Целевая позиция для SmoothDamp
        private Vector3 velocity = Vector3.zero; // Для SmoothDamp
        private bool recoiling = false; // Флаг отдачи
        private bool recovering = false; // Флаг возврата

        private void Start()
        {
            initialPosition = transform.localPosition; 
            targetPosition = initialPosition;
        }

        private void Update()
        {
            transform.localPosition = Vector3.SmoothDamp(
                transform.localPosition,
                targetPosition,
                ref velocity,
                recoiling ? recoilSpeed : returnSpeed
            );

            if (recovering && Vector3.Distance(transform.localPosition, initialPosition) < 0.01f)
            {
                recovering = false;
            }
        }

        public void ApplyRecoil()
        {
            recoiling = true;
            recovering = false;
            targetPosition = initialPosition + recoilAmount; 
            
            Invoke(nameof(StartRecovery), recoilSpeed * 2f);
        }

        private void StartRecovery()
        {
            recoiling = false;
            recovering = true;
            targetPosition = initialPosition;
        }
    }
}