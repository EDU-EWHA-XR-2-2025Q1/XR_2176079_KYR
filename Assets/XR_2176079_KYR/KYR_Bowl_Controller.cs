using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYR_Bowl_Controller : MonoBehaviour
{
    public GameObject UI_Controller;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            UI_Controller.GetComponent<KYR_UI_Controller>().Display_PutCounts();
            Destroy(other.gameObject);
        }
    }
}