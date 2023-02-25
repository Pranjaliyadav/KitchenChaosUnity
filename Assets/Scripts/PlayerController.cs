using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{   
    private bool isWalking;

    [SerializeField] private GameInput gameInput;
    
    
    private void Update() {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDir = new Vector3(inputVector.x,0f,inputVector.y);

        float moveAcceleration = 8f;
        transform.position += moveDir*Time.deltaTime*moveAcceleration;

        isWalking = moveDir != Vector3.zero; //if moveDir is diff than 0,0,0

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);


    }

    public bool IsWalking(){
        return isWalking;
    }
}
