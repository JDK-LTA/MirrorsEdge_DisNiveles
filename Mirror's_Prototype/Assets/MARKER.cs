using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MARKER : MonoBehaviour
{
    
    private Transform lastCheckpoint;

    public void NewCheckpoint(Transform newCheckpoint)
    {
        lastCheckpoint.position=newCheckpoint.position;
        lastCheckpoint.rotation = transform.rotation;
    }

    public void TPToLastCheckpoint()
    {
        if (lastCheckpoint)
        {
            transform.position = lastCheckpoint.position;
            transform.rotation = lastCheckpoint.rotation;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        GameObject go = Instantiate(new GameObject(), transform.position, transform.rotation);
        lastCheckpoint = go.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
