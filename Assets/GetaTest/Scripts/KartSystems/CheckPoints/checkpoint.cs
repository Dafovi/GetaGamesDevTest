using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private respawn respawn;
    void Start()
    {
        respawn=FindObjectOfType<respawn>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
            //Guarda el ultimo "checkpoint" por el que el jugador paso
            respawn.checkpoint=this.gameObject;
        }
    }
}
