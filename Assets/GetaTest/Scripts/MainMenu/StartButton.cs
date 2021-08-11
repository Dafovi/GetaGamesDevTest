using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void startGame(){
        LoadScene sceneManager = FindObjectOfType<LoadScene>();
        sceneManager.ToLoadingScene("Gameplay");
    }
}
