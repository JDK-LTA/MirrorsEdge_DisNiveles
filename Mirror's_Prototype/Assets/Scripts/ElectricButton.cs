using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElectricButton : MonoBehaviour
{
    [SerializeField] private Text text;
    [SerializeField] private GameObject electrified, nonElectrified, pointsParent;
    private bool canPress = false, wasPressed = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!wasPressed && other.GetComponent<MARKER>())
        {
            canPress = true;
            text.gameObject.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (!wasPressed && other.GetComponent<MARKER>())
        {
            canPress = false;
            text.gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        if (canPress && Input.GetKeyDown(KeyCode.E) && !wasPressed)
        {
            electrified.SetActive(false);
            nonElectrified.SetActive(true);
            pointsParent.SetActive(true);
            wasPressed = true;
            canPress = false;
            text.gameObject.SetActive(false);
            
            enabled = false;
        }
    }
}
