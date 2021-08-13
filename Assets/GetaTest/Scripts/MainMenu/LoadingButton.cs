using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingButton : MonoBehaviour
{
    public GameObject button;
    public GameObject LoadingText,LoadingSlider;
    public GameObject GamePlay,EndlessGame;
    private void Update()
    {
        //Si el la escena ya esta carga y el botón de continuar activo
        //Quita o activa los elementos de carga
        LoadingSlider.SetActive(!button.activeSelf);
        LoadingText.SetActive(!button.activeSelf);

        //Segun la escena que se esta cargando activa sus instrucciones
        if(LoadScene.SceneManagement.sceneToLoad=="Gameplay")GamePlay.SetActive(true);
        if(LoadScene.SceneManagement.sceneToLoad=="EndlessGame")EndlessGame.SetActive(true);

    }
    public void ChangeScene(){
        //Activa el cambio de escena y destruye la musica del menú
        LoadScene.SceneManagement.Done();
        GameObject music= GameObject.Find("BackgroundMusic");
        Destroy(music);
    }
}
