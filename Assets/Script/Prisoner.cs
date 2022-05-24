using UnityEngine;
using Invector.vCharacterController;
using UnityEngine.Events;

public class Prisoner: MonoBehaviour
{
    public event UnityAction OnDie;
    public event UnityAction OnScore;
    public bool isAlive = true;

    vThirdPersonController playerController;

    int BombBoxLayer = 19;
    int enemy = 9;
    int damage = 10;

    private void Awake()
    {
        playerController = GetComponent<vThirdPersonController>();
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("플레이어 충돌 감지");
        if (other.gameObject.layer == BombBoxLayer)
        {
            isAlive = false;
            OnDie?.Invoke();
            Debug.Log("You Die");
            Debug.Log(playerController.currentHealth);            
        }
        else if (other.gameObject.layer == enemy)
        {
            playerController.currentHealth -= damage;
            Debug.Log(playerController.currentHealth);            
        }    
    }
}
   
