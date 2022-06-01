using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class HitPointSet : MonoBehaviour
{    
    public UnityEvent OnZombieDead;
    public GameObject zombie;

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
            zombie.GetComponent<Zombie_Info>().damage = 0;
            anim.SetBool("Die", true);
            anim.SetBool("IsTrace", false);
            navMeshAgent.enabled = false;
            Dead(); 
            Debug.Log("넥슬라이스!");           
        }
    }
}
