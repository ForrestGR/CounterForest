using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Ein Array von Gegner-Prefabs zum Spawnen
    public float spawnDelay = 2f; // Verzögerung zwischen den Spawn-Vorgängen
    public float spawnRadius = 5f; // Radius für zufällige Spawn-Positionen um den Spawner
    public Transform playerTransform; // Referenz auf den Spieler, der verfolgt werden soll

    private void Start()
    {
        StartCoroutine(SpawnEnemies()); // Startet die Coroutine zum Spawnen der Gegner
    }

    IEnumerator SpawnEnemies()
    {
        while (true) // Eine Endlosschleife, die Gegner spawnen lässt
        {
            yield return new WaitForSeconds(spawnDelay); // Wartet für die festgelegte Verzögerungszeit

            Vector2 spawnPosition = Random.insideUnitCircle * spawnRadius + (Vector2)transform.position; // Erzeugt eine zufällige Position im definierten Radius um den Spawner
            GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];  // Wählt ein zufälliges Gegner-Prefab aus
            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);  // Spawnt den Gegner an der berechneten Position

            // Setzt die Spielerreferenz im Enemy-Skript
            enemy.GetComponent<Enemy>().player = playerTransform;
        }
    }
}
