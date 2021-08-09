using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapObject : MonoBehaviour
{
    private Timer timer;
    public GameObject winUI,loseUI;
    private LoadScene SceneManager;
    public KartController player;
    
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        winUI.SetActive(false);
        loseUI.SetActive(false);
        SceneManager = FindObjectOfType<LoadScene>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("KartCollider") && other.transform.GetComponentInParent<KartController>().checkPoint!=Vector3.zero){
            winUI.SetActive(true);
            StartCoroutine(ChangeScene());
            timer.EstaPausado=true;
            player.isDrivable=false;
        }

    }
    void Update(){
        if(timer.tiempoMostrarEnSegundos<=0){
            loseUI.SetActive(true);
            StartCoroutine(ChangeScene());
            player.isDrivable=false;
        }
    }

    IEnumerator ChangeScene(){
        yield return new WaitForSeconds(3);
        SceneManager.ToLoadingScene("MainMenu");
    }
}
