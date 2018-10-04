using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour {

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Enter Object : " + other.gameObject.name);
        //Debug.Log("Enter other.name : " + other.name);
        if (other.gameObject.name.Contains("Player"))
        {
            other.gameObject.transform.position = new Vector3(0.0f, 10.0f, -3.0f);
        }
        else if (other.gameObject.name.Contains("Item"))
        {
            Destroy(other.gameObject);
        }
    }
}
