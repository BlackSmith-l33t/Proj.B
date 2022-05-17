using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie_EasyPattern : MonoBehaviour
{   
    public Transform target;

    int m_iDir = 1;

    float m_fSpeed = 10f;
    float m_fRange = 0f;
    float m_fDiff = 0f;

    Vector3 destination;
    NavMeshAgent agent;

    bool isRange = false;
    bool isAttackRange = false;

    Rigidbody rigid;   
    Transform targetTransform;
    Animator anin;      

    private void Awake()
    {       
        rigid = GetComponent<Rigidbody>();
        anin = GetComponent<Animator>();
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        destination = agent.destination;
    }

    private void FixedUpdate()
    {
        RaycastHit trace;
        RaycastHit attack;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out trace, 50f, LayerMask.GetMask("Player")))
        {
            Debug.DrawRay(transform.position, Vector3.forward * 15f, new Color(1, 0, 0));
            Debug.Log("Did Hit");
        }
        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 50f, new Color(0, 1, 0));
            Debug.Log("Did not Hit");
        }
    }

    private void Update()
    {
        //rigid.AddForce(new Vector3(0f, 0f, 0.5f), ForceMode.Impulse);
        //anin.SetFloat("velocity", rigid.velocity.z);

        if (Vector3.Distance(destination, target.position) > 1.0f)
        {
            destination = target.position;
            agent.destination = destination;
        }

        // 감지 범위
        // 공격 발동 범위
        // 벽, 같은 좀비 충돌시 방향 변경      
    }




}
