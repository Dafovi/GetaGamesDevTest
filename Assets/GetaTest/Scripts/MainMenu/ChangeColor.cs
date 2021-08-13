using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeColor : MonoBehaviour
{
    public Material chasis,wheels,character;
    public GameObject kart;
    public void revertChanges(){
        chasis.color=GameManager.instance.ChasisColor;
        character.color=GameManager.instance.CharacterColor;
        wheels.color=GameManager.instance.WheelsColor;
        StartCoroutine(Delay(false));
    }
    public void saveChanges(){
        GameManager.instance.ChasisColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(chasis.color);
        GameManager.instance.CharacterColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(character.color);
        GameManager.instance.WheelsColorHex ="#"+ ColorUtility.ToHtmlStringRGBA(wheels.color);
        GameManager.instance.SetVariables();
        StartCoroutine(Delay(false));
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
    public void showKart(bool show){
        StartCoroutine(Delay(show));
    }
    IEnumerator Delay(bool show){
        if(show)
        yield return new WaitForSeconds(0.6f);

        kart.SetActive(show);
    }
}
