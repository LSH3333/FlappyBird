using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageTitle : MonoBehaviour
{
    public Text textName, textBscore, textBtnName, textIF;
    public GameObject pInputField;
    private bool status = false; // InputField 상태값, show/hide
    // nickname이 설정 되었는지 여부, 닉네임 설정이 안된 상태에선 게임 시작 불가능 하도록 
    private bool nicknameSaved = false;  

    private void Start()
    {
        // 로드된 값들을 바탕으로 UI상의 문자열을 변경한다
        textName.text = string.Format(
            "NICKNAME : {0}", ManageApp.singleton.NickName); // singleton property

        textBscore.text = string.Format(
            "BEST SCORE : {0}", ManageApp.singleton.BestScore); // singleton property

        // InputField는 시작함과 동시에 안보이게 처리
        pInputField.SetActive(false);
    }

    // "Name" 버튼 클릭 핸들러
    public void onClickName()
    {
        status = !status; // InputField의 상태값 전환
        textBtnName.text = (status) ? "Okay" : "Name"; // 상태값에 따라 버튼 문자열 변경
        pInputField.SetActive(status); // status 상태에 따라 전환

        if(status == false && textIF.text != "")
        {
            // 입력된 nickname 문자열을 저장 처리
            ManageApp.singleton.NickName = textIF.text;
            ManageApp.singleton.Save();
            nicknameSaved = true;

            // UI 상의 nickname 문자열을 업데이트
            textName.text = string.Format("nickname : {0}", textIF.text);
            textIF.text = "";
        }
    }

    // Start 버튼 클릭 핸들러
    public void onClickStart()
    {
        if (!nicknameSaved) return;
        SceneManager.LoadScene("Game");
    }
}
