using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LapObject : MonoBehaviour
{
    #region Variables
    [Header("lose/win Screens")]
    public GameObject winUI;
    public GameObject loseUI;
    public GameObject LastCheckPoint;
    
    [Header("Timer"),Space(6)]
    public GameObject TimerObject;
    private Timer timer;
    
    [Header("Player and PlayerPlarticles"),Space(6)]
    public KartController player;
    public GameObject particles;


    private LoadScene SceneManager;
    private respawn respawn;
    #endregion
    
    void Start()
    {
        timer = FindObjectOfType<Timer>();
        winUI.SetActive(false);
        loseUI.SetActive(false);
        SceneManager = FindObjectOfType<LoadScene>();
        respawn = FindObjectOfType<respawn>();
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //Si el jugador ya paso por le ultimo checkpoint y cruza la meta gana
        if(other.CompareTag("KartCollider") && respawn.checkpoint==LastCheckPoint && respawn.checkpoint!=null){

            winUI.SetActive(true);

            StartCoroutine(ChangeScene());

            timer.EstaPausado=true;
            player.isDrivable=false;

            //Suma 1 a el numero de carreras ganadas
            PlayerPrefs.SetInt("racesWon",GameManager.instance.RacesWon+1);
            
            //Si el tiempo obtenido fue menor al récord actual, este se guarda
            if(GameManager.instance.Record==0 || GameManager.instance.Record>timer.record)
            PlayerPrefs.SetFloat("record",timer.record);

            particles.SetActive(true);
        }

    }
    void Update(){
        //Si se termina el tiempo y no ha logrado cruzar la meta,se pierde
        if(timer.tiempoMostrarEnSegundos<=0){
            loseUI.SetActive(true);
            StartCoroutine(ChangeScene());
            player.isDrivable=false;
        }
    }

    IEnumerator ChangeScene(){

        TimerObject.SetActive(false);

        //Agrega 1 al numero de carreras jugadas
        PlayerPrefs.SetInt("racesPlayed",GameManager.instance.RacesPlayed+1);

        //Espera 5 seegundos mientras se termina la musica
        yield return new WaitForSeconds(5);

        //Atualiza las estadisticas
        GameManager.instance.GetVariables();
        
        SceneManager.ToLoadingScene("MainMenu");
    }
}
