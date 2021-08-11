using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Banana : MonoBehaviour
{
    
    private KartController KartController;
    private GameObject Player;
    private CinemachineTransposer virtualCamera;
    public bool collision;
    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        KartController=Player.GetComponent<KartController>();
        virtualCamera = FindObjectOfType<CinemachineTransposer>();
    }
    private void Update()
    {
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
        KartController.transform.GetComponent<KartyVFX>().driftStatus=true;
        GetComponent<MeshRenderer>().enabled=false;
        GetComponent<AudioSource>().Play();
        KartController.isDrivable=false;
        collision=true;
        virtualCamera.m_YawDamping=20f;
        yield return new WaitForSeconds(1);
        collision=false;
        KartController.isDrivable=true;
        virtualCamera.m_YawDamping=1f;
        KartController.transform.GetComponent<KartyVFX>().driftStatus=false;
        Destroy(gameObject);
    }

}
