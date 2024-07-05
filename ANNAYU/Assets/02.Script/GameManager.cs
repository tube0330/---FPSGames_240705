using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance;
    public GameObject Skeleton;
    public Transform[] Points;
    private float timePrev;
    private int maxCount = 10;
    string SkeletonTag = "ENEMY";
    public Text KillText;
    public static int KillCount = 0;
    void Start()
    {
        Instance = this;
        Points = GameObject.Find("SpawnPoints").GetComponentsInChildren<Transform>();
    }

    void Update()
    {
        timePrev += Time.deltaTime;

        int enemyCount = GameObject.FindGameObjectsWithTag(SkeletonTag).Length;

        if (timePrev >= 3f)
        {
            if (enemyCount <= maxCount)
            {
                CreateEnemies();
            }
            timePrev = 0;
        }
    }

    void CreateEnemies()
    {
        int pos = Random.Range(1, Points.Length);
        Instantiate(Skeleton, Points[pos].position, Points[pos].rotation);

    }

    public void KillScore(int score)
    {
        KillCount += score;
        KillText.text = $"KILL <color=#ff0000>{KillCount.ToString()}</color>";
    }
}
