using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BombBox : MonoBehaviour
{
    public GameObject box;
    public ParticleSystem glitterParticle;
    public ParticleSystem explsionParticle;    
    public UnityEvent DestoryEvent;

    bool isTouch = false;

    BoxCollider boxCollider;
    Animator anim;

    private void DestroyAlarm()
    {
        DestoryEvent.Invoke();
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();     
        boxCollider = GetComponent<BoxCollider>();  
    }

    private void OnCollisionEnter(Collision other)
    {      
        if (other.gameObject.tag.Equals("Player"))
        {
            DestroyAlarm();
            anim.SetTrigger("Touch");
            explsionParticle.Play();
            glitterParticle.Stop();           
            isTouch = true;
            Debug.Log("콰지직!");
            Destroy(boxCollider);
            Destroy(box, 8);
        }    
    }
}
