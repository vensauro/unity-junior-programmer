using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
  [SerializeField] private List<GameObject> gameObjects;

  void Start()
  {
    int obstaclesQuantity = Random.Range(9, 20);
    for (int i = 0; i < obstaclesQuantity; i++)
    {
      int gameObjectIndex = Random.Range(0, gameObjects.Count);
      var gameObject = gameObjects[gameObjectIndex];
      var location = new Vector3(Random.Range(-9, 0), 0, (i + 1) * 8);
      var obj = Instantiate(gameObject, location, gameObject.transform.rotation);
      obj.transform.SetParent(this.transform);
    }
  }


}
