using UnityEngine;
using UnityEngine.Assertions;
using System.Collections;


public class KartAnimations : MonoBehaviour
{
    public Animator PlayerAnimator;
    public PlayerController Kart;

    public string SteeringParam = "Steering";
    public string GroundedParam = "Grounded";

    int m_SteerHash, m_GroundHash;

    float steeringSmoother;
    public float horizontal;
    public Transform WheelFrontLeft,WheelFrontRight;
    public GameObject JumpVFX;
    public AudioSource jumpSound, driftSound;

    public TrailRenderer FRWheelDriftTrail,FLWheelDriftTrail,RRWheelDriftTrail,RLWheelDriftTrail;
    public GameObject[] JumpsParticles;

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
        wheel.transform.rotation=Quaternion.Euler(0f,horizontal*45,0f);
    }
    private void JumpFx(){
        JumpsParticles=GameObject.FindGameObjectsWithTag("jumpDust");
        if (!Kart.isKarGrounded && JumpsParticles.Length<=10){
            GameObject fx = Instantiate(JumpVFX);
            fx.transform.position= new Vector3(transform.position.x,transform.position.y-0.85f,transform.position.z);
            jumpSound.Play();
        }  
    }
    private void wheelsTrails(bool status){
        FLWheelDriftTrail.emitting = status;
        FRWheelDriftTrail.emitting = status;
        RRWheelDriftTrail.emitting = status;
        RLWheelDriftTrail.emitting = status;
    }

}
