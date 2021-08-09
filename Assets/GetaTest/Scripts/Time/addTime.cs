using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTime : MonoBehaviour
{
    private Timer timer;
    public float extraTime = 10f;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
        timer.tiempoMostrarEnSegundos+=extraTime;
        Destroy(this.gameObject);
        }
    }
    
}
