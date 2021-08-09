using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class statistics : MonoBehaviour
{
    public Text racesPlayedText;
    public Text racesWonText;
    public Text recordText;
    void Start()
    {
        racesPlayedText.text="Carreras jugadas: "+ GameManager.instance.RacesPlayed;
        racesWonText.text="Carreras ganadas: "+ GameManager.instance.RacesWon;

        if(GameManager.instance.Record!=0)
        recordText.text="Carrera más rapida: "+ActualizarReloj(GameManager.instance.Record) +" segundos";
        else recordText.text="Carrera más rapida: --:--";
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
