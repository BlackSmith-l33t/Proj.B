using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public ParticleSystem particleSystem;

    bool isTouch = false;


    BoxCollider boxCollider;
    Animator anim;

    IEnumerator BoxChecker()
    {
        yield return new WaitForSeconds(0.1f);

        if (isTouch)
        {
            
        }
    }

    
    private void Awake()
    {
        anim = GetComponent<Animator>();
        particleSystem = GetComponentInChildren<ParticleSystem>();
        boxCollider = GetComponent<BoxCollider>();
    }    

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {            
            anim.SetTrigger("Touch");
            Destroy(particleSystem);
            isTouch = true;
            Debug.Log("콰지직!");
            Destroy(boxCollider);

        }
    }

    //private void MoveBox()
    //{
    //    transform.position =  new
    //}

}
