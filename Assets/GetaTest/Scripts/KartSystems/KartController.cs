using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public class KartController : MonoBehaviour
{
    #region Variables

    [Header("Kart status")]
    public bool isKarGrounded =true;
    public bool isDrivable;
    public LayerMask groundLayer;
    public InputData Input;

    [Header("Kart Variables"),Space(10)]
    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerInAngle;
    [SerializeField] public float aceleration;
    [SerializeField] private float reverseAcceleration;
    [SerializeField] public float speed;
    [SerializeField] private float turn;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float airDrag;
    [SerializeField] private float groundDrag;
    [SerializeField] private float gravityForce;
    [SerializeField] private float currentSteerAngle;

    [Header("Wheels Colliders"),Space(10)]
    [SerializeField] public WheelCollider FrontLeftWheel;
    [SerializeField] public WheelCollider FrontRightWheel;
    [SerializeField] public WheelCollider RearLeftWheel;
    [SerializeField] public WheelCollider RearRightWheel;

    [Header("Wheels Transforms"),Space(4)]
    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;
    

    [Header("Kart"),Space(10)]
    public Rigidbody KartCenterMass;
    
    #endregion

    void FixedUpdate(){
        
        //Observa si el "Kart" esta sobre una superficie "ground"
        RaycastHit hit;
        isKarGrounded=Physics.Raycast(transform.position, - transform.up, out hit, 1f, groundLayer);

        if(isDrivable){
            KartMove();
            HandleMotor();
            HandleStreering();
            UpdateWheels();
            Drift();       
        } 
    }
    void KartMove(){
        //Define la rotacion del "Kart"
        float newRotation = Input.horizontalInput * turnSpeed * Time.deltaTime * Input.verticalInput;
        transform.Rotate(0,newRotation,0,Space.World);

        //Si el "Kart" esta en el aire aplica una caida mas fuerte
        if(isKarGrounded)
        KartCenterMass.drag = groundDrag;
        else 
        KartCenterMass.drag = airDrag;

        //Si el "Kart" esta sobre el suelo, se esta presionando la tecla de acelerar y no se a sobrepasado la velocidad maxima
        if(KartCenterMass.velocity.magnitude<=maxSpeed && isKarGrounded && Input.verticalInput!=0)
        //Acelera el "Kart"
        KartCenterMass.AddForce(transform.forward * speed , ForceMode.Acceleration);
        //De lo contrario lo hace caer
        else KartCenterMass.AddForce(transform.up * gravityForce);

        
        //Ajusta la velocidad del "Kart"
        speed = Input.verticalInput;
        speed *= speed > 0 ? aceleration : reverseAcceleration;
    }

    void HandleMotor(){
        //Establece la dirección del giro de las ruedas segun el Input Axis Vertical por la fuerza del motor
        FrontLeftWheel.motorTorque = Input.verticalInput * motorForce;
        FrontRightWheel.motorTorque = Input.verticalInput * motorForce;
    }


    void HandleStreering(){
        //Establece el giro maximo de las ruedas al presionar Input Axis Horizontal
        currentSteerAngle = maxSteerInAngle * Input.horizontalInput;
        FrontLeftWheel.steerAngle = currentSteerAngle;
        FrontRightWheel.steerAngle = currentSteerAngle;
    }

    void UpdateWheels(){
        UpdateSinfleWheel(FrontLeftWheel, FrontLeftWheelTransform);
        UpdateSinfleWheel(FrontRightWheel, FrontRightWheelTransform);
        UpdateSinfleWheel(RearLeftWheel, RearLeftWheelTransform);
        UpdateSinfleWheel(RearRightWheel, RearRightWheelTransform);
    }

    void UpdateSinfleWheel(WheelCollider WheelCollider, Transform WheelTransform){
        //Actualiza la rotación y posición de cada rueda
        Vector3 pos;
        Quaternion rot;
        WheelCollider.GetWorldPose(out pos, out rot);
        WheelTransform.rotation = rot;
        WheelTransform.position = pos;
    }

    void Drift(){
        //Establece la velocidad de giro cuando se esta derrapando
        if(KartCenterMass.velocity.magnitude>=10)
        turnSpeed = Input.isDrifting ? turn*2 : turn;

        if(Input.isDrifting && Input.horizontalInput==0 && isKarGrounded)
        KartCenterMass.AddForce(transform.forward * speed*-0.8f, ForceMode.Acceleration);
    }   

}
