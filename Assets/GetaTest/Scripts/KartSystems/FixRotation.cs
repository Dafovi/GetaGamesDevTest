using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    private bool isOverturned;
    public LayerMask groundLayer;
    void Update()
    {
        //Si el "kart" se vuelca, corrige su rotación

        RaycastHit hit;
        isOverturned=Physics.Raycast(transform.position, transform.up, out hit, 1f, groundLayer);
       
        if(isOverturned)
        transform.rotation=Quaternion.Euler(transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y,0F);
    }
}
