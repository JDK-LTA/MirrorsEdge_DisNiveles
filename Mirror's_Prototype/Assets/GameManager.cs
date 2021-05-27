using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int bags = 0;
    public Text bagsText;
    private float timeToHoldR = 1.5f, timeToHoldT = 2f;
    private float auxT = 0, auxR = 0;
    private bool pressedR = false, pressedT = false;

    public void AddBag()
    {
        bags++;
        bagsText.text = "Bags: " + bags + "/3";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            pressedR = true;
        }
        else if (Input.GetKeyUp(KeyCode.R))
        {
            auxR = 0;
            pressedR = false;
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            pressedT = true;
        }
        else if (Input.GetKeyUp(KeyCode.T))
        {
            auxT = 0;
            pressedT = false;
        }


        if (pressedR)
        {
            auxR += Time.deltaTime;
            if (auxR >= timeToHoldR)
            {
                auxR = 0;
                pressedR = false;
                FindObjectOfType<MARKER>().TPToLastCheckpoint();
            }
        }
        if (pressedT)
        {
            auxT += Time.deltaTime;
            if (auxT >= timeToHoldT)
            {
                auxT = 0;
                pressedT = false;
                SceneManager.LoadScene(0);
            }
        }
    }
}
