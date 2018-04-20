using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class KillPlayer : MonoBehaviour {

    private Transform playerPosition;
    PlayManagement playManagement;
	void Awake () {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        playManagement = GameObject.FindGameObjectWithTag("mainsceneobject").GetComponent<PlayManagement>();    
	}
	void Update () {
        GetComponent<NavMeshAgent>().destination = playerPosition.position;
	}   
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            playManagement.GameOver();
        }
    }
   
}
