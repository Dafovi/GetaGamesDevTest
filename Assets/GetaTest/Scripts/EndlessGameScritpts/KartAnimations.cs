using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;


public class KartAnimations : MonoBehaviour
{
    #region Variables
    [Header("Player")]
    [SerializeField] private Animator PlayerAnimator;
    [SerializeField] private PlayerController Kart;


    [Header("Animator parameters"),Space(10)]
    [SerializeField] private string SteeringParam = "Steering";
    [SerializeField] private string GroundedParam = "Grounded";
    
    [Header("Wheels"),Space(10)]
    [SerializeField] private Transform WheelFrontLeft;
    [SerializeField] private Transform WheelFrontRight;
    
    [Header("Wheels Drift Trails"),Space(10)]
    [SerializeField] private TrailRenderer FRWheelDriftTrail;
    [SerializeField] private TrailRenderer FLWheelDriftTrail;
    [SerializeField] private TrailRenderer RRWheelDriftTrail;
    [SerializeField] private TrailRenderer RLWheelDriftTrail;
    
    [Header("Jump Particle Prefab"),Space(10)]
    [SerializeField] private GameObject JumpVFX;
    
    [Header("FX AudioSource"),Space(10)]
    [SerializeField] private AudioSource jumpSound, driftSound;

    private GameObject[] JumpsParticles;

    private int m_SteerHash, m_GroundHash;

    private float steeringSmoother;
    private float horizontal;
    #endregion

    void Awake()
    {
        Assert.IsNotNull(Kart, "No ArcadeKart found!");
        Assert.IsNotNull(PlayerAnimator, "No PlayerAnimator found!");
        m_SteerHash  = Animator.StringToHash(SteeringParam);
        m_GroundHash = Animator.StringToHash(GroundedParam);
        
        wheelsTrails(false);
    }

    void Update()
    {
        //Establece el giro de las ruedas y la animacion del personaje segun la tecla pulsada

        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            StopAllCoroutines();
            horizontal = 1;
            StartCoroutine(Delay());
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            StopAllCoroutines();
            horizontal = -1;
            StartCoroutine(Delay());
        }
    
        wheelRotation(WheelFrontLeft);
        wheelRotation(WheelFrontRight);

        steeringSmoother = Mathf.Lerp(steeringSmoother, horizontal, Time.deltaTime * 5f);
        PlayerAnimator.SetFloat(m_SteerHash, steeringSmoother);

        PlayerAnimator.SetBool(m_GroundHash, Kart.isKarGrounded);

        JumpFx();
    }
    IEnumerator Delay(){
        //Activa y espera un momento para desactivar los efectos y animaciones del cambio de carril

        wheelsTrails(true);
        
        if(Kart.isDrivable)
        driftSound.Play();

        yield return new WaitForSeconds(0.25f);
        horizontal=0;
        wheelsTrails(false);

        
        if(Kart.isDrivable)
        driftSound.Stop();
    }
    private void wheelRotation(Transform wheel){
    //Establece la rotacion de las ruedas
        wheel.transform.rotation=Quaternion.Euler(0f,horizontal*45,0f);
    }
    private void JumpFx(){
        //Si el personaje no esta tocando la carretera y no hay muchos efectos de salto activos...
        //Activa las particulas y el sonido de salto

        JumpsParticles=GameObject.FindGameObjectsWithTag("jumpDust");
        if (!Kart.isKarGrounded && JumpsParticles.Length<=10){
            GameObject fx = Instantiate(JumpVFX);
            fx.transform.position= new Vector3(transform.position.x,transform.position.y-0.85f,transform.position.z);
            jumpSound.Play();
        }  
    }
    private void wheelsTrails(bool status){
        //Activa o desactiva el trail de las ruedas
        FLWheelDriftTrail.emitting = status;
        FRWheelDriftTrail.emitting = status;
        RRWheelDriftTrail.emitting = status;
        RLWheelDriftTrail.emitting = status;
    }

}
