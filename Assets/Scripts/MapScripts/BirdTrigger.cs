using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdTrigger : MonoBehaviour {
    public static bool BirdisTruePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bird")
        {
            BirdisTruePlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Panguin" || other.tag == "Pig")
        {
            PlayerMove.instance.moveSpeed = 10.0f;
            BirdisTruePlayer = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        BirdisTruePlayer = false;
    }
}
