using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Invector.vCharacterController;
using Invector.vCamera;
using UnityEngine.Events;

public class Player: MonoBehaviour
{
    public event UnityAction OnDie;
    public event UnityAction OnScore;
    public bool isAlive = true;       

    int BombBoxLayer = 19;   
 
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("플레이어 충돌 감지");
        if (!(other.gameObject.layer == BombBoxLayer))
        {
            return;
        }

        isAlive = false;
        OnDie?.Invoke();
        Debug.Log("You Die");
    }
}
   
