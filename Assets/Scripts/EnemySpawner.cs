using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
    public enum SpawnType { FixedPoints, RandomRadius }

    [Header("General Configuration")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform treeTarget; // Transform Pohon di Tengah
    [SerializeField] private float spawnInterval = 2f;
    [SerializeField] private SpawnType spawnType = SpawnType.FixedPoints;

    [Header("Option A: Fixed Spawn Points (Titik Merah)")]
    [SerializeField] private Transform[] spawnPoints;

    [Header("Option B: Random Radius Outer Circle (Area Acak)")]
    [SerializeField] private float minRadius = 8f; // Jarak minimal di luar garis biru
    [SerializeField] private float maxRadius = 10f;

    private void Start() {
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine() {
        while (true) {
            yield return new WaitForSeconds(spawnInterval);
            SpawnEnemy();
        }
    }

    private void SpawnEnemy() {
        if (enemyPrefab == null || treeTarget == null) return;

        Vector3 spawnPosition = Vector3.zero;

        if (spawnType == SpawnType.FixedPoints && spawnPoints.Length > 0) {
            // Pilih salah satu titik spawn secara acak dari array
            int randomIndex = Random.Range(0, spawnPoints.Length);
            spawnPosition = spawnPoints[randomIndex].position;
        } else if (spawnType == SpawnType.RandomRadius) {
            // Menghasilkan arah acak 360 derajat di luar radius tertentu (untuk 2D: X & Y)
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float randomDistance = Random.Range(minRadius, maxRadius);

            spawnPosition = treeTarget.position + new Vector3(randomDirection.x, randomDirection.y, 0f) * randomDistance;

            // Catatan: Jika proyek Unity versi 3D (X & Z), ubah baris di atas menjadi:
            // spawnPosition = treeTarget.position + new Vector3(randomDirection.x, 0f, randomDirection.y) * randomDistance;
        }

        // Spawn musuh di posisi yang ditentukan
        GameObject spawnedEnemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

        // Kirim referensi pohon ke script musuh
        EnemyMovement movement = spawnedEnemy.GetComponent<EnemyMovement>();
        if (movement != null) {
            movement.SetTarget(treeTarget);
        }
    }
}