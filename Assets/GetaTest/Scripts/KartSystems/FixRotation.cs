using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixRotation : MonoBehaviour
{
    public bool isOverturned;
    public LayerMask groundLayer;
    void Update()
    {
        RaycastHit hit;
        isOverturned=Physics.Raycast(transform.position, transform.up, out hit, 1f, groundLayer);
       
        if(isOverturned)
        transform.rotation=Quaternion.Euler(transform.localRotation.eulerAngles.x,transform.localRotation.eulerAngles.y,0F);
    }
}
