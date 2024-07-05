using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonCtrl : MonoBehaviour
{
    [Header("컴포넌트")]
    public NavMeshAgent find;
    public AudioClip skelClip;
    public AudioSource skelSource;
    public Animator animator;
    public Transform Player;
    public Transform Skeleton;
    public SkeletonDamage damage;


    [Header("변수")]
    public float attackDist = 2.5f;
    public float traceDist = 20.0f;
    void Start()
    {
        find = GetComponent<NavMeshAgent>();
        Skeleton = GetComponent<Transform>();
        Player = GameObject.FindWithTag("Player").transform;
        animator = GetComponent<Animator>();
        skelSource = GetComponent<AudioSource>();
        damage = GetComponent<SkeletonDamage>();
    }

    void Update()
    {
        float distance = Vector3.Distance(Skeleton.position, Player.position);

        if (damage.isDie || Player.GetComponent<FPSDamage>().isPlayerDie)
            return;

        if (distance <= attackDist)
        {
            animator.SetBool("isAttack", true);
            find.isStopped = true;
        }

        else if (distance <= traceDist)
        {
            animator.SetBool("isTrace", true);
            animator.SetBool("isAttack", false);

            find.isStopped = false;
            find.destination = Player.position;
        }

        else
        {
            animator.SetBool("isTrace", false);
            find.isStopped = false;
        }
    }

    public void SwordSfx()
    {
        skelSource.clip = skelClip;
        skelSource.PlayDelayed(0.25f);
    }

    public void PlayerDeath()
    {
        GetComponent<Animator>().SetTrigger("PlayerDie");
    }
}
