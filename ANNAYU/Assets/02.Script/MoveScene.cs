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
#if UNITY_EDITOR    //��ó����: ������ �� �̸� ����� �������ִ�.
        UnityEditor.EditorApplication.isPlaying = false;
        //����Ƽ���� �������� ���¿� ����

#else   //���忡�� ����
    Application.Quit();

#endif
    }
}
