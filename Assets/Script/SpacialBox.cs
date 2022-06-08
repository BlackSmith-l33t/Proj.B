using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpacialBox : MonoBehaviour
{
    public GameObject candle;
    public GameObject box;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            candle.SetActive(true);
            box.SetActive(true);
        }
    }
}
