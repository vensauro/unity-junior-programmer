using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float speed = 20;
  [SerializeField] private float turnSpeed = 50;
  private NavMeshAgent agent;
  void Start()
  {
    agent = GetComponent<NavMeshAgent>();
  }

  // Update is called once per frame
  void Update()
  {
    var horizontal = Input.GetAxis("Horizontal");
    var vertical = Input.GetAxis("Vertical");

    transform.Translate(Vector3.forward * Time.deltaTime * speed * vertical);
    transform.Translate(Vector3.right * Time.deltaTime * speed * horizontal);

    var rotation = Vector3.up * Time.deltaTime * turnSpeed;
    if (Input.GetKey(KeyCode.Q))
    {
      transform.Rotate(rotation * -1);
    }
    else if (Input.GetKey(KeyCode.E))
    {
      transform.Rotate(rotation);
    }

    if (Input.GetMouseButtonDown(0))
    {
      var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hitinfo;
      if (Physics.Raycast(ray, out hitinfo))
      {
        agent.destination = hitinfo.point;
        // Debug.Log("Hit Something");
        // Debug.DrawRay(ray.origin, ray.direction * hitinfo.distance, Color.red);
      }
    }
  }
}
