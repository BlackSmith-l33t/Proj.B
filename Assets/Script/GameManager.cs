using System.Collections;
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

    private void Awake()
    {
        player.OnDie += Death;
    }

    IEnumerator StartFadeInOut()
    {
        yield return new WaitForSeconds(4.0f);

        Color fadeColor = fadeOutImage.color;

        for (int i = 0; i < 100; i++)
        {
            float f = i / 100.0f;
            fadeColor.a = f + 0.5f;
            fadeOutImage.color = fadeColor;
            yield return new WaitForSeconds(0.01f);
        }

        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("Pit");
    }

    private void Death()
    {        
        deathMotion.ActivateRagdoll();
        deathUI.SetActive(true);
        mainCamera.GetComponentInChildren<GraySceleEffect>().enabled = true;
        mainCamera.GetComponentInChildren<vThirdPersonCamera>().isFreezed = true;

        Debug.Log("fade out 호출");       
        StartCoroutine("StartFadeInOut");
    }
 
}
