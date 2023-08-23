using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidboody;
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float JumpForce = 5f;

    [SerializeField] Transform groundcheck;
    [SerializeField] LayerMask ground;


    [SerializeField] AudioSource jumpsound;
    // Start is called before the first frame update
    void Start()
    {
        rigidboody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticallInput = Input.GetAxis("Vertical");

        rigidboody.velocity = new Vector3(horizontalInput * MovementSpeed, rigidboody.velocity.y, verticallInput * MovementSpeed);

        if (Input.GetButton("Jump") && IsGrounded())
        {
            jump();
        }
    }

    void jump()
    {
        rigidboody.velocity = new Vector3(rigidboody.velocity.x, JumpForce, rigidboody.velocity.z);
        jumpsound.Play();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy Head"))
        {
            Destroy(collision.transform.parent.gameObject);
            jump();
        }
    }

    bool IsGrounded()
    {
       return Physics.CheckSphere(groundcheck.position, .1f, ground);
    }
}
