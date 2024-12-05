using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RTS {
public class RTSCameraController : MonoBehaviour
{
    public float moveSpeed; 
    Vector3 movement; 
   void OnMove(InputValue value){
    Vector2 direction = value.Get<Vector2>();
    movement = new Vector3(direction.x, 0, direction.y);
   }

    // Update is called once per frame
    void Update()
    {
       Vector3 checkPosition = transform.position + movement * moveSpeed * Time.deltaTime;
       checkPosition += new Vector3(0, 10f, 0);
       bool hitGround = Physics.Raycast(checkPosition, Vector3.down, Mathf.Infinity, LayerMask.GetMask("Ground"));
         if(hitGround) {
        transform.position += movement * moveSpeed * Time.deltaTime;
        }
    }
}
}
