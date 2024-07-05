using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("02.PlayScene");
    }

    public void QuitGame()
    {
#if UNITY_EDITOR    //전처리기: 컴파일 전 미리 기능이 정해져있다.
        UnityEditor.EditorApplication.isPlaying = false;
        //유니티에서 편집중인 상태에 종료

#else   //빌드에서 종료
    Application.Quit();

#endif
    }
}
