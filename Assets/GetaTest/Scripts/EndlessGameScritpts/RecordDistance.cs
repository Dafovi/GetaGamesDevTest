
using UnityEngine;
using UnityEngine.UI;

public class RecordDistance : MonoBehaviour
{
    public float distance,velocity;
    public GameObject StartLine;
    public Transform Kart;
    private Vector3 LineStart = new Vector3(0f,0f,8.24f);
    private PlayerController kartController;
    public Text winnerText,loserText,meters;

    void Start()
    {
        kartController=Kart.transform.GetComponent<PlayerController>();
    }

    void Update()
    {
        distance=Vector3.Distance(LineStart,Kart.position);

        if(distance>10)Destroy(StartLine);
        
        if(distance>=100 && distance<=200)
        velocity=distance/10;
        else if(distance>=400 && distance<=600)
        velocity=distance/20;
        else if(distance>=900 && distance<=1200)
        velocity=distance/30;
        else if(distance>=1600 && distance <=2500)
        velocity=distance/40;
        else if(distance>=3600 && distance <=6400)
        velocity=distance/60;
        else if(distance>=10000)
        velocity=distance/100;


        kartController.forwardSpeed=velocity;
        if(distance>=2.6f)
        meters.text=distance.ToString("00")+"m";

        if(PlayerManager.gameOver){
            loserText.text="Distancia recorrida: "+distance.ToString("00")+"m\n Récord actual: "+ GameManager.instance.MetersRecord.ToString("00")+"m";
            winnerText.text = distance.ToString("00")+"m";
        }

    }
}
