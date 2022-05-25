using UnityEngine;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine.Events;

public class PrisonerController: MonoBehaviour
{
    public event UnityAction OnDie;
    public event UnityAction OnScore;
    public bool isAlive = true;
    public bool m_IsGround = false;

    public Event OnDeath;

    vThirdPersonController prisonerController;
    
    int BombBoxLayer = 19;
    int enemy = 9;
    int damage = 50;

    float hp;   

    public bool isGround
    {
        get
        {
            return m_IsGround;
        }
        set
        {
            m_IsGround = value;
        }
    }

    private void Awake()
    {
        prisonerController = GetComponent<vThirdPersonController>();          
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("플레이어 충돌 감지");
        if (other.gameObject.layer == BombBoxLayer)
        {
            isAlive = false;
            prisonerController.currentHealth = 0.0f;
            OnDie?.Invoke();
            Debug.Log("You Die");
            Debug.Log(prisonerController.currentHealth);            
        }
        else if (other.gameObject.layer == enemy)
        {         
            hp = prisonerController.currentHealth -= damage;
            Debug.Log(hp);
            if (hp < 0.0f)
            {
                OnDie?.Invoke();
                Debug.Log("You Die");
                Debug.Log(hp);
            }       
        }      
    }  
}
   
