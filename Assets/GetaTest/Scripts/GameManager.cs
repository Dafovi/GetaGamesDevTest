using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables privadas
    [Header("Race against time Statistics")]
    [SerializeField] private int racesPlayed;
    [SerializeField] private int racesWon;
    [SerializeField] private float record;
    
    [Header("Player colors"),Space(8)]
    [SerializeField] private Color chasisColor;
    [SerializeField] private Color wheelsColor;
    [SerializeField] private Color characterColor;
    
    [Header("Colors HEX"),Space(6)]
    [SerializeField] private string chasisColorHex;
    [SerializeField] private string wheelsColorHex;
    [SerializeField] private string characterColorHex;
    
    [Header("Long distance race Statistics"),Space(10)]
    [SerializeField] private float metersRecord;
    [SerializeField] private int endlesRacesPlayed;
    #endregion

    #region Variables publicas
    public int RacesPlayed {
        get { return racesPlayed; }
    }
    public int RacesWon {
        get { return racesWon; }
    }
    public float Record {
        get { return record; }
    }
    public string ChasisColorHex {
        get { return chasisColorHex; }
        set { chasisColorHex=value; }
  
    }
    public string WheelsColorHex {
        get { return wheelsColorHex; }
        set { wheelsColorHex=value; } 
    }
    public string CharacterColorHex {
        get { return characterColorHex; }
        set { characterColorHex=value; }
    }
    public Color ChasisColor{
        get {return chasisColor;}
    }
    public Color WheelsColor{
        get {return wheelsColor;}
    }
    public Color CharacterColor{
        get {return characterColor;}
    }
    public int EndlesRacesPlayed {
        get { return endlesRacesPlayed; }
    }
    public float MetersRecord {
        get { return metersRecord; }
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
        
        //Traer los valores de las variables desde los PlayerPrefs
        GetVariables();  
    }
    public void GetVariables(){

        //Si es la primera vez que se cargan, establece su valor en 0
        racesPlayed=PlayerPrefs.GetInt("racesPlayed",0);
        racesWon=PlayerPrefs.GetInt("racesWon",0);
        record=PlayerPrefs.GetFloat("record",0);

        endlesRacesPlayed=PlayerPrefs.GetInt("endlesRacesPlayed",0);
        metersRecord=PlayerPrefs.GetFloat("metersRecord",0);

        //Si es la primera vez que se cargan, toma el valor por defecto de cada color en Hexadecimal
        chasisColorHex=PlayerPrefs.GetString("chasisColorHex","#"+ColorUtility.ToHtmlStringRGBA(chasisColor));
        wheelsColorHex=PlayerPrefs.GetString("wheelsColorHex","#"+ColorUtility.ToHtmlStringRGBA(wheelsColor));
        characterColorHex=PlayerPrefs.GetString("characterColorHex","#"+ColorUtility.ToHtmlStringRGBA(characterColor));

        //Establece el color desde los playerPrefs
        ColorUtility.TryParseHtmlString (chasisColorHex, out chasisColor);
        ColorUtility.TryParseHtmlString (wheelsColorHex, out wheelsColor);
        ColorUtility.TryParseHtmlString (characterColorHex, out characterColor);

    }

    public void SetVariables(){
        //Guarda el color del jugador en Hexadecimal
        PlayerPrefs.SetString("chasisColorHex",chasisColorHex);
        PlayerPrefs.SetString("wheelsColorHex",wheelsColorHex);
        PlayerPrefs.SetString("characterColorHex",characterColorHex);

        GetVariables();
    }
}
