using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody myRB;
    public CharacterController characterController;
    //movement
    private Vector3 moveDirection;
    public float moveSpeed;
    public float gravityScale;
    //knockback
    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;
    

    // Use this for initialization
    void Start () 
	{
        characterController = GetComponent<CharacterController>();
        myRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
	{
        PlayerMovement();
	}

    void PlayerMovement()
    {
        if (knockBackCounter<=0)
        {
            moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection = moveDirection.normalized * moveSpeed;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        characterController.Move(moveDirection * Time.deltaTime);
    }
    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
    }
}
