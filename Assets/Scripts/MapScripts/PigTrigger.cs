using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigTrigger : MonoBehaviour {
    public static bool PigisTruePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        //if (other.CompareTag("Pig")) //태그 비교할땐 컴페어를 주로 사용할 것
        if(other.tag == "Pig")
        {
            PigisTruePlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bird" || other.tag == "Panguin")
        {
            PlayerMove.instance.moveSpeed = 10.0f;
            PigisTruePlayer = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        PigisTruePlayer = false;
    }
}
