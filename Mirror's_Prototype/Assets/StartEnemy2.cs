using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartEnemy2 : MonoBehaviour
{
    private bool hasStarted = false;
    [SerializeField] private Animator enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && !hasStarted)
        {
            hasStarted = true;
            enemy.SetTrigger("Start");
        }
    }
}
