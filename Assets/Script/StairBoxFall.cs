using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBoxFall : MonoBehaviour
{

    private void OnCollisionEnter(Collision other)
    {
        GetComponent<Rigidbody>().useGravity = true;
    }

}
