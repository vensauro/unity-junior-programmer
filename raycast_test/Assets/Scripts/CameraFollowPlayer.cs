using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
  public GameObject player;
  [SerializeField] private Vector3 offset = new Vector3(5, 19, -16);

  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    transform.position = player.transform.position + offset;
  }
}
