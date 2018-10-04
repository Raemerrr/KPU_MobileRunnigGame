using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageManager : MonoBehaviour {
    //씬 전환시 씬이름을 얻어오기 위한 함수
    //public static string OpenScenename = string.Empty;
    //public static string nowScenename = string.Empty;

    //다른 스크립트에서 사용하기위해 싱글톤 화
    public static StageManager instance;

    //로딩 슬라이더 바
    public Slider roadingValue = null;
    public GameObject roadingSlider = null;
    //float fTime = 0f;
    AsyncOperation async;

    void Start()
    {
        StageManager.instance = this;
    }
    public void TitleSceneLoad()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadingProgress("Title"));
    }
    public void Stage1SceneLoad()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadingProgress("Stage1"));
    }
    public void Stage2SceneLoad()
    {
        Time.timeScale = 1.0f;
        StartCoroutine(LoadingProgress("Stage2"));
    }
    //private void Update()
    //{
    //    fTime += Time.deltaTime;
    //    //slider.value = fTime;

    //    if (fTime >= 5)
    //    {
    //        async.allowSceneActivation = true;
    //    }
    //    async.allowSceneActivation = true; //Change Scene
    //    roadingSlider.SetActive(false);
    //}

    IEnumerator LoadingProgress(string Scenename)
    {
        roadingSlider.SetActive(true);
        async = SceneManager.LoadSceneAsync(Scenename);
        //async.allowSceneActivation = false;
        
        while (async.progress < 0.9f)
        {
            roadingValue.value = async.progress;
            //Debug.Log("Loading : " + async.progress + "%");
            yield return null;
        }
        while (!async.isDone)
        {
            yield return new WaitForEndOfFrame();
        }
        async.allowSceneActivation = true; //Change Scene
        roadingSlider.SetActive(false);

        //Debug.Log("Loading Complete");
    }
}
