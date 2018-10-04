using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitManager : MonoBehaviour {
    //public void OnApplicationQuit()
    //{
    //    Application.CancelQuit();
    //    System.Diagnostics.Process.GetCurrentProcess().Kill();  //프로세스까지 아에 죽이기
    //    Application.Quit();
    //}
    public void OnApplicationQuit()
    {
        Application.Quit();
        //Debug.Log("종료!...");
    }
}
