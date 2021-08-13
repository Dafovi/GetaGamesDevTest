using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartStart : MonoBehaviour
{
    void Start()
    {
      KartController kartController = FindObjectOfType<KartController>();
      kartController.isDrivable=true;
    }

}
