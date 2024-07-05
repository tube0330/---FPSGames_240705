using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.VisualScripting.Member;

public class FireCtrl : MonoBehaviour
{
    [Header("컴포넌트들")]
    public GameObject bulletPrefab;
    public Transform firePos;
    public Animation fireAni;
    public AudioClip fireClip;
    public AudioSource fireSource;
    public ParticleSystem muzzleFlash;

    [Header("각종 변수들")]
    public float fireTime;
    public HandleCtrl hc;
    public int bulletCnt = 0;
    public bool reload = false;
    void Start()
    {
        hc = this.gameObject.GetComponent<HandleCtrl>();
        fireSource = GetComponent<AudioSource>();

        fireTime = Time.time;

        muzzleFlash.Stop();
    }


    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time - fireTime > 0.5f)
            {
                if (!hc.Run)
                    Fire();

                fireTime = Time.time;
            }
        }
    }

    void Fire()
    {
        bulletCnt++;

        Instantiate(bulletPrefab, firePos.position, firePos.rotation);

        fireSource.PlayOneShot(fireClip, 1.0f);
        fireAni.Play("fire");

        muzzleFlash.Play();

        Invoke("MuzzleFlashDisable", 0.03f);

        if (bulletCnt == 10)
            StartCoroutine(Reload());
    }

    IEnumerator Reload()
    {
        reload = true;
        fireAni.Play("pump1");

        yield return new WaitForSeconds(0.5f);

        bulletCnt = 0;
        reload = false;
    }

    void MuzzleFlashDisable()
    {
        muzzleFlash.Stop();
    }
}
