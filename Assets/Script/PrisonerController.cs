using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Invector.vCharacterController;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PrisonerController: MonoBehaviour
{    public enum PotionList
    {
        HP_POTION = 22,
        SP_POTION = 23,
        JUMP_POTION = 24
    }

    public event UnityAction OnDie;   
    public Event             OnDeath;
    public MountainOfStupid  mountain;
   
    public bool isAlive = true;
    public bool m_IsGround = false;
    public bool readyNextLevel = false;

    vThirdPersonController prisonerController;
    vThirdPersonInput      personInput;

    // Layer Number
    int BombBoxLayer = 19;
    int enemy        = 9;
    int gate         = 29;    

    // Prisoner Info  
    float   jumpPower;
    float   jumpPowerMax = 30f;
    float   hp;   

    private void Awake()
    {
        prisonerController = GetComponent<vThirdPersonController>();
        personInput = GetComponent<vThirdPersonInput>();
        mountain.OnMountain += BeOnMountainHalfWay;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (0 == other.gameObject.layer)
        {
            return;
        }

        //if (other.gameObject.layer == nextLevelBox)
        //{
        //    readyNextLevel = true;
        //    SceneManager.LoadScene("Level_3");
        //}

        Debug.Log("플레이어 충돌 감지");
        if (other.gameObject.layer == BombBoxLayer)
        {
            isAlive = false;
            prisonerController.currentHealth = -1.0f;
            OnDie?.Invoke();
            Debug.Log("You Die");
            Debug.Log(prisonerController.currentHealth);
            personInput.lockInput = true;
        }
        else if (other.gameObject.layer == enemy)
        {
            hp = prisonerController.currentHealth -= other.gameObject.GetComponent<Zombie_Info>().damage;
            Debug.Log(hp);
            if (hp < 0.0f)
            {
                OnDie?.Invoke();
                Debug.Log("You Die");
                Debug.Log(hp);
            }       
        }
        else if (other.gameObject.layer == (int)PotionList.HP_POTION)
        {
            Debug.Log("빨간 약");
            prisonerController.currentHealth = 100.0f;
        }
        else if (other.gameObject.layer == (int)PotionList.SP_POTION)
        {
            Debug.Log("초록 약");
            prisonerController.currentStamina = 100.0f;
        }
        else if (other.gameObject.layer == (int)PotionList.JUMP_POTION)
        {
            Debug.Log("파란 약");
            prisonerController.jumpHeight = 53.0f;            
        }
      
    }  

    public void BeOnMountainHalfWay()
    {
        jumpPower = prisonerController.jumpHeight = 30f;
        mountain.OnMountain -= BeOnMountainHalfWay;
        mountain.OnMountain += BeOnTop;
    }

    public void BeOnTop()
    {
        prisonerController.jumpHeight = 12f;
    }
}
   
