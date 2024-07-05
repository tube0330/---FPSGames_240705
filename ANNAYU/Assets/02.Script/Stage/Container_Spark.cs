using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class Container_Spark : MonoBehaviour
{
    public GameObject sparkPrefab;
    public AudioSource sparkSource;
    public AudioClip sparkClip;

    private void Start()
    {
        sparkSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "BULLET")
        {
            Destroy(col.gameObject);
            sparkSource.PlayOneShot(sparkClip, 1.0f);

            var spark = Instantiate(sparkPrefab, col.transform.position, Quaternion.identity);

            Destroy(spark, 2.0f);
        }
    }
}
