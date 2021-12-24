using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    /* ZTK was here
     * Kodları yazarken isimlendirmeden daha önemli bir konu olan "indentation"
     * Yani hizalama... Hizalama standartları çok önemlidir, özellikle kodun okunabilirliği açısından.
     * Bu konuya da dikkat etmeni öneririm.
     */
  public Transform target;
  public Vector3 offset;

  void Update()
  {
      transform.position = new Vector3(transform.position.x, transform.position.y, target.position.z) + offset;
  }
}
