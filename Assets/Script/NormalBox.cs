using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBox : MonoBehaviour
{   
    public ParticleSystem glitterParticle;  

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {                      
            glitterParticle.Stop();                   
        }
    }
}
