using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrackdownManager : MonoBehaviour
{
    public static bool isTruePlayer = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("충돌시작 테그 이름 : " + other.tag);
        if (other.tag == "Pig")
        {
            isTruePlayer = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Bird" || other.tag == "Panguin")
        {
            PlayerMove.instance.moveSpeed = 10.0f;
            isTruePlayer = false;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        isTruePlayer = false;
    }
}
