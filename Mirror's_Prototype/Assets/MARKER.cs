using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MARKER : MonoBehaviour
{
    [SerializeField] private Transform lastCheckpoint;

    public void NewCheckpoint(Transform newCheckpoint)
    {
        lastCheckpoint.position=newCheckpoint.position;
        lastCheckpoint.rotation = transform.rotation;
    }

    public void TPToLastCheckpoint()
    {
        transform.position = lastCheckpoint.position;
        transform.rotation = lastCheckpoint.rotation;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
