using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EndGame : MonoBehaviour
{
    public event UnityAction OnFnishied;
    public GameObject MountainOfStupid;
    public bool endGame = false;

    private void OnCollisionEnter(Collision collision)
    {
        endGame = true;
        MountainOfStupid.SetActive(false);
        OnFnishied?.Invoke();
    }
}
