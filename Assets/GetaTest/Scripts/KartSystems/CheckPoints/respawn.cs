using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private KartController kartController;
    public LayerMask outRoad;
    public Vector3 checkPointPos;
    [SerializeField] private Quaternion checkPointRot;
    public GameObject checkpoint;
    [SerializeField] private GameObject respawnGUI;
    void Start()
    {
        kartController=GetComponentInParent<KartController>();   
    } 
    private void OnTriggerEnter(Collider other){
        //Si el jugador se sale de la carretera se le devuelve al ultimo "checkpoint" guardado
        if(other.CompareTag("outRoad")){
            checkPointPos = checkpoint.transform.position;
            checkPointRot = checkpoint.transform.rotation;
            StartCoroutine(FixKartPos());
        }
    }
    IEnumerator FixKartPos(){
        //Se bloquea el movimiento mientras se reposiciona el "kart"
        //Además se activa una animación de difuminado a negro para que no se vea el cambio de posición de manera brusca

        GameObject visualRespawn=Instantiate(respawnGUI);
        visualRespawn.transform.SetParent(GameObject.Find("GUI").transform,false);;
        kartController.isDrivable=false;

        //La tansición se desactiva despues de 1 segundo
        yield return new WaitForSeconds(1);
        kartController.transform.position=new Vector3(checkPointPos.x,checkPointPos.y+0.93f,checkPointPos.z);
        kartController.transform.rotation = checkPointRot;
        kartController.isDrivable=true;

        //Al finalizar el difumunado se destruye
        yield return new WaitForSeconds(0.5f);
        Destroy(visualRespawn);
    }
}
