using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private Rigidbody playerRb;
  public float jumpForce = 10f;
  public float gravityModifier;
  public bool isOnGround = true;

  public bool gameOver;

  private Animator playerAnim;
  public ParticleSystem explosionParticle;
  public ParticleSystem dirtParticle;
  public AudioClip jumpSound;
  public AudioClip crashSound;
  private AudioSource playerAudio;


  void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    playerAnim = GetComponent<Animator>();
    playerAudio = GetComponent<AudioSource>();
    Physics.gravity *= gravityModifier;
  }

  // Update is called once per frame
  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
    {
      playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
      isOnGround = false;
      playerAnim.SetTrigger("Jump_trig");
      dirtParticle.Stop();
      playerAudio.PlayOneShot(jumpSound, 1.0f);
    }
  }

  void OnCollisionEnter(Collision collision)
  {
    if (collision.gameObject.CompareTag("Ground"))
    {
      isOnGround = true;
      dirtParticle.Play();
    }
    else if (collision.gameObject.CompareTag("Obstacle"))
    {
      explosionParticle.Play();
      gameOver = true;
      Debug.Log("Game Over");
      playerAnim.SetBool("Death_b", true);
      playerAnim.SetInteger("DeathType_int", 1);
      dirtParticle.Stop();
      playerAudio.PlayOneShot(crashSound, 1.0f);
    }
  }
}