using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    #region Variables
    [HideInInspector] public string sceneToLoad;
    AsyncOperation loadingOperation;
    private Slider progressBar;
    private float progressValue;
    private Text percentLoaded;
    public static LoadScene SceneManagement = null;
    private bool isLoading;
    private int scene;
    private GameObject ButtonToScene;
    #endregion

    void Awake(){
        // No eliminar el script en la carga.
        if (SceneManagement == null) {
            SceneManagement = this;
        } else if (SceneManagement != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        //Guarda el numero de la escena en la que inicia
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    //Envia a la escena de carga "Loading"
    public void ToLoadingScene(string nextScene){
        SceneManager.LoadSceneAsync("Loading");
        //Guarda el nombre de la escena que se va a cargar
        sceneToLoad =nextScene;
    }

    void Update(){
        //Si ya no se encuentra en la misma escena, actualiza el numero de la misma
        if(scene!=SceneManager.GetActiveScene().buildIndex){
            isLoading=false;
            scene=SceneManager.GetActiveScene().buildIndex;
        }

        //Si estoy en la escena "Loading", carga de manera asincrónica la siguiente escena
        if(SceneManager.GetActiveScene().name=="Loading"){
            if(!isLoading){
                ButtonToScene=GameObject.Find("DoneButton");
                ButtonToScene.SetActive(false);
                loadingOperation = SceneManager.LoadSceneAsync(sceneToLoad);
                isLoading=true;
            }
            if(progressValue!=1){
                //convertir el progreso a un valor entre 0 y 0,9
                progressValue  = Mathf.Clamp01(loadingOperation.progress / 0.9f);

                //Mostrar el porcentaje de carga en texto
                percentLoaded=GameObject.Find("LoadingText").GetComponent<Text>();
                percentLoaded.text ="Cargando: "+ Mathf.Round(progressValue * 100) + "%";
                
                //Mostrar el progreso de la carga en el slider
                progressBar=GameObject.Find("LoadingSlider").GetComponent<Slider>();
                progressBar.value = progressValue ;
            }

            //Si esta cargando un modo de juego, desactiva el cambio de escena automatico
            if(sceneToLoad!="MainMenu" && !ButtonToScene.activeSelf){
                loadingOperation.allowSceneActivation = false;
                if(progressValue==1)ButtonToScene.SetActive(true);
            }

            //Debug.Log(progressValue);
        }
    }

    //Envia a la siguiente escena
    public void Done(){
        loadingOperation.allowSceneActivation = true;
    }
    
}
