using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addTime : MonoBehaviour
{
    private Timer timer;
    [SerializeField]private float extraTime = 10f;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }
    void Update()
    {
        //Hace palpitar el "GameObjetc"
        transform.localScale = Vector3.one *(1.34f + 0.15f * Mathf.Sin(Time.time * Mathf.PI));
    }

    private void OnTriggerEnter(Collider other)
    {
        //Al colisionar con el reloj, aumenta el tiempo y destruye el objeto
        if(other.CompareTag("KartCollider")){
            timer.tiempoMostrarEnSegundos+=extraTime;
            timer.addTime();
            Destroy(this.gameObject);
        }
    }
    
}
