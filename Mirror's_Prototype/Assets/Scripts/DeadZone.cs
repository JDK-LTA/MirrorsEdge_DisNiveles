using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MARKER>())
        {
            other.GetComponent<MARKER>().TPToLastCheckpoint();
        }
    }
}
