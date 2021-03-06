using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
   #region  Variables
   [Tooltip("Tiempo iniciar en Segundos")]
   public int tiempoinicial =120;
   [Tooltip("Escala del Tiempo del Reloj")]
   [Range(-10.0f, 10.0f)]
   public float escalaDeTiempo = 1;

   private Text myText;
   public Text tiempoTotal;
   private float TiempoFrameConTiempoScale = 0f;
   [HideInInspector]
   public float tiempoMostrarEnSegundos = 0F;
   private float escalaDeTiempoPausar, escalaDeTiempoInicial;
   public bool EstaPausado = false;
   [HideInInspector]
   public float record = 0F;

   public Color color;
   public AudioSource addtime;

   #endregion
   void Start()
   {
      //Escala de Tiempo Original
      escalaDeTiempoInicial = escalaDeTiempo;


      myText = GetComponent<Text>();
      tiempoMostrarEnSegundos = tiempoinicial;

      ActualizarReloj(tiempoinicial);


   }

    // Update is called once per frame
   void Update() {
      if(!EstaPausado){
         TiempoFrameConTiempoScale = Time.deltaTime * escalaDeTiempo;
         tiempoMostrarEnSegundos -= TiempoFrameConTiempoScale;
         record+=TiempoFrameConTiempoScale;
         myText.text =ActualizarReloj(tiempoMostrarEnSegundos);
         tiempoTotal.text="Tiempo total: "+ActualizarReloj(record);
      }
   }
   public string ActualizarReloj(float tiempoEnSegundos)
   {
      int minutos = 0;
      int segundos = 0;
      // int milisegundos = 0;
      string textoDelReloj;

      if (tiempoEnSegundos < 0) tiempoEnSegundos = 0;

      minutos = (int)tiempoEnSegundos / 60;
      segundos = (int)tiempoEnSegundos % 60;
      //milisegundos = (int)tiempoEnSegundos / 1000;

      textoDelReloj = minutos.ToString("00") + ":" + segundos.ToString("00"); //+ ":" + milisegundos.ToString("00");
      return textoDelReloj;
   }
   public void addTime(){
      StartCoroutine(ChangeColor());
      addtime.Play();
   }

   IEnumerator ChangeColor(){
      myText.color=color;
      yield return new WaitForSeconds(0.7f);
      myText.color=Color.white;
   }

}
