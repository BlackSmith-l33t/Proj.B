using System.Collections;
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

    [Header("Game Start Initialization")]
    public GameObject startPoint;
    public Light prisonerLight;    

    bool isPlaying = false;           

    private void Awake()
    {             
        //prisoner.GetComponent<PrisonerController>().OnDie += Death;
        personController.onChangeHealth.AddListener(OnChangeHealth);
        StartCoroutine(GameStart());
    }

    IEnumerator StartFadeInOut()
    {
        isPlaying = true;

        yield return new WaitForSeconds(4.0f);

        Color fadeColor = fadeOutImage.color;

        for (int i = 0; i < 100; i++)
        {
            float f = i / 100.0f;
            fadeColor.a = f + 0.5f;
            fadeOutImage.color = fadeColor;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(3.5f);
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

    IEnumerator Death()
    {
        yield return new WaitForSeconds(1.0f);

        if (isPlaying == true) //중복재생방지
        {
            Debug.Log("fade In 실행 중");
            yield break;
        }
        deathUI.SetActive(true);
        HUD.SetActive(false);
        mainCamera.GetComponentInChildren<GraySceleEffect>().enabled = true;
        //GetComponentInChildren<vThirdPersonCamera>().isFreezed = true;

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
        prisonerLight.intensity = 5;
        personController.isImmortal = false;
        deathMotion.keepRagdolled = false;       
    }
}
