using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KYR_Heart_Controller : MonoBehaviour {

    public GameObject PickController;
    private void OnMouseDown()
    {
        PickController.GetComponent<KYR_Pick_Controller>().Add_Click(gameObject);
    }
}
