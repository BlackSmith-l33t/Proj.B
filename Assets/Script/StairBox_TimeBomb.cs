using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Invector.vCharacterController;

public class StairBox_TimeBomb : MonoBehaviour
{
    public GameObject box;
    public ParticleSystem glitterParticle;
    public ParticleSystem explsionParticle;
    public UnityEvent DestoryEvent;
    public event UnityAction OnDie;

    bool isTouch = false;
    
    Rigidbody rigid;
    BoxCollider boxCollider;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider>();
        rigid = GetComponentInChildren<Rigidbody>();       
    }

    IEnumerator TimeBomb(float time)
    {
        yield return new WaitForSeconds(time);
                
        if (isTouch)
        {
            rigid.useGravity = true;
            DestroyAlarm();
            OnDie?.Invoke();
            anim.SetTrigger("Touch");
            explsionParticle.Play();
            glitterParticle.Stop();
            Debug.Log("콰지직!");
            Destroy(boxCollider);
            Destroy(box, 5);
        }        
    }

    private void DestroyAlarm()
    {
        DestoryEvent.Invoke();
    } 

    private void OnCollisionExit(Collision collisionInfo)
    {
        isTouch = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {           
            isTouch = true;
            StartCoroutine(TimeBomb(2.0f));           
        }
    }
}
