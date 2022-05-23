using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Invector.vCharacterController;
using Invector.vCamera;

public class PlayerController : MonoBehaviour
{
    public vRagdoll deathMotion;
    public GameObject startPoint;
    public GameObject deathUI;  
    public Image fadeOutImage;
    public vThirdPersonCamera mainCamera;
    

    int BombBoxLayer = 19;
    float FadeTime = 2.0f; // fade 효과 재생시간
    float start;
    float end;
    float time = 0.0f;

    bool isPlaying = false;

    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();  
        
    }

    private void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            transform.position = startPoint.transform.position;
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("플레이어 충돌 감지");
        if (!(other.gameObject.layer == BombBoxLayer))
        {
            return;
        }     
        
        Debug.Log("You Die");
        deathMotion.ActivateRagdoll();
        Death();
    }

    private void Death()
    {
        deathUI.SetActive(true);
        mainCamera.GetComponentInChildren<GraySceleEffect>().enabled = true;
        mainCamera.GetComponentInChildren<vThirdPersonCamera>().isFreezed = true;
       
        // TODO :흑백 화면 -> UI 표시 -> fade out

    }

    private void Respawn()
    {
        // 리스폰 지역은 어떻게?  리스폰 지역 업데이트? 처음 시작점? 
        // TODO : 플레이어 ragdoll 해제 -> 리스폰 지역으로 이동 -> fade in 
    }
}
   
