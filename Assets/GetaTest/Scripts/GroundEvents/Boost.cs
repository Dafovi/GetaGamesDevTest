using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boost : MonoBehaviour
{
    
    private InputData Input;
    private KartController KartController;
    private GameObject Player;
    [SerializeField] private float speed =2.5f;
    [SerializeField] private float aceleration;
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
        //Recibe la velocidad actual del "kart" sin turbo y la multiplica el aumento de velocidad
        float acelerationBoost=aceleration*speed;
        KartController.aceleration=acelerationBoost;

        //Vuelve a su velocidad normal
        yield return new WaitForSeconds(2);
        KartController.aceleration=aceleration;
    }
}
