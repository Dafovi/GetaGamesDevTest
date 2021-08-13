using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statistics : MonoBehaviour
{
    public Text TR_racesPlayedText;
    public Text TR_racesWonText;
    public Text TR_recordText;
    public Text DR_racesPlayedText;
    public Text DR_recordText;
    void Start()
    {
        TR_racesPlayedText.text="Carreras jugadas: "+ GameManager.instance.RacesPlayed;
        TR_racesWonText.text="Carreras ganadas: "+ GameManager.instance.RacesWon;

        if(GameManager.instance.Record!=0)
        TR_recordText.text="Carrera más rapida: "+ActualizarReloj(GameManager.instance.Record) +" segundos";
        else TR_recordText.text="Carrera más rapida: --:--";

        DR_racesPlayedText.text="Carreras jugadas: "+ GameManager.instance.EndlesRacesPlayed;
        DR_recordText.text="Distancia máxima: "+GameManager.instance.MetersRecord.ToString("00")+"m";
    }
    public string ActualizarReloj(float tiempoEnSegundos){
        int minutos = 0;
        int segundos = 0;
        // int milisegundos = 0;
        string textoDelReloj;

        if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

        minutos = (int)tiempoEnSegundos / 60;
        segundos = (int)tiempoEnSegundos % 60;

        textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00");
        return textoDelReloj;
    }
}
