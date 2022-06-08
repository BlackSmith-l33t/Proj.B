using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBox_DropBox : MonoBehaviour
{
    public BombBox bombBox;    

    bool m_PlayerOnBox;

    IEnumerator DropBox()
    {
        yield return new WaitForSeconds(0.2f);
        
        if (m_PlayerOnBox)
        {
            bombBox.GetComponent<Rigidbody>().useGravity = true;
        }        
    }

    private void OnCollisionEnter(Collision collision)
    {
        m_PlayerOnBox = true;
        StartCoroutine(DropBox());
    }
}
