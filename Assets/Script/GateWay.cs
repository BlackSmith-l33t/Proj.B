using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateWay : MonoBehaviour
{
    public GameObject gate;
    public GameObject connectGate;    
    public int gateNumber;

    Transform teleportPos;
    Vector3 pos;
    int playerLayer = 8;

    private void OnCollisionEnter(Collision other)
    {
        Debug.Log("OnCollisionEnter");

        if (playerLayer == other.gameObject.layer)
        {            
            RunGateWay(other.gameObject);
            
            Debug.Log("GateWay Running");
        }        
    }

    private void RunGateWay(GameObject player)
    {
        switch (connectGate.name)
        {
            case "Gate1" :
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x, connectGate.transform.position.y, connectGate.transform.position.z + 5.0f);
                break;
            case "Gate2":
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x - 2.0f, connectGate.transform.position.y, connectGate.transform.position.z - 1.0f);
                break;
            case "Gate3":
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x - 3.0f, connectGate.transform.position.y, connectGate.transform.position.z + 2.0f);
                break;
            case "Gate4":
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x, connectGate.transform.position.y, connectGate.transform.position.z + 2.0f);
                break;
            case "Gate5":
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x + 2.0f, connectGate.transform.position.y, connectGate.transform.position.z + 2.0f);
                break;
            case "Gate6":
                player.gameObject.transform.position = new Vector3(connectGate.transform.position.x, connectGate.transform.position.y, connectGate.transform.position.z - 2.0f);
                break;

            default:
                break;
        }       
    }
}
