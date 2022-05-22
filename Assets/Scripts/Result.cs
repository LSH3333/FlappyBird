using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public Text _txtRank; // 1~10위 까지의 랭크정보 문자열 출력

    private void Start()
    {
        SetResult();
        ManageApp.singleton.Save(); // 랭크정보를 저장한다

        _txtRank.text = ManageApp.singleton.getRankString();  // 랭크정보를 string 형태로 가져옴
    }

    void SetResult()
    {
        // best score update
        ManageApp.singleton.updateBestScore(ManagerGame.inst.Score);

        var list_name = new ArrayList();
        var list_score = new ArrayList();
        string out_name;
        int out_score;
        for(int i = 0; i < 10; i++) // 기존 데이터 모두 리스트로 가져옴
        {
            ManageApp.singleton.GetData(i, out out_name, out out_score);
            list_name.Add(out_name);
            list_score.Add(out_score);
        }

        for(int i = 0; i < 10; i++)
        {
            // 항목을 순차적으로 탐색하면서 현재의 스코어를 삽입할 위치를 찾는다
            if(ManagerGame.inst.Score > (int) list_score[i])
            {
                list_name.Insert(i, ManageApp.singleton.NickName);
                list_score.Insert(i, ManagerGame.inst.Score);
                break; // 랭크 데이터로 삽입했기 때문에 탐색 종료
            }
        }

        // 새롭게 구성된 랭크 데이터 저장
        for(int i = 0; i < 10; i++)
        {
            ManageApp.singleton.SetData(i, (string)list_name[i], (int)list_score[i]);
        }
    }
}
