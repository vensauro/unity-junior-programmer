using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastTest : MonoBehaviour
{

  void Update()
  {
    var maxDistance = 100f;
    var ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
    RaycastHit hitinfo;
    if (Physics.Raycast(ray, out hitinfo, maxDistance))
    {
      Debug.Log("Hit Something");
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
    }
    else
    {
      Debug.Log("Hit Nothing");
      Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * maxDistance, Color.green);
    }
  }
}
