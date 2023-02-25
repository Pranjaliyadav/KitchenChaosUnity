using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private void Awake() {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable(); //this is how you enable Input Actions 
    }
   public Vector2 GetMovementVectorNormalized(){


        Vector2 moveDir =  playerInputActions.Player.Move.ReadValue<Vector3>();
        moveDir = moveDir.normalized; //this way if you press two keys at once it'll move same amount in both direction diagnonally summing to 1
        
         return moveDir;

   }
}
