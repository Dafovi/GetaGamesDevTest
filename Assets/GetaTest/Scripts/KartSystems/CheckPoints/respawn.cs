using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respawn : MonoBehaviour
{
    private KartController kartController;
    public LayerMask outRoad;
    public Vector3 checkPointPos;
    public Quaternion checkPointRot;
    public GameObject checkpoint;
    public GameObject respawnGUI;
    void Start()
    {
        kartController=GetComponentInParent<KartController>();   
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("outRoad")){
            checkPointPos = checkpoint.transform.position;
            checkPointRot = checkpoint.transform.rotation;
            StartCoroutine(FixKartPos());
        }
    }
    IEnumerator FixKartPos(){
        GameObject visualRespawn=Instantiate(respawnGUI);
        visualRespawn.transform.SetParent(GameObject.Find("GUI").transform,false);;
        kartController.isDrivable=false;
        yield return new WaitForSeconds(1);
        kartController.transform.position=new Vector3(checkPointPos.x,checkPointPos.y+0.93f,checkPointPos.z);
        kartController.transform.rotation = checkPointRot;
        kartController.isDrivable=true;
        yield return new WaitForSeconds(0.5f);
        Destroy(visualRespawn);
    }
}
