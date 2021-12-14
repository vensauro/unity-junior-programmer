using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  private Rigidbody enemyRb;
  private GameObject player;
  public float speed = 3;

  private PlayerController playerController;
  void Start()
  {
    enemyRb = GetComponent<Rigidbody>();
    player = GameObject.Find("Player");
    playerController = GameObject.Find("Player").GetComponent<PlayerController>();
  }

  // Update is called once per frame
  void Update()
  {
    if (transform.position.y < -10)
    {
      Destroy(gameObject);
    }
    Vector3 lookDirection = (player.transform.position - transform.position).normalized;
    if (playerController.gameOver) return;

    enemyRb.AddForce(lookDirection * speed);
  }
}
