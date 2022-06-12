using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Zombie_EasyPattern : MonoBehaviour
{
    Transform target;

    Vector3 direction;
    Vector3 destination;
    NavMeshAgent agent;
    HitPointSet hitPointSet;

    bool isRange = false;
    bool isDead = false;
    int safeZoneLayer = 28;
    int playerLayer = 8;
    int DefaultLayer = 9;

    public void Dead()
    {
        isDead = true;
        this.enabled = false;
        Debug.Log("빠른 좀비 죽음");
    }

    Animator anin;
    IEnumerator CheckRange()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (isRange && !isDead)
            {
                anin.SetBool("IsTrace", isRange);
                GetComponent<NavMeshAgent>().enabled = true;
                destination = target.position;
                agent.destination = destination;
                Debug.Log("네비 발동");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (safeZoneLayer == other.gameObject.layer)
        {
            Debug.Log("safeZone!");
            transform.Rotate(new Vector3(0, -180f, 0));
            isRange = false;
            GetComponent<NavMeshAgent>().enabled = false;
            anin.SetBool("IsTrace", isRange);
            Debug.Log(transform.rotation);
            return;
        }
        else if (playerLayer == other.gameObject.layer)
        {
            isRange = true;
            anin.SetTrigger("Attacking");
        }     
    }

    private void Awake()
    {
        anin = GetComponent<Animator>();
        hitPointSet = GetComponentInChildren<HitPointSet>();
        hitPointSet.OnZombieDead.AddListener(Dead);
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Start()
    {
        direction = transform.position;
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
        anin.SetBool("IsTrace", isRange);

        StartCoroutine(CheckRange());
    }

    private void FixedUpdate()
    {
        RaycastHit forwardRange;

        if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 10f)), out forwardRange, 10f, LayerMask.GetMask("Player")))
        {
            //Debug.DrawRay(transform.position, Vector3.forward, new Color(1, 0, 0));
            isRange = true;
            //Debug.Log("Hit Player");     
        }
        else if (Physics.Raycast(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 5f)), out forwardRange, 2f, LayerMask.GetMask("Default")))
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 3f, 5f)), new Color(0, 0, 1));
            transform.Rotate(new Vector3(0, -180f, 0));
            //Debug.Log("Hit Wall");
        }
        else
        {
            //Debug.DrawRay(transform.position, transform.TransformDirection(new Vector3(0f, 1.5f, 10f)), new Color(0, 1, 1));
            transform.Translate(0f, 0f, 0.6f * Time.deltaTime);
        }
    }
}
