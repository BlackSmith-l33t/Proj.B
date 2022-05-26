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
            //explsionParticle.Play();
            glitterParticle.Stop();
            isTouch = true;
            Debug.Log("콰지직!");
            Destroy(boxCollider);
            Destroy(box, 8);

            // TODO : 박스가 깨지면 포션이 생긴다.

            Instantiate(potion, transform.position, Quaternion.identity);

        }

    }


}
