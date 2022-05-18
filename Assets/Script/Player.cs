using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed;

    Rigidbody rigid;

    public int damage = 50;
    public int health = 50;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

}
   
