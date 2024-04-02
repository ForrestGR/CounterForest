using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float spawnDelay = 2f;
    public Vector2 spawnRectangleSize = new Vector2(10f, 10f); // Größe des Rechtecks für das Spawnen
    public float minDistanceToPlayer = 5f; // Mindestabstand zum Spieler
    public Transform playerTransform;
      

    private void Start()
    {
        StartCoroutine(SpawnEnemies()); // Startet die Coroutine zum Spawnen der Gegner
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay);

            Vector2 spawnPosition = GenerateSpawnPosition();
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity); // Diese Zeile speichert das instanziierte Objekt in einer lokalen Variable
    
            // Hier versuchen wir, das Enemy-Skript des instanziierten Objekts zu erhalten
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript != null) // Überprüfen, ob das Skript gefunden wurde
            {
                enemyScript.player = playerTransform; // Setzt die Spielerreferenz im Enemy-Skript
            }
            else
            {
                Debug.LogWarning("Enemy script not found on spawned enemy prefab, ensure it's attached.");
            }
        }
    }



    Vector2 GenerateSpawnPosition()
    {
        Vector2 spawnPosition;
        do
        {
            float spawnX = Random.Range(-spawnRectangleSize.x / 2, spawnRectangleSize.x / 2);
            float spawnY = Random.Range(-spawnRectangleSize.y / 2, spawnRectangleSize.y / 2);
            spawnPosition = new Vector2(spawnX, spawnY) + (Vector2)playerTransform.position;
        }
        while (Vector2.Distance(spawnPosition, playerTransform.position) < minDistanceToPlayer);

        return spawnPosition;
    }
}
