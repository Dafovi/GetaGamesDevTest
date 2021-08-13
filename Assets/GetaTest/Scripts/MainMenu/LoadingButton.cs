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
        LoadingSlider.SetActive(!button.activeSelf);
        LoadingText.SetActive(!button.activeSelf);
        if(LoadScene.SceneManagement.sceneToLoad=="Gameplay")GamePlay.SetActive(true);
        if(LoadScene.SceneManagement.sceneToLoad=="EndlessGame")EndlessGame.SetActive(true);

    }
    public void ChangeScene(){
        LoadScene.SceneManagement.Done();
        GameObject music= GameObject.Find("BackgroundMusic");
        Destroy(music);
    }
}
