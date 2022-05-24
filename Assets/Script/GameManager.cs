using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;
using Invector.vCamera;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject prisoner;
    public GameObject deathUI;
    public GameObject HUD;
    public GameObject startPoint;
    public Image fadeOutImage;
    public vThirdPersonCamera mainCamera;
    public vRagdoll deathMotion;
    public vThirdPersonController prisonerController;

    bool isPlaying = false;

    private void Awake()
    {             
        prisoner.GetComponent<PrisonerController>().OnDie += Death;
        prisonerController.onChangeHealth.AddListener(OnChangeHealth);
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
        SceneManager.LoadScene("Pit");
    }

    private void Death()
    {
        if (isPlaying == true) //중복재생방지
        {
            Debug.Log("fade In 실행 중");
            return;
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
}
