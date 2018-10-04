using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class PlayManager : MonoBehaviour {
    public InputField UserName_Field = null;
    public static string Username = null;
    string strMsg = string.Empty;
    string nowScene = string.Empty;
    //스톱워치 함수
    public float time;
    private float s;
    private int m;
    string text = string.Empty;
    string BestText = string.Empty;

    //플레이어 종료
    //PlayerState playerState = null;
    public static float GoalInTime = 0.0f;

    //GoalInPoint
    //public GameObject GoalInPoint = null;

    //StageManager 불러오기
    public StageManager stageManager;

    //
    public Scene scene;
    public Text strText;


    string bestUser;
    float bestScore;
    float bestS = 0.0f;
    int bestM = 0;
    void Start()
    {
        bestUser = ScoreManager.Instance().bestUser;
        bestScore = ScoreManager.Instance().bestScore;
        nowScene = SceneManager.GetActiveScene().name;
        //Debug.Log("nowScene : " + nowScene);
    }

    //로딩 프로세스
    //IEnumerator LoadingProgress()
    //{
    //    AsyncOperation async = SceneManager.LoadSceneAsync(nowScene);
    //    while (async.progress < 0.9f)
    //    {
    //        Debug.Log("Loading : " + async.progress + "%");
    //        yield return null;
    //    }
    //    while (!async.isDone)
    //    {
    //        yield return new WaitForEndOfFrame();
    //    }
    //    async.allowSceneActivation = true; //Change Scene
    //    Debug.Log("Loading Complete");
    //}


    //Stage1 로드 시작
    public void CheckFieldText()
    {

        Username = (string)UserName_Field.text;
        if (Username == string.Empty)
        {
            strMsg = "사용자 이름을 입력하시오....";
            return;
        }
        Time.timeScale = 1.0f;
        StageManager.instance.Stage1SceneLoad();
    }
    //Stage1 로드 끝

    //Stage2 로드 시작
    public void CheckFieldText2()
    {

        Username = (string)UserName_Field.text;
        if (Username == string.Empty)
        {
            strMsg = "사용자 이름을 입력하시오....";
            return;
        }
        //snowScene = "Stage2";
        Time.timeScale = 1.0f;
        StageManager.instance.Stage2SceneLoad();
    }
    //Stage2 로드 끝
    
    private void Update()
    {
        if (PlayerState.GoalIn)
        {
            ScoreManager.Instance().myScore = time;
            if (bestScore > time)
            {
                Debug.Log("최고기록 실행");
                strText.text = "\n\n*********************\n최고기록입니다.!\n*********************";
            }
            else
            {
                Debug.Log("최고도달 실패 실행");
                strText.text = "\n\n최고기록 도전 실패.!!";
            }
            return;
        }
        //strText.text = strMsg;
        bestS = bestScore % 60;
        bestM = (int)bestScore / 60;
        BestText = string.Format("{0:D2} : {1:00.00}", bestM, bestS);

        if (nowScene == "Title")
        {
            //GUI.Box(new Rect(Screen.width - 250, 20, 200, 50), strMsg);
            //GUI.Box(new Rect(30, 20, 200, 30), strMsg);
            strMsg = "시작 대기중....";
            strText.text = strMsg;
        }
        else if (nowScene != "Title")
        {
            //GUI.Box(new Rect(30, 20, 130, 80), "최고 선수 : " + bestUser + "\n최고 점수 : " + bestScore + "\n선수 이름 : " + Username + "\n현재 점수 : " + myScore);
            //GUI.Box(new Rect(30, 20, 130, 150), "최고 선수 : \n" + bestUser + "\n최고 점수 : \n" + BestText + "\n------------------------" + "\n선수 이름 : \n" + Username + "\n현재 시간 : " + text);
            strMsg =  "최고 선수 : " + bestUser + "\n최고 점수 : " + BestText +  "\n\n현재 선수 : " + Username + "\n현재 시간 : " + text;
            strText.text = strMsg;
        }
        

        
        time += Time.deltaTime;
        s = time % 60;
        m = (int)time / 60;
        //string text = string.Format("{0:0.0}time {1:0.}m {2:0.000}s", m, m,s);
        text = string.Format("{0:D2} : {1:00.00}", m, s);
        //Debug.Log(text);
    }
}
