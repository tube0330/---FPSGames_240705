using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;  //Scene 관련 기능을 사용한다. 그리고 그 뒤는 생략을 명시
using UnityEngine.UI;

public class UIManager : MonoBehaviour//(Mono~: 이 클래스가 유니티 엔진에 있는것들을 상속한다.)
{
    public Text FinalKillScore;
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        FinalKillScore = GameObject.Find("Text_KillScore").GetComponent<Text>();
        FinalKillScore.text = $"Kill Score {GameManager.KillCount.ToString()}";
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#else
    Application.Quit();

#endif
    }
}
