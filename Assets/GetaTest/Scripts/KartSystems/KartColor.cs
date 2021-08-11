using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartColor : MonoBehaviour
{
    public SkinnedMeshRenderer Chasis;
    public SkinnedMeshRenderer Character;
    public MeshRenderer[] Wheels;
    void Awake(){
        Chasis.material.color=GameManager.instance.ChasisColor;
        Character.material.color=GameManager.instance.CharacterColor;
        for(int i=0; i<Wheels.Length; i++)
        Wheels[i].material.color=GameManager.instance.WheelsColor;
    }

}
