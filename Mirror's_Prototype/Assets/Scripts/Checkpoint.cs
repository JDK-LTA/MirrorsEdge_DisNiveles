using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Checkpoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MARKER>())
        {
            other.GetComponent<MARKER>().NewCheckpoint(transform);
        }
    }
}
