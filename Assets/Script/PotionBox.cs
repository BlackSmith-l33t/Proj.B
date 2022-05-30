using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PotionBox: MonoBehaviour
{
    public GameObject box;
    public ParticleSystem glitterParticle;   
    public UnityEvent DestoryEvent;
    public Potion potion;

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
            glitterParticle.Stop();
            isTouch = true;
            Debug.Log("콰지직!");
            Destroy(boxCollider);
            Destroy(box, 8);
            GetComponent<RespawnZombie>().enabled = false;

            if (!(null == potion))
            {
                Instantiate(potion, transform.position, Quaternion.identity);
            }           
        }
    }

    
}
