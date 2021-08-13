using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;
    private int desiredLane = 1;//0:left, 1:middle, 2:right
    public float laneDistance = 2.5f;//The distance between two lanes
    public float Gravity = -20;
    public bool isDrivable;
    public bool isKarGrounded=true;
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if(isDrivable)
        kartMove();
    }
    private void FixedUpdate()
    {
        if(isDrivable){
            controller.Move(direction * Time.deltaTime);
            changeLine();
        }

    }
    private void kartMove(){
        direction.z= forwardSpeed;
    
        isKarGrounded=controller.isGrounded;

        if(isKarGrounded){
            direction.y=-1;
        }else 
        direction.y += Gravity* Time.deltaTime;

        //Gather the inputs on which lane we should be
        
        if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)){
            desiredLane++;
            if(desiredLane == 3) desiredLane = 2;
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)){
            desiredLane--;
            if(desiredLane == -1) desiredLane=0;
        }
    }
    private void changeLine(){
        //Calculate where we should be in the future

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if(desiredLane==0)
        targetPosition += Vector3.left * laneDistance;
        else if(desiredLane==2)
        targetPosition += Vector3.right * laneDistance;

        if(transform.position == targetPosition) return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized *25 * Time.deltaTime;
        if(moveDir.sqrMagnitude < diff.sqrMagnitude)
        controller.Move(moveDir);
        else
        controller.Move(diff);
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.transform.tag=="Obstacle"){
            PlayerManager.gameOver=true;
        }
    }
}
