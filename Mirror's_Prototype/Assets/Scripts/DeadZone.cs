using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DeadZone : MonoBehaviour
{
    private void Start()
    {
        Rigidbody rb;
        rb = GetComponent<Rigidbody>();
        if (!rb)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }
        rb.useGravity = false;
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        GetComponent<BoxCollider>().isTrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<MARKER>().TPToLastCheckpoint();
        }
    }
}
