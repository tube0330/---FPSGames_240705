using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeCast : MonoBehaviour
{
    private Transform tr;
    private Ray ray;
    private RaycastHit hit;
    private float distance = 20f;
    public CrossHair C_cross;
    void Start()
    {
        C_cross = GameObject.Find("UI").transform.GetChild(3).GetComponent<CrossHair>();
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        ray = new Ray(tr.position, tr.forward);

        Debug.DrawRay(ray.origin, ray.direction * distance, Color.green);   //방향 * 거리 = Velocity

        if (Physics.Raycast(ray, out hit, distance, 1<<6))
        {
            C_cross.isGaze = true;
        }

        else C_cross.isGaze = false;
    }
}
