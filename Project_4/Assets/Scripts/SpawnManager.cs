using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject enemyPrefab;
  public GameObject powerupPrefab;
  private float spawnRange = 9;
  public int enemyCount;
  public int waveNumber = 1;
  private PlayerController playerController;
  void Start()
  {
    InvokeRepeating("SpawnPowerups", 2, Random.Range(10, 30));
    playerController = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  Vector3 GenerateSpawnPosition()
  {
    float spawnPosX = Random.Range(-spawnRange, spawnRange);
    float spawnPosZ = Random.Range(-spawnRange, spawnRange);
    return new Vector3(spawnPosX, 0, spawnPosZ);
  }
  void SpawnEnemyWave(int enemiesToSpawn)
  {
    for (int i = 0; i < enemiesToSpawn; i++)
      Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
  }

  void SpawnPowerups()
  {
    Instantiate(powerupPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
  }



  void Update()
  {
    if (playerController.gameOver) return;
    enemyCount = FindObjectsOfType<Enemy>().Length;
    if (enemyCount == 0)
    {
      SpawnEnemyWave(waveNumber * 2);
      waveNumber++;
    }
  }
}
