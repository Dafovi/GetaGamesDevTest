using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void startGame(string scene){
        LoadScene sceneManager = FindObjectOfType<LoadScene>();
        sceneManager.ToLoadingScene(scene);
    }
}
