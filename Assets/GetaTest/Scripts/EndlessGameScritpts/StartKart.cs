using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartKart : MonoBehaviour
{
    void Start()
    {
      PlayerController kartController = FindObjectOfType<PlayerController>();
      kartController.isDrivable=true;
    }
}
