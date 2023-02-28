using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    //private PlayerInputActions playerInputActions;

    //private void Awake()
    //{
    //    playerInputActions = new PlayerInputActions();
    //    playerInputActions.Player.Enable(); //this is how you enable Input Actions 
    //}
    public Vector3 GetMovementVectorNormalized()
    {

        Vector3 moveDir = new Vector3(0, 0, 0);

        //playerInputActions.Player.Move.ReadValue<Vector3>();
        if (Input.GetKey(KeyCode.W))
        {
            moveDir.z += +1f;
        }
        if (Input.GetKey(KeyCode.S))
        {
            moveDir.z += -1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveDir.x += -1f;
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveDir.x += +1f;
        }
        moveDir = moveDir.normalized; //this way if you press two keys at once it'll move same amount in both direction diagnonally summing to 1
        return moveDir;
    }
}