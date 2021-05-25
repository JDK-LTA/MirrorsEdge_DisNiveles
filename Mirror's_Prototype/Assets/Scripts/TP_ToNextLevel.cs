using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_ToNextLevel : MonoBehaviour
{
    [SerializeField] private GameObject[] Levels;
    [SerializeField] private int nextLevel;
    [SerializeField] private bool doOnce=true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")&&doOnce)
        {
            for(int i = 0; i < Levels.Length; i++)
            {
                Levels[i].SetActive(false);
            }
            Levels[nextLevel].SetActive(true);
            doOnce = false;
        }
    }
}
