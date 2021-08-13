using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Banana : MonoBehaviour
{
    
    private KartController KartController;
    private GameObject Player;
    private CinemachineTransposer virtualCamera;
    private bool collision;
    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        KartController=Player.GetComponent<KartController>();
        virtualCamera = FindObjectOfType<CinemachineTransposer>();
    }
    private void Update()
    {
        //Al colisionar con una "banana" el "kart" empieza a dar vueltas
        if(collision){
            float newRotation = 720* Time.deltaTime;
            Player.transform.Rotate(0,newRotation,0,Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
            StartCoroutine(BananaDelay());
        }
    }

    IEnumerator BananaDelay(){
        //Activa las particulas y sonidos de derrape
        KartController.transform.GetComponent<KartVFX>().driftStatus=true;
        GetComponent<AudioSource>().Play();

        //Desactiva las visuales de la "banana"
        GetComponent<MeshRenderer>().enabled=false;
        
        //Impide que el jugador pueda moverse
        KartController.isDrivable=false;
        collision=true;

        //Bloquea la rotacion de la cámara
        virtualCamera.m_YawDamping=20f;

        yield return new WaitForSeconds(1);

        //Vuelve a dejar todo como estaba antes de colisionar
        collision=false;
        KartController.isDrivable=true;
        virtualCamera.m_YawDamping=1f;
        KartController.transform.GetComponent<KartVFX>().driftStatus=false;

        //Destruye la "banana
        Destroy(gameObject);
    }

}
