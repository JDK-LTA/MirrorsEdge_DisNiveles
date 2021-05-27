using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDeactivator : MonoBehaviour
{
    [SerializeField] private GameObject tutorialParent;
    [SerializeField] private Animator robberPartOne;
    private bool aux = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !aux)
        {
            aux = true;
            tutorialParent.SetActive(false);
            robberPartOne.SetTrigger("Start");
        }
    }
}
