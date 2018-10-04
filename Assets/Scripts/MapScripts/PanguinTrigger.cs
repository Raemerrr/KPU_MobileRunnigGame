using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanguinTrigger : MonoBehaviour {
    public static bool PanguinisTruePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Panguin")
        {
            PanguinisTruePlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bird" || other.tag == "Pig")
        {
            PlayerMove.instance.moveSpeed = 10.0f;
            PanguinisTruePlayer = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PanguinisTruePlayer = false;
    }
}
