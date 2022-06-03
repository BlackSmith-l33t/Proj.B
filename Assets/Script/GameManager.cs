using System.Collections;
using System;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;
using Invector.vCamera;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [Header("Player")]
    public GameObject prisoner;
    public vThirdPersonController personController;
    public vThirdPersonCamera mainCamera;
    public PrisonerController prisonerController;

    [Header ("Death State")]    
    public GameObject deathUI;
    public GameObject HUD;
    public Image fadeOutImage;
    public vRagdoll deathMotion;
    public StairBox_TimeBomb timeBomb;

    [Header("Respawn Setting Information")]  
    public Scene scene;
    public GameObject RespawnPoint1;
    public GameObject RespawnPoint2;
    public GameObject RespawnPoint3;
    public GameObject RespawnPoint4;
    public GameObject RespawnPoint5; 
    public GameObject RespawnPoint6;

    bool isPlaying = false;

    private void Awake()
    {
        timeBomb.OnDie += Death;
        prisoner.GetComponent<PrisonerController>().OnDie += Death;
        personController.onChangeHealth.AddListener(OnChangeHealth);        
        StartCoroutine(GameStart());

        scene = SceneManager.GetActiveScene();
        Debug.Log("Name: " + scene.name);

        if (scene.name == "Repeat")
        {
            Debug.Log("Start Posion Set");            
            prisoner.transform.position = SetRespawnPoint().position;
        }        
    }

    IEnumerator StartFadeInOut()
    {
        isPlaying = true;

        yield return new WaitForSeconds(4.0f);

        deathUI.SetActive(true);
        HUD.SetActive(false);
        mainCamera.GetComponentInChildren<GraySceleEffect>().enabled = true;

        yield return new WaitForSeconds(2.0f);

        Color fadeColor = fadeOutImage.color;

        for (int i = 0; i < 100; i++)
        {
            float f = i / 100.0f;
            fadeColor.a = f + 0.5f;
            fadeOutImage.color = fadeColor;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(3.3f);
        SceneManager.LoadScene("Repeat");
    }

    IEnumerator GameStart()
    {  
        while (true)
        {
            yield return new WaitForSeconds(0.1f);

            if (Input.anyKey)
            {
                Debug.Log("GameisOn!");
                GameisOn();
                break;
            }
        }        
    }

    public void Death()
    {
        prisoner.GetComponent<vThirdPersonController>().currentHealth = -1.0f;
        if (isPlaying == true) 
        {            
            Debug.Log("fade In 실행 중");
            return;
        }

        Debug.Log("fade out 호출");       
        StartCoroutine("StartFadeInOut");
    }
    public void OnChangeHealth(float health)
    {
        if (health <= 0)
        {
            Death();
            StartCoroutine("StartFadeInOut");
            Debug.Log("You Die");            
        }
    }

    private void GameisOn()
    {            
        personController.isImmortal = false;
        deathMotion.keepRagdolled = false;       
    }

    private Transform SetRespawnPoint()
    {
        //random startPoint settting   
        Transform position = RespawnPoint1.transform;
        System.Random randomPoint = new System.Random();

        int pointNum;
        pointNum = randomPoint.Next(1, 6);
        Debug.Log("randomNumber : " + pointNum);

        switch (pointNum)
        {
            case 1:
                position = RespawnPoint1.transform;
                break;
            case 2:
                position = RespawnPoint2.transform;
                break;
            case 3:
                position = RespawnPoint3.transform;
                break;
            case 4:
                position = RespawnPoint4.transform;
                break;
            case 5:
                position = RespawnPoint5.transform;
                break;
            case 6: 
                position = RespawnPoint6.transform;
                break;
            default:
                break;
        }
        return position;
    }
}
