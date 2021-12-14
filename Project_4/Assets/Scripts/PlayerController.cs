using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float speed = 5.0f;
  private Rigidbody playerRb;
  private GameObject focalPoint;
  public bool hasPowerUp;

  private float powerupStrength = 15.0f;
  public GameObject powerupIndicator;
  public bool gameOver = false;
  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    focalPoint = GameObject.Find("Focal Point");
  }

  // Update is called once per frame
  void Update()
  {
    float forwardInput = Input.GetAxis("Vertical");
    playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
    powerupIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    if (transform.position.y < -3)
    {
      gameOver = true;
    }
  }

  private void OnTriggerEnter(Collider other)
  {
    if (other.CompareTag("Powerup"))
    {
      hasPowerUp = true;
      powerupIndicator.SetActive(true);
      Destroy(other.gameObject);
      StartCoroutine(PowerupCountdownRoutine());
    }
  }

  IEnumerator PowerupCountdownRoutine()
  {
    yield return new WaitForSeconds(7);
    hasPowerUp = false;
    powerupIndicator.SetActive(false);
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
    {

      Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
      Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position);

      Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);
      enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
    }
  }


}
