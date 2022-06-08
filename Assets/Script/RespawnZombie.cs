using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnZombie : MonoBehaviour
{
    public GameObject zombieType1;
    public GameObject zombieType2;
    public GameObject secretDoor;
    public bool isGateOpen = false;

    int m_iSlowZombieMaxCount = 30;
    int m_iFastZombieMaxCount = 3;    

    IEnumerator ERespawnZombie()
    {
        //for (int i = 0; i < m_iSlowZombieMaxCount; i++) 
        //{           
        //    Instantiate(zombieType1, transform.position, Quaternion.identity);            
        //    yield return new WaitForSeconds(10f);
        //}

        for (int i = 0; i < m_iFastZombieMaxCount; i++)
        {
            Instantiate(zombieType2, transform.position, Quaternion.identity);            
            yield return new WaitForSeconds(2f);
        }

        secretDoor.SetActive(false);
        isGateOpen = true;
        StopAllCoroutines();
    }    

    private void Awake()
    {
        StartCoroutine(ERespawnZombie());
    }
}
