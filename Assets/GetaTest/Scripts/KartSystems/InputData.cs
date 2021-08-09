using UnityEngine;

public class InputData : MonoBehaviour
{
    
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    public float horizontalInput;
    public float verticalInput;
    public bool isDrifting;
    public bool boost;


    void Update(){
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isDrifting = Input.GetKey(KeyCode.LeftControl);
        boost= Input.GetKeyDown(KeyCode.LeftShift);
    }
}
