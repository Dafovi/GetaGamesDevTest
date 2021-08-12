using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    
    private InputData Input;
    private KartController KartController;
    private GameObject Player;
    public float speed =2.5f;
    public float aceleration;
    void Start()
    {
        Player=GameObject.FindGameObjectWithTag("Player");
        Input=Player.GetComponent<InputData>();
        KartController=Player.GetComponent<KartController>();
        aceleration=KartController.aceleration;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
            StartCoroutine(BoostDelay());
        }
    }

    IEnumerator BoostDelay(){
        float acelerationBoost=aceleration*speed;
        KartController.aceleration=acelerationBoost;

        yield return new WaitForSeconds(2);
        KartController.aceleration=aceleration;
    }
}
