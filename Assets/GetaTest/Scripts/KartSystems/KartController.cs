using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
public class KartController : MonoBehaviour
{
    #region Variables

    private float currentSteerAngle;
    private bool isKarGrounded;
    private bool dntOnRoad;

    [SerializeField] private float motorForce;
    [SerializeField] private float maxSteerInAngle;
    [SerializeField] public float aceleration;
    [SerializeField] private float reverseAcceleration;
    [SerializeField] private float speed;
    [SerializeField] private float turn;
    [SerializeField] private float turnSpeed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float airDrag;
    [SerializeField] private float groundDrag;
    [SerializeField] private float gravityForce;

    [SerializeField] private WheelCollider FrontLeftWheel;
    [SerializeField] private WheelCollider FrontRightWheel;
    [SerializeField] private WheelCollider RearLeftWheel;
    [SerializeField] private WheelCollider RearRightWheel;

    [SerializeField] private Transform FrontLeftWheelTransform;
    [SerializeField] private Transform FrontRightWheelTransform;
    [SerializeField] private Transform RearLeftWheelTransform;
    [SerializeField] private Transform RearRightWheelTransform;

    public Rigidbody KartCenterMass;
    public LayerMask groundLayer;
    public LayerMask outRoad;
    public InputData Input;
    public Vector3 checkPoint = Vector3.zero;
    public bool isDrivable;
    
    #endregion

    void FixedUpdate(){
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

        //Observa si el "Kart" esta sobre una superficie "ground"
        RaycastHit hit;
        isKarGrounded=Physics.Raycast(transform.position, - transform.up, out hit, 1f, groundLayer);
        dntOnRoad=Physics.Raycast(transform.position, - transform.up, out hit, 1f, outRoad);

        
        //Si el "Kart" esta en el aire aplica una caida mas fuerte
        if(isKarGrounded)
        KartCenterMass.drag = groundDrag;
        else 
        KartCenterMass.drag = airDrag;

        if(dntOnRoad && transform.position.y<0.9f && !isKarGrounded)
        transform.position=new Vector3(checkPoint.x,checkPoint.y+0.93f,checkPoint.z);

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
        if(KartCenterMass.velocity.magnitude>=10)
        turnSpeed = Input.isDrifting ? turn*2 : turn;

        if(Input.isDrifting && Input.horizontalInput==0 && isKarGrounded)
        KartCenterMass.AddForce(transform.forward * speed*-0.8f, ForceMode.Acceleration);
    }   

}
