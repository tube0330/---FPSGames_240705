using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FPSDamage : MonoBehaviour
{
    public Image HPBar;
    public Text HPText;
    public int HP = 0;
    public int HPMax = 100;
    public string skeleton = "SKELETON";
    public bool isPlayerDie = false;
    public GameObject BlackScreen;
    void Start()
    {
        HP = HPMax;
        HPBar.color = Color.green;
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag(skeleton))
        {
            HP_Info();

            if (HP <= 0)
                PlayerDie();
        }
    }

    private void HP_Info()
    {
        HP -= 50;
        HP = Mathf.Clamp(HP, 0, 100);
        HPBar.fillAmount = (float)HP / (float)HPMax;

        if (HPBar.fillAmount <= 0.3)
            HPBar.color = Color.red;

        else if (HPBar.fillAmount <= 0.5)
            HPBar.color = Color.yellow;

        HPText.text = $"<color=#ff0000>HP</color> {HP.ToString()}";
    }

    void PlayerDie()
    {
        BlackScreen.SetActive(true);
        isPlayerDie = true;

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("ENEMY");

        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].gameObject.SendMessage("PlayerDeath", SendMessageOptions.DontRequireReceiver);
        }

        Invoke("MoveToNextScene", 2.0f);    //죽자마자 3.0초 후에 MoveToNextScene 함수 호출
    }

    void MoveToNextScene()
    {
        SceneManager.LoadScene("03.EndScene");
    }
}
