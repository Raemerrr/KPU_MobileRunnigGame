using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    static ScoreManager _instance = null;
    void Awake()
    {
        if (_instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        _instance = this;
    }

    public static ScoreManager Instance()
    {
        return _instance;
    }
    string _bestUser = string.Empty;
    float _bestScore = 0;
    float _myScore = 0;
    public string bestUser
    {
        get
        {
            return _bestUser;
        }
    }
    public float bestScore
    {
        get
        {
            return _bestScore;
        }
    }
    public float myScore
    {
        get
        {
            return _myScore;
        }
        set
        {
            _myScore = value;
            if (_myScore <= _bestScore) //현재기록이 최고기록과 같거나 더 빠르면 갱신
            {
                _bestUser = PlayManager.Username;
                _bestScore = _myScore;
                SaveBestScore();
            }
        }
    }
    void SaveBestScore()
    {
        PlayerPrefs.SetString("최고 선수 : ", _bestUser);
        PlayerPrefs.SetFloat("최고 점수 : ", _bestScore);
    }
    void LoadBestScore()
    {
        _bestUser = PlayerPrefs.GetString("최고 선수 : ",string.Empty);
        _bestScore = PlayerPrefs.GetFloat("최고 점수 : ", 0);
    }
    void Start()
    {
        if (_instance == null)
            _instance = this;
        else
            Destroy(gameObject);

        LoadBestScore();
    }
}
