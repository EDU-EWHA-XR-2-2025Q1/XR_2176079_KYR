using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYR_Pick_Controller : MonoBehaviour
{
    int clickCounter = 0;
    public GameObject UI;
    bool isInTheArea = false;

    public void Add_Click(GameObject Clone)
    {
        if (isInTheArea)
        {
            clickCounter++;
            Destroy(Clone);
            UI.GetComponent<KYR_UI_Controller>().Display_PickCounts(clickCounter);
            GameManager.I.heartsLeft--;


        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "FPSController")
        {
            isInTheArea = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "FPSController")
        {
            isInTheArea = false;
        }
    }
}
