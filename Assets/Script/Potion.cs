using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potion : MonoBehaviour
{
    public PotionData data;
    public GameObject potion;

    private void OnCollisionEnter(Collision other)
    {        
        if (other.gameObject.tag.Equals("Player"))
        {              
            Destroy(potion);
        }
    }
}
