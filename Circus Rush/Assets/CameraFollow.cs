using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
  public Transform target;
  public Vector3 offset;

  void Update()
  {
      transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z) + offset;
  }
}
