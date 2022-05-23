using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Invector.vCharacterController;
using Invector.vCamera;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Player player;
    public GameObject deathUI;
    public GameObject startPoint;
    public Image fadeOutImage;
    public vThirdPersonCamera mainCamera;
    public vRagdoll deathMotion;

    float fadeTime = 5.0f; // fade 효과 재생시간
    float start;
    float end;
    float time = 0.0f;

    bool isPlaying = false;

    private void Awake()
    {        
        player.OnDie += Death;
    }

    IEnumerator StartFadeIn()
    {
        yield return new WaitForSeconds(4.0f);

        //if (player.isAlive)
        //{
        //    yield return null;
        //}

        isPlaying = true;        

        Color fadeColor = fadeOutImage.color;
        time = 0.0f;        
        fadeColor.a = Mathf.Lerp(start, end, time);

        while (fadeColor.a > 0.0f)
        {
            time += Time.deltaTime / fadeTime;
            fadeColor.a = Mathf.Lerp(start, end, time);
            fadeOutImage.color = fadeColor;
            yield return null;
        }

        isPlaying = false;
        Restart();
    }  

    public void Restart()
    {
        SceneManager.LoadScene("Pit");        
    }

    private void Death()
    {
        deathMotion.ActivateRagdoll();
        deathUI.SetActive(true);
        mainCamera.GetComponentInChildren<GraySceleEffect>().enabled = true;
        mainCamera.GetComponentInChildren<vThirdPersonCamera>().isFreezed = true;

        Debug.Log("fade out 호출");
        // TODO :흑백 화면 -> UI 표시 -> fade out -> ReStart() 호출
        FadeIn();
    }

    public void FadeIn()
    {
        if (true == isPlaying) // 중복 재생 방지
        {
            return;
        }
        start = 5.0f;
        end = 0.0f;

        StartCoroutine("StartFadeIn");
    }
}
