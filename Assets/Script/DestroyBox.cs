using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DestroyBox : MonoBehaviour
{   
    BombBox box;
    BoxCollider boxCollider;
     
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        box = GetComponentInParent<BombBox>();
        box.DestoryEvent.AddListener(ColliderDestroy);
    }

    public void ColliderDestroy()
    {
        Debug.Log("밑에 충돌체 삭제");
        Destroy(boxCollider);
    }
}
