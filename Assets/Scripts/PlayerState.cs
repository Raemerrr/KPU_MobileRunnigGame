using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public static bool GoalIn = false;
    public static float finishTime = 0.0f;
    public GameObject mainCam = null;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("PlayManager.GoalInTime : "+ PlayManager.GoalInTime);
        //Debug.Log("finishTime : " + finishTime);
        //finishTime = PlayManager.GoalInTime;
        if (other.gameObject.name == "GoalInPoint")
        {
            Vector3 OgPosition = Vector3.zero;
            Vector3 OgRocation = Vector3.zero;

            //Debug.Log("실행됨 \nfinishTime : "+ finishTime);
            OgPosition = mainCam.transform.position;
            OgRocation = mainCam.transform.eulerAngles;
            mainCam.transform.position = new Vector3(OgPosition.x - 10.0f, OgPosition.y + 4.0f, OgPosition.z + 6.5f);
            mainCam.transform.eulerAngles = new Vector3(OgRocation.x + 10.0f, OgRocation.y, OgRocation.z);
            GoalIn = true;
            //ScoreManager.Instance().myScore += finishTime;
            //Time.timeScale = 0.0f;
        }
        //Debug.Log(other.gameObject.name == "GoalInPoint");
        //StopAllCoroutines();
        //Setting.SetActive(true);
    }
}
