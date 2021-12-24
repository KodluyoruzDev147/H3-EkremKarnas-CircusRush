using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDetector : MonoBehaviour
{
    [SerializeField]
    RotateAroundPivot pivot;
    void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Collectable"))
        {
            Destroy(col.gameObject);
            pivot.CollectPin();
        }

        else if(col.CompareTag("Obstacle"))
        {
            pivot.DropPin();
        }
    }
}
