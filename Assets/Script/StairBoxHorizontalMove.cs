using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairBoxHorizontalMove : MonoBehaviour
{
    Transform transform;

    bool m_On = false;
    bool m_Increase = true;

    float startPosZ;
    
    
    private void Awake()
    {
        transform = GetComponent<Transform>();
        startPosZ = transform.position.z;
    }

    private void OnCollisionEnter(Collision other)
    {
        m_On = true;
    }


    private void Update()
    {
        if (m_On)
        {
            if (transform.position.z < startPosZ - 4.0f)
            {
                m_Increase = true;
            }
            else if (transform.position.z > startPosZ + 4.0f)
            {
                m_Increase = false;
            }

            float offset = (m_Increase == true ? 0.1f : -0.1f);
            float px = transform.position.z + offset;
            transform.position = new Vector3(transform.position.x, transform.position.y, px);
        }        
    }
}
