using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    private void Update() {
        Vector3 moveDir =new Vector3(0,0,0);
        if(Input.GetKey(KeyCode.W)){
            moveDir.z += +1f;
        }
        if(Input.GetKey(KeyCode.S)){
            moveDir.z += -1f;
        }
        if(Input.GetKey(KeyCode.A)){
            moveDir.x += -1f;
        }
        if(Input.GetKey(KeyCode.D)){
            moveDir.x += +1f;
        }

        moveDir = moveDir.normalized; //this way if you press two keys at once it'll move same amount in both direction diagnonally summing to 1
        float moveAcceleration = 8f;
        transform.position += moveDir*Time.deltaTime*moveAcceleration;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward,moveDir,Time.deltaTime*rotateSpeed);


    }
}