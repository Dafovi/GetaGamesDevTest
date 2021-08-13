using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool gameOver;
    public GameObject gameOverPanel,newrecordPanel,Meters;
    private PlayerController kartController;
    private LoadScene SceneManager;
    public GameObject metersImage;
    void Start()
    {
        kartController = FindObjectOfType<PlayerController>();
        gameOver = false;
        SceneManager = FindObjectOfType<LoadScene>();
    }

    void Update()
    {
        if(gameOver){
            kartController.isDrivable=false;
            if(GameManager.instance.MetersRecord<GetComponent<RecordDistance>().distance){
                newrecordPanel.SetActive(true);
                PlayerPrefs.SetFloat("metersRecord",GetComponent<RecordDistance>().distance);
            }
            else
            gameOverPanel.SetActive(true);
        
            Meters.SetActive(false);
            metersImage.SetActive(false);
            StartCoroutine(ChangeScene());
        }
    }

    IEnumerator ChangeScene(){
        PlayerPrefs.SetInt("endlesRacesPlayed",GameManager.instance.EndlesRacesPlayed+1);

        yield return new WaitForSeconds(5);

        GameManager.instance.GetVariables();

        SceneManager.ToLoadingScene("MainMenu");
    }
}
