using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CrossHair : MonoBehaviour
{
    Transform tr;
    Image crossHairImg;
    float startTime;
    float duration = 0.25f;
    float minSize = 0.7f;
    float maxSize = 1.8f;

    Color originColor = new Color(1f, 1f, 1f, 0.8f);
    Color gazeColor = Color.red;
    public bool isGaze = false;
    void Start()
    {
        tr = transform;
        crossHairImg = GetComponent<Image>();
        startTime = Time.time;
        tr.localScale = Vector3.one * minSize;
    }

    void Update()
    {
        if (isGaze)
        {
            float time = (Time.time - startTime) / duration;
            tr.localScale = Vector3.one * Mathf.Lerp(minSize, maxSize, time);
            crossHairImg.color = gazeColor;
        }

        else
        {
            tr.localScale = Vector3.one * minSize;
            crossHairImg.color = originColor;
            startTime = Time.time;
        }
    }
}
