using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SkeletonDamage : MonoBehaviour
{
    public CapsuleCollider skelCol;
    public Rigidbody skelRb;
    public Animator skelAni;
    public GameObject bloodEffect;
    public BoxCollider boxCol;
    public MeshRenderer meshRend;

    public string PlayerTag = "Player";
    public string BulletTag = "BULLET";
    public string HitTrigger = "HitTrigger";
    public string Dietrigger = "DieTrigger";
    public bool isDie = false;

    [Header("UI")]
    public Image HPBar;
    public int maxHP = 100;
    public int HPInitiate = 0;
    public Text HPText;

    void Start()
    {
        skelCol = GetComponent<CapsuleCollider>();
        skelRb = GetComponent<Rigidbody>();
        skelAni = GetComponent<Animator>();
        HPBar.color = Color.green;
        HPInitiate = maxHP;
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(PlayerTag))
        {
            skelRb.mass = 800f;
            skelRb.isKinematic = false;
            skelRb.freezeRotation = true;
        }

        else if (col.gameObject.CompareTag(BulletTag))
        {
            HitInfo(col);

            HPInitiate -= col.gameObject.GetComponent<BulletCtrl>().damage;
            HPBar.fillAmount = (float)HPInitiate / (float)maxHP;
            HPText.text = ($"HP: <color=#ff0000>{HPInitiate.ToString()}</color>");

            if (HPBar.fillAmount <= 0.3f)
                HPBar.color = Color.red;

            else if (HPBar.fillAmount <= 0.5f)
                HPBar.color = Color.yellow;

            if (HPInitiate <= 0)
            {
                SkeletonDie();
            }

        }
    }
    private void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag(PlayerTag))
            skelRb.mass = 75f;
    }

    private void HitInfo(Collision col)
    {
        Destroy(col.gameObject);
        skelAni.SetTrigger(HitTrigger);

        Vector3 hitPos = col.transform.position;
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, hitPos.normalized);

        var blood = Instantiate(bloodEffect, hitPos, rot);
        Destroy(blood, Random.Range(0.8f, 1.2f));
    }
    void SkeletonDie()
    {
        skelAni.SetTrigger(Dietrigger);
        skelCol.enabled = false;
        skelRb.isKinematic = true;
        isDie = true;
        GameManager.Instance.KillScore(1);
    }
    public void boxColEnable()
    {
        boxCol.enabled = true;  //enabled: È°¼ºÈ­
        meshRend.enabled = false;
    }

    public void boxColDisable()
    {
        boxCol.enabled = false;
        meshRend.enabled = false;
    }
}
