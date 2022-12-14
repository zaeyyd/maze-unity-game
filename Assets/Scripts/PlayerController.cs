using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float turnSpeed = 250f;
    public float speed = 5f;

    public bool hasRedKey;
    public bool hasBlueKey;
    public bool hasGreenKey;

    public bool atEnd;

    Animator m_Animator;
    // Rigidbody m_Rigidbody;
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity;

    void Start ()
    {
        m_Animator = GetComponent<Animator> ();
    }

    void FixedUpdate ()
    {
        float horizontal = Input.GetAxis ("Horizontal");
        float vertical = Input.GetAxis ("Vertical");
        
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize ();

        bool hasHorizontalInput = !Mathf.Approximately (horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately (vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool ("isWalking", isWalking);


        var velocity = Vector3.forward * Input.GetAxis("Vertical") * speed;
        transform.Translate(velocity * Time.deltaTime);
        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * turnSpeed);

    }

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "greenKey"){
            hasGreenKey = true;
            Destroy(other.gameObject);

        }
        if (other.tag == "redKey"){
            hasRedKey = true;
            Destroy(other.gameObject);
        }
        if (other.tag == "blueKey"){
            hasBlueKey = true;
            Destroy(other.gameObject);
        }
        if (other.name == "END"){
            atEnd = true;
        }
        
    }

    private void OnCollisionEnter(Collision other) {

        if (other.gameObject.tag == "blueDoor" && hasBlueKey){
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "redDoor" && hasRedKey){
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "greenDoor" && hasGreenKey){
            Destroy(other.gameObject);
        }
    }

}
