﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_EasyPattern : MonoBehaviour
{
    Transform target;
   
    Vector3 direction;
    Vector3 destination;
    NavMeshAgent agent;

    bool isRange = false;
    int safeZone = 28;
    int player = 8;


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
        if (safeZone == other.gameObject.layer)
        {
            Debug.Log("safeZone!");
            transform.Rotate(new Vector3(0, -180f, 0));
            isRange = false;
            GetComponent<NavMeshAgent>().enabled = false;
            anin.SetBool("isTrace", isRange);
            Debug.Log(transform.rotation);
            return;
        }
        else if (player == other.gameObject.layer)
        {
            isRange = true;
            anin.SetTrigger("Attacking");
        }            
    }

    private void Awake()
    {      
        anin = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

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
            //Debug.Log("Hit Player");     
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 5f)), out forwardRange, 2f, LayerMask.GetMask("Default")))
        {         
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 3f, 5f)), new Color(0, 0, 1));
            //Quaternion rotation = Quaternion.Euler(0f, 180f, 0f);

            transform.Rotate(new Vector3(0, -180f, 0));              
            //Debug.Log("Hit Wall");
        }
        else
        {            
            Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 10f)), new Color(0, 1, 1));
            transform.Translate(0f, 0f, 0.6f * Time.deltaTime);                         
        }
    }
}
