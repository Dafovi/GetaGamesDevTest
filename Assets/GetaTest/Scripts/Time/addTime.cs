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
    void Update()
    {
        transform.localScale = Vector3.one *(1.34f + 0.15f * Mathf.Sin(Time.time * Mathf.PI));
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider")){
        timer.tiempoMostrarEnSegundos+=extraTime;
        Destroy(this.gameObject);
        }
    }
    
}
