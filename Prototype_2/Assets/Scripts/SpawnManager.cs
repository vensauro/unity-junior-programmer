using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  public GameObject[] animalPrefabs;
  private float spawnPosY = 0;
  private float spawnPosZ = 20;

  private float startDelay = 2;
  private float spawnInterval = 1.5f;
  // Start is called before the first frame update
  void Start()
  {
    InvokeRepeating("SpawnRandomAnimal", startDelay, spawnInterval);
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.S))
    {
      SpawnRandomAnimal();
    }

  }

  void SpawnRandomAnimal()
  {
    float spawnPosX = Random.Range(-20, 20);
    Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
    int animalIndex = Random.Range(0, animalPrefabs.Length);

    GameObject animalPrefab = animalPrefabs[animalIndex];
    Instantiate(animalPrefab, spawnPos, animalPrefab.transform.rotation);
  }
}
