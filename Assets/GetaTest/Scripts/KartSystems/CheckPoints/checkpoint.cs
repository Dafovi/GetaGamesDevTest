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
            respawn.checkpoint=this.gameObject;
        }
    }
}
