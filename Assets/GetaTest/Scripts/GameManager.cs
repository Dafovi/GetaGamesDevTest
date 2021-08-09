using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //Variables privadas
    [SerializeField] private int racePlayed;
    [SerializeField] private int raceWon;
    [SerializeField] private float record;
    [SerializeField] private Color chasisColor;
    [SerializeField] private Color wheelsColor;
    [SerializeField] private Color characterColor;
    [SerializeField] private string chasisColorHex;
    [SerializeField] private string wheelsColorHex;
    [SerializeField] private string characterColorHex;
    //Variables publicas
    public int RacePlayed {
        get { return RacePlayed; }
    }
    public int RaceWon {
        get { return raceWon; }
    }
    public float Record {
        get { return record; }
    }
    public string ChasisColorHex {
        get { return chasisColorHex; }
    }
    public string WheelsColorHex {
        get { return wheelsColorHex; }
    }
    public string CharacterColorHex {
        get { return characterColorHex; }
    }

    public static GameManager instance = null;
    #endregion
    void Awake(){
        // No eliminar el script entre escenas.
        if (instance == null) {
            instance = this;
        } else if (instance != null) {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
        
        //Load variables
        GetVariables();  
    }
    public void GetVariables(){
        racePlayed=PlayerPrefs.GetInt("racePlayed",0);
        raceWon=PlayerPrefs.GetInt("raceWon",0);
        record=PlayerPrefs.GetFloat("record",0);
        
        chasisColorHex=PlayerPrefs.GetString("chasisColorHex","#"+ColorUtility.ToHtmlStringRGBA(chasisColor));
        wheelsColorHex=PlayerPrefs.GetString("wheelsColorHex","#"+ColorUtility.ToHtmlStringRGBA(wheelsColor));
        characterColorHex=PlayerPrefs.GetString("characterColorHex","#"+ColorUtility.ToHtmlStringRGBA(characterColor));

        ColorUtility.TryParseHtmlString (chasisColorHex, out chasisColor);
        ColorUtility.TryParseHtmlString (wheelsColorHex, out wheelsColor);
        ColorUtility.TryParseHtmlString (characterColorHex, out characterColor);

    }
}
