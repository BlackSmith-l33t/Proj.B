using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator anim;
    public GameObject startPoint;


    private void Awake()
    {
        anim = GetComponent<Animator>();
        
    }


    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            transform.position = startPoint.transform.position;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Box"))
        {
            //anim.SetBool("IsDead", true);
        }
    }
}
   
