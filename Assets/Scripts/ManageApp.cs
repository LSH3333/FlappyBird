using UnityEngine;
using System;

public class ManageApp : MonoBehaviour
{
    public static ManageApp singleton;

    private string nickName;
    private int bestScore;

    private int[] _scores = new int[10];
    private string[] _names = new string[10];

    private string _defaultScores = "0,0,0,0,0,0,0,0,0,0";
    private string _defalutNames = "N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A,N/A";

    public int BestScore // property
    {
        get { return bestScore; }
        set { bestScore = value;  }
    }

    public string NickName // property
    {
        get { return nickName; }
        set { nickName = value;  }
    }

    private void Awake()
    {
        // singleton
        if(singleton == null)
        {
            singleton = this;
            Load();
            DontDestroyOnLoad(gameObject);
        }
        else if(singleton != this)
        {
            Destroy(gameObject);
        }
        
    }

    private void Load()
    {
        bestScore = PlayerPrefs.GetInt("Best Score", 0);
        nickName = PlayerPrefs.GetString("Nick name", "none");

        string scores = PlayerPrefs.GetString("Scores", _defaultScores);
        string names = PlayerPrefs.GetString("Names", _defalutNames);
        
        // names set
        string[] tmps = names.Split(',');
        string[] tmpi = scores.Split(',');
        for(int i = 0; i < 10; i++)
        {
            _names[i] = tmps[i];
            _scores[i] = Convert.ToInt32(tmpi[i]);
        }
    }

    public void Save()
    {
        PlayerPrefs.SetInt("Best Score", bestScore);
        PlayerPrefs.SetString("Nick Name", nickName);

        string scores = "" + _scores[0];
        string names = _names[0];
        for(int i = 1; i < 10; i++)
        {
            scores += "," + _scores[i];
            names += "," + _names[i];
        }
        PlayerPrefs.SetString("Scores", scores);
        PlayerPrefs.SetString("Names", names);
    }

    public void SetData(int index, string name, int score)
    {
        _names[index] = name;
        _scores[index] = score;
    }

    // out: 참조를 통해 인자를 전달 가능. 2개의 데이터를 반환해야하기 때문에 return대신 out 키워드 사용
    public void GetData(int index, out string out_name, out int out_score)
    {
        out_name = _names[index];
        out_score = _scores[index];
    }

    public string getRankString()
    {
        string res = "";
        for(int i = 0; i < 10; i++)
        {
            res += string.Format("{0:D2}. {1} ({2:#,0})\n",
                i + 1, _names[i], _scores[i]);
        }
        return res;
    }

    public void updateBestScore(int score)
    {
        bestScore = (bestScore < score) ? score : bestScore;
    }
}
