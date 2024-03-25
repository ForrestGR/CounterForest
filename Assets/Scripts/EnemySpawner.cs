using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Ein Array von Gegner-Prefabs zum Spawnen
    public float spawnDelay = 2f; // Verz�gerung zwischen den Spawn-Vorg�ngen
    public float spawnRadius = 5f; // Radius f�r zuf�llige Spawn-Positionen um den Spawner





    private void Start()
    {
        StartCoroutine(SpawnEnemies()); // Startet die Coroutine zum Spawnen der Gegner
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Eine Endlosschleife, die Gegner spawnen l�sst
        {
            yield return new WaitForSeconds(spawnDelay); // Wartet f�r die festgelegte Verz�gerungszeit
            
            Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius + (Vector2)transform.position;   // Erzeugt eine zuf�llige Position im definierten Radius um den Spawner
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];  // W�hlt ein zuf�lliges Gegner-Prefab aus
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);  // Spawnt den Gegner an der berechneten Position
        }
    }
}