using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KartVFX : MonoBehaviour
{
    #region Variables
    [Header("Wheels Trails")]
    public TrailRenderer FRWheelDriftTrail;
    public TrailRenderer FLWheelDriftTrail;
    public TrailRenderer RRWheelDriftTrail;
    public TrailRenderer RLWheelDriftTrail;


    [Header("Wheels Trails"),Space(10)]
    public GameObject FRWheelDriftFX;
    public GameObject FLWheelDriftFX;
    public GameObject RRWheelDriftFX;
    public GameObject RLWheelDriftFX;


    [Header("Jump"),Space(10)]
    public GameObject JumpVFX;
    public AudioSource jumpSound;


    [Header("Kart status"),Space(10)]
    public float GroundPercent;
    public float m_PreviousGroundPercent = 1.0f;
    public float AirPercent;
    public bool driftStatus;

    KartController kartController;
    #endregion
    void Start()
    {
        kartController = GetComponentInParent<KartController>();
    }

    void Update()
    {
        Drift();   
        jumpFXDust();
    }

    void Drift(){
        //Si se esta avtivando la tecla de derrape, se activan las particulas y lineas de derrape
        if(kartController.isDrivable){
            if(kartController.isKarGrounded) driftStatus= kartController.Input.isDrifting;
        }
        else driftStatus = false;

        FLWheelDriftTrail.emitting = driftStatus;
        FRWheelDriftTrail.emitting = driftStatus;
        RRWheelDriftTrail.emitting = driftStatus;
        RLWheelDriftTrail.emitting = driftStatus;

        FRWheelDriftFX.SetActive(driftStatus);
        FLWheelDriftFX.SetActive(driftStatus);
        RRWheelDriftFX.SetActive(driftStatus);
        RLWheelDriftFX.SetActive(driftStatus);
    }

    public void jumpFXDust(){
        int groundedCount = 0;
            if (kartController.FrontLeftWheel.isGrounded && kartController.FrontLeftWheel.GetGroundHit(out WheelHit hit))
                groundedCount++;
            if (kartController.FrontRightWheel.isGrounded && kartController.FrontRightWheel.GetGroundHit(out hit))
                groundedCount++;
            if (kartController.RearLeftWheel.isGrounded && kartController.RearLeftWheel.GetGroundHit(out hit))
                groundedCount++;
            if (kartController.RearRightWheel.isGrounded && kartController.RearRightWheel.GetGroundHit(out hit))
                groundedCount++;
        // calculate how grounded and airborne we are
        GroundPercent = (float) groundedCount / 4.0f;
        AirPercent = 1 - GroundPercent;
        
        //m_PreviousGroundPercent = GroundPercent;

        if (GroundPercent > 0.0f){
            if (!kartController.isKarGrounded){
                GameObject fx = Instantiate(JumpVFX);
                fx.transform.position= new Vector3(transform.position.x,transform.position.y-0.85f,transform.position.z);
                jumpSound.Play();
            }
        }
        
    }
}
