using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    
    private InputData Input;
    private KartController KartController;
    private GameObject Player;
    public float speed =2.5f;
    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        Input=Player.GetComponent<InputData>();
        KartController=Player.GetComponent<KartController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
            StartCoroutine(BoostDelay(KartController.aceleration));
            KartController.checkPoint=this.transform.position;
        }
    }

    IEnumerator BoostDelay(float actAceleration){
        float acelerationBoost=actAceleration*speed;
        KartController.aceleration=acelerationBoost;

        yield return new WaitForSeconds(2);
        KartController.aceleration=actAceleration;
    }
}
