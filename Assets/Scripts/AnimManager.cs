using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimManager : MonoBehaviour {
    protected Animator avatar;

    // Use this for initialization
    void Start () {
        avatar = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () {
        //Debug.Log("PlayerMove.instance.moveSpeed : " + PlayerMove.instance.moveSpeed+ "\nPlayerMove.instance.changing : "+ PlayerMove.instance.changing);
        if (PlayerMove.instance.changing)
        {
            avatar.SetBool("Change", true);
        }
        else
        {
            avatar.SetBool("Change", false);
        }
        if (PlayerMove.instance.moveSpeed >= 11.0f)
        {
            avatar.SetFloat("Speed", PlayerMove.instance.moveSpeed);
        }
        else
        {
            avatar.SetFloat("Speed", 0.0f);
        }
        if (PlayerState.GoalIn)
        {
            avatar.SetBool("GoalIn", true);
            Vector3 temp = transform.eulerAngles;
            transform.eulerAngles = new Vector3(temp.x, 290.0f, temp.z);
        }
        else
        {
            avatar.SetBool("GoalIn", false);
        }
        //avatar.SetFloat("Speed", PlayerMove.instance.moveSpeed);
    }
}
