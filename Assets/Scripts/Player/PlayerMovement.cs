﻿// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float speed = 6f;
//     Vector3 movement;
//     Animator anim;
//     Rigidbody playerRigidbody;
//     int floorMask;
//     float camRayLength = 100f;


//     void Awake()
//     {
//         floorMask = LayerMask.GetMask("Floor");

//         anim = GetComponent<Animator>();
//         playerRigidbody = GetComponent<Rigidbody>();
//     }

//     void FixedUpdate()
//     {
//         float h = Input.GetAxisRaw("Horizontal");
//         float v = Input.GetAxisRaw("Vertical");

//         Move(h, v);
//         Turning();
//         Animating(h, v);
//     }

//     void Move(float h, float v)
//     {
//         movement.Set(h, 0f, v);
//         movement = movement.normalized * speed * Time.deltaTime;
//         playerRigidbody.MovePosition(transform.position + movement);
//     }

//     void Turning()
//     {
//         Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
//         RaycastHit floorHit;
//         if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
//         {
//             Vector3 playerToMouse = floorHit.point - transform.position;
//             playerToMouse.y = 0f;
//             Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
//             playerRigidbody.MoveRotation(newRotation);
//         }
//     }

//     void Animating(float h, float v)
//     {
//         bool walking = h != 0f || v != 0f;
//         anim.SetBool("IsWalking", walking);
//     }


// }
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 6f;
    public LayerMask floorMask;
    float camRayLength = 100f;
    Vector3 movement;
    Animator anim;
    Rigidbody playerRigidbody;
    void Awake()
    {
        floorMask = LayerMask.GetMask("Floor");
        anim = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Move(h, v);
        Turning();
        Animating(h, v);
    }

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);
        movement = movement.normalized * speed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray camRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit floorHit;
        Debug.Log("Ray origin: " + camRay.origin + ", direction: " + camRay.direction);
        if (Physics.Raycast(camRay, out floorHit, camRayLength, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;
            playerToMouse.y = 0f;
            Quaternion newRotation = Quaternion.LookRotation(playerToMouse);
            playerRigidbody.MoveRotation(newRotation);
        }
    }

    void Animating(float h, float v)
    {
        bool walking = h != 0f || v != 0f;
        anim.SetBool("IsWalking", walking);
    }
}