using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyBox : MonoBehaviour
{   
    Box box;
    BoxCollider boxCollider;

    bool isDestroy = false;
 
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        box = GetComponentInParent<Box>();
        box.DestoryEvent.AddListener(ColliderDestroy);
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("OnCollisionEnter에서 충돌체 삭제");
    //    Destroy(boxCollider);
    //}
    public void ColliderDestroy()
    {
        Debug.Log("밑에 충돌체 삭제");
        Destroy(boxCollider);
    }
}
