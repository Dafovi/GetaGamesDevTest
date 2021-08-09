using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Material chasis,wheels,character;
    public void revertChanges(){
        chasis.color=GameManager.instance.ChasisColor;
        character.color=GameManager.instance.CharacterColor;
        wheels.color=GameManager.instance.WheelsColor;
    }
    public void saveChanges(){
        GameManager.instance.ChasisColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(chasis.color);
        GameManager.instance.CharacterColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(character.color);
        GameManager.instance.WheelsColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(wheels.color);
        GameManager.instance.SetVariables();
    }

    public void ChasisColor(Button button){
        chasis.color=button.transform.GetComponent<Image>().color;
    }
    public void WheelsColor(Button button){
        wheels.color=button.transform.GetComponent<Image>().color;
    }
    public void CharacterColor(Button button){
        character.color=button.transform.GetComponent<Image>().color;
    }
}
