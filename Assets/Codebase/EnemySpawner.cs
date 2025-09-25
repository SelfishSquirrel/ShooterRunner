using System.Collections;
using UnityEngine;

namespace Codebase
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private GameObject zombiePrefab; // Префаб зомби
        [SerializeField] private float minSpawnInterval = 2f; // Минимальный интервал спавна
        [SerializeField] private float maxSpawnInterval = 5f; // Максимальный интервал спавна

        private void Start()
        {
            // Проверяем, задан ли префаб
            if (zombiePrefab == null)
            {
                Debug.LogError("Zombie Prefab is not assigned in the Inspector!");
                return;
            }

            // Запускаем корутину спавна
            StartCoroutine(SpawnZombies());
        }

        private IEnumerator SpawnZombies()
        {
            while (true)
            {
                // Генерируем случайный интервал
                float randomInterval = Random.Range(minSpawnInterval, maxSpawnInterval);

                // Спавним зомби
                Instantiate(zombiePrefab, transform.position, transform.rotation);

                // Ждем случайный интервал перед следующим спавном
                yield return new WaitForSeconds(randomInterval);
            }
        }
    }
}