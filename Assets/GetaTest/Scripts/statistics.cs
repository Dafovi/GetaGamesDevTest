using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statistics : MonoBehaviour
{
    #region Variables
    [Header("Race against time Statistics")]
    [SerializeField] private Text TR_racesPlayedText;
    [SerializeField] private Text TR_racesWonText;
    [SerializeField] private Text TR_recordText;
    
    [Header("Long distance race Statistics"),Space(10)]
    [SerializeField] private Text DR_racesPlayedText;
    [SerializeField] private Text DR_recordText;
    #endregion
    void Start()
    {
        //Actualiza los "Text" con los valores traidos desde el "GameManager" que son los mismos "PlayerPrefs"

        TR_racesPlayedText.text="Carreras jugadas: "+ GameManager.instance.RacesPlayed;
        TR_racesWonText.text="Carreras ganadas: "+ GameManager.instance.RacesWon;

        if(GameManager.instance.Record!=0)
        TR_recordText.text="Carrera más rapida: "+ActualizarReloj(GameManager.instance.Record) +" segundos";
        else TR_recordText.text="Carrera más rapida: --:--";

        DR_racesPlayedText.text="Carreras jugadas: "+ GameManager.instance.EndlesRacesPlayed;
        DR_recordText.text="Distancia máxima: "+GameManager.instance.MetersRecord.ToString("00")+"m";
    }

    //Corrige el formato en que se muestra el tiempo
    public string ActualizarReloj(float tiempoEnSegundos){
        int minutos = 0;
        int segundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        return textoDelReloj;
    }
}
