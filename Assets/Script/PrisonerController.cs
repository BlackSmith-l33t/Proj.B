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
    public MountainStart     mountainStart;
    public EndGame           endGame;
    public string[]          texts = { };
   
    public bool isAlive = true;
    public bool m_IsGround = false;
    bool isFinished = false;

    vThirdPersonController prisonerController;
    vThirdPersonInput      personInput;

    // Layer Number
    int defaultLayer = 0;
    int ground       = 21;
    int wall         = 13;
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
        mountainStart.OnMountainStart += EnterMountain;
        mountain.OnMountain += BeOnMountainWay;
        endGame.OnFnishied += FinalFall;
    }

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");
        if (defaultLayer == other.gameObject.layer)
        {            
            return;
        }

        if (ground == other.gameObject.layer || wall == other.gameObject.layer)
        {
            m_IsGround = true;
            prisonerController.jumpHeight = 12f;
            Debug.Log("불로불사 해제");
            prisonerController.isImmortal = false;
            return;
        }      

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

    public void BeOnMountainWay()
    {
        jumpPower = prisonerController.jumpHeight = 30f;
        mountain.OnMountain -= BeOnMountainWay;
        mountain.OnMountain += BeOnTop;
    }

    public void BeOnTop()
    {
        prisonerController.jumpHeight = 12f;
        prisonerController.isImmortal = false;
    }

    public void EnterMountain()
    {
        Debug.Log("불로불사");
        prisonerController.isImmortal = true;
        jumpPower = prisonerController.jumpHeight = 53f;
    }

    public void FinalFall()
    {
        prisonerController.isImmortal = false;
    }
}
   
