using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapObject : MonoBehaviour
{
    private Timer timer;
    public GameObject winUI,loseUI;
    private LoadScene SceneManager;
    public KartController player;
    public GameObject particles;
    
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
            PlayerPrefs.SetInt("racesWon",GameManager.instance.RacesWon+1);
            
            if(GameManager.instance.Record==0 || GameManager.instance.Record>timer.record)
            PlayerPrefs.SetFloat("record",timer.record);

            particles.SetActive(true);
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
        PlayerPrefs.SetInt("racesPlayed",GameManager.instance.RacesPlayed+1);

        yield return new WaitForSeconds(5);

        GameManager.instance.GetVariables();

        SceneManager.ToLoadingScene("MainMenu");
    }
}
