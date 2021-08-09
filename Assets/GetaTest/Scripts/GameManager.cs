using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Variables
    //Variables privadas
    [SerializeField] private int racesPlayed;
    [SerializeField] private int racesWon;
    [SerializeField] private float record;
    [SerializeField] private Color chasisColor;
    [SerializeField] private Color wheelsColor;
    [SerializeField] private Color characterColor;
    [SerializeField] private string chasisColorHex;
    [SerializeField] private string wheelsColorHex;
    [SerializeField] private string characterColorHex;
    //Variables publicas
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
        racesPlayed=PlayerPrefs.GetInt("racesPlayed",0);
        racesWon=PlayerPrefs.GetInt("racesWon",0);
        record=PlayerPrefs.GetFloat("record",0);
        
        chasisColorHex=PlayerPrefs.GetString("chasisColorHex","#"+ColorUtility.ToHtmlStringRGBA(chasisColor));
        wheelsColorHex=PlayerPrefs.GetString("wheelsColorHex","#"+ColorUtility.ToHtmlStringRGBA(wheelsColor));
        characterColorHex=PlayerPrefs.GetString("characterColorHex","#"+ColorUtility.ToHtmlStringRGBA(characterColor));

        ColorUtility.TryParseHtmlString (chasisColorHex, out chasisColor);
        ColorUtility.TryParseHtmlString (wheelsColorHex, out wheelsColor);
        ColorUtility.TryParseHtmlString (characterColorHex, out characterColor);

    }

    public void SetVariables(){
        PlayerPrefs.SetString("chasisColorHex",chasisColorHex);
        PlayerPrefs.SetString("wheelsColorHex",wheelsColorHex);
        PlayerPrefs.SetString("characterColorHex",characterColorHex);

        GetVariables();
    }
}
