using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    [SerializeField]
    private float maxSpeed=10;

    public float moveSpeed;
    
    private Rigidbody myRB;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    public float knockBackForce;
    public float knockBackTime;
    private float knockBackCounter;

    // Use this for initialization
    void Start () 
	{
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
            moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
            moveVelocity = moveInput * moveSpeed;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        
    }
    void FixedUpdate()
    {
        float currentSpeed = Mathf.Abs(myRB.velocity.magnitude);
        if (currentSpeed<maxSpeed)
        {
            myRB.AddForce(moveVelocity);
        }
    }

    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveVelocity = direction * knockBackForce;
    }
}
