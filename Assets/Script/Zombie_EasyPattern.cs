﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_EasyPattern : MonoBehaviour
{   
    public Transform target;

    float m_fDir = 0.5f;
    float m_fSpeed = 10f;
    float m_fRange = 0f;
    float m_fDiff = 0f;

    Vector3 direction;
    Vector3 destination;
    NavMeshAgent agent;

    bool isRange = false;
    bool isAttackRange = false;

    Rigidbody rigid;   
    Transform targetTransform;
    Animator anin;      

    IEnumerator CheckRange()
    {
        while(true)
        {
            yield return new WaitForSeconds(0.1f);

            if (isRange)
            {
                anin.SetBool("isTrace", isRange);
                GetComponent<NavMeshAgent>().enabled = true;
                destination = target.position;
                agent.destination = destination;                
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        anin.SetTrigger("Attacking");
    }

    private void Awake()
    {       
        rigid = GetComponent<Rigidbody>();
        anin = GetComponent<Animator>();
    }

    private void Start()
    {
        direction = transform.position;
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        anin.SetBool("isTrace", isRange);        

        StartCoroutine(CheckRange());        
    }

    private void FixedUpdate()
    {
        RaycastHit forwardRange;       

        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 10f)), out forwardRange, 10f, LayerMask.GetMask("Player")))
        {
            Debug.DrawRay(transform.position, Vector3.forward, new Color(1, 0, 0));            
            isRange = true;          
            Debug.Log("Hit Player");     
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 5f)), out forwardRange, 2f, LayerMask.GetMask("Default")))
        {         
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 3f, 5f)), new Color(0, 0, 1));
            Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

            transform.Rotate(new Vector3(0, -180f, 0));              
            Debug.Log("Hit Wall");
        }
        else
        {            
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 10f)), new Color(0, 1, 0));
            transform.Translate(0f, 0f, 0.6f * Time.deltaTime);                         
        }
    }
}
