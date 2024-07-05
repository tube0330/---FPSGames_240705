using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class HandleCtrl : MonoBehaviour
{
    public Animation Player;
    public Light FlashLight;
    public AudioClip FlashSound;
    public AudioSource FlashSource;
    public bool Run = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            FlashLight.enabled = !FlashLight.enabled;
            FlashSource.PlayOneShot(FlashSound, 1.0f);
        }

        GunCtrl();
    }
    private void GunCtrl()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            Player.Play("running");
            Run = true;
        }

        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            Player.Play("runStop");
            Run = false;
        }
    }
}
