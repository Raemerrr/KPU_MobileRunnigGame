using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingManager : MonoBehaviour {

    public GameObject Setting = null; //세팅 메인 창
    public GameObject OptionSettingobj = null; //옵션 창
    public GameObject ChangeButtonobj = null; //체인지 버튼 위치
    private Vector3 ChangeButtonTemp = Vector3.zero;


    public static bool gameSetting = false;
    public static bool OptionSetting = false;
    private bool ButtonChange = false;

    private void Start()
    {
        gameSetting = false;
        ChangeButtonTemp = ChangeButtonobj.transform.position;
    }

    public void ChangeButtonPosition()
    {
        float ChangeButtonTempX = 100.0f;
        ButtonChange = !ButtonChange; //실행할 때 마다 반대값을 넣어준다.
        if (ButtonChange == true)
        {
            ChangeButtonobj.transform.position = new Vector3(ChangeButtonTempX, ChangeButtonTemp.y , ChangeButtonTemp.z);
        }
        else if (ButtonChange == false)
        {
            ChangeButtonobj.transform.position = ChangeButtonTemp;
        }
    }

    public void mainSettingEnter()
    {
        gameSetting = !gameSetting; //실행할 때 마다 반대값을 넣어준다.
        if (gameSetting == true)
        {
            Time.timeScale = 0.0f;
            //StopAllCoroutines();
            Setting.SetActive(true);
        }
        else
        {
            Time.timeScale = 1.0f;
            Setting.SetActive(false);
            OptionSettingobj.SetActive(false);
        }
    }
    public void mainSettingExit()
    {
        gameSetting = !gameSetting; //실행할 때 마다 반대값을 넣어준다.
        Time.timeScale = 1.0f;
        Setting.SetActive(false);
        OptionSettingobj.SetActive(false);

    }
    public void optionSettingExit()
    {
        OptionSettingobj.SetActive(false);
    }
    public void optionSettingEnter()
    {
        OptionSettingobj.SetActive(true);
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameSetting = !gameSetting; //실행할 때 마다 반대값을 넣어준다.
            if (gameSetting == true)
            {
                Time.timeScale = 0.0f;
                //StopAllCoroutines();
                Setting.SetActive(true);
            }
            else
            {
                Time.timeScale = 1.0f;
                Setting.SetActive(false);
                OptionSettingobj.SetActive(false);
            }
        }
    }
}
