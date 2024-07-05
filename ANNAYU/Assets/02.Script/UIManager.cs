using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;  //Scene ���� ����� ����Ѵ�. �׸��� �� �ڴ� ������ ���
using UnityEngine.UI;

public class UIManager : MonoBehaviour//(Mono~: �� Ŭ������ ����Ƽ ������ �ִ°͵��� ����Ѵ�.)
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
