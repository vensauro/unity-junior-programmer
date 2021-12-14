﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
  public GameObject dogPrefab;
  public float coolDown = 0;

  // Update is called once per frame
  void Update()
  {
    // On spacebar press, send dog
    if (Input.GetKeyDown(KeyCode.Space) && coolDown > 1.5)
    {
      Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
      coolDown = 0;
    }
    coolDown = coolDown + Time.deltaTime;
  }


}
