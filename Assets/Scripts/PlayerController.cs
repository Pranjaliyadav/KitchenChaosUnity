using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 lastInteractDir;
    private bool isWalking;

    //[SerializeField] private GameInput gameInput;
    float moveAcceleration = 7f;
    float rotateSpeed = 10f;

    private void Update() {
        Vector3 moveDir = new Vector3(0, 0, 0);
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

        float moveDistance = moveAcceleration * Time.deltaTime;

        float playerHeight = 2f;


        float playerRadius = 0.7f;
        bool canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDir, moveDistance); //can move if this raycast doesnt hit anything


        if (!canMove)
        {
            //cant move towards moveDir

            //attempt only X movement
            Vector3 moveDirX = new Vector3(moveDir.x, 0, 0).normalized;

            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirX, moveDistance);

            if (canMove)
            {
                //can move only on x
                moveDir = moveDirX;
            }
            else
            {
                Vector3 moveDirZ = new Vector3(0, 0, moveDir.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerHeight, playerRadius, moveDirZ, moveDistance);

                if (canMove)
                {
                    //can move only on z
                    moveDir = moveDirZ;
                }
                else
                {
                    //cannot move in any direction

                }
            }

        }

        if (canMove)
        {
            transform.position += moveDir * moveDistance;
        }

        isWalking = moveDir != Vector3.zero; //if moveDir is diff than 0,0,0


        if (moveDir != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);
        }
        HandleInteractions();

    }
    public bool IsWalking(){
        return isWalking;
    }

    public void HandleMovement()
    {
        
    }

    public void HandleInteractions()
    {

        Vector3 moveDir = new Vector3(0, 0, 0);
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

        moveDir = moveDir.normalized;

        if(moveDir != Vector3.zero)
        {
            lastInteractDir = moveDir; //for that case when player is standing just next to counter and not moving, we store this position and use this
        }

        float interactDistance = 2f;
        if(Physics.Raycast(transform.position, lastInteractDir, out RaycastHit raycastHit, interactDistance))
        {//give raycastHit output
            Debug.Log(raycastHit.transform);
        }
        else
        {

            Debug.Log("---");
        }

        //RaycastHit a struct to get infor back froma raycast
    }
}
