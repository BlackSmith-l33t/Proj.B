using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class HitPointSet : MonoBehaviour
{    
    public UnityEvent OnZombieDead;

    Animator anim;
    NavMeshAgent navMeshAgent;

    private void Awake()
    {
        anim = GetComponentInParent<Animator>();
        navMeshAgent = GetComponentInParent<NavMeshAgent>();
    }

    private void Dead()
    {
        OnZombieDead.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            anim.SetBool("Die", true);
            anim.SetBool("IsRange", false);
            navMeshAgent.enabled = false;
            Dead(); 
            Debug.Log("넥슬라이스!");
        }
    }
}
