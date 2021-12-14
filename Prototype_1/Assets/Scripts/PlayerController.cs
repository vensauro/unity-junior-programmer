using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

  [SerializeField] float speed;
  [SerializeField] float rpm;
  [SerializeField] private float horsePower = 0;
  [SerializeField] float turnSpeed = 30.0f;
  private float horizontalInput;
  private float forwardInput;
  private Rigidbody playerRb;

  [SerializeField] GameObject centerOfMass;
  [SerializeField] TextMeshProUGUI speedometerText;
  [SerializeField] TextMeshProUGUI rpmText;

  [SerializeField] List<WheelCollider> allWheels;
  [SerializeField] int wheelsOnGround;

  [SerializeField] GameObject[] cameras;
  private int actualCamera;

  private void Start()
  {
    playerRb = GetComponent<Rigidbody>();
    playerRb.centerOfMass = centerOfMass.transform.position;
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.V))
    {
      cameras[actualCamera].gameObject.SetActive(false);

      if (actualCamera < cameras.Length - 1) actualCamera++;
      else actualCamera = 0;

      cameras[actualCamera].gameObject.SetActive(true);
    }
  }


  void FixedUpdate()
  {
    //Get Input from player
    horizontalInput = Input.GetAxis("Horizontal");
    forwardInput = Input.GetAxis("Vertical");

    if (IsOnGround())
    {

      //Move the vehicle forward
      //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput);
      playerRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
      //Turning the vehicle
      transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * horizontalInput);

      //print speed
      speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f);
      speedometerText.SetText("Speed: " + speed + " km/h");

      //print RPM
      rpm = Mathf.Round((speed % 30) * 40);
      rpmText.SetText("RPM: " + rpm);
    }

    bool IsOnGround()
    {
      wheelsOnGround = 0;
      foreach (WheelCollider wheel in allWheels)
      {
        if (wheel.isGrounded)
        {
          wheelsOnGround++;
        }
      }
      if (wheelsOnGround == 4)
      {
        return true;
      }
      else
      {
        return false;
      }
    }
  }
}
