using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    private Rigidbody myRB;
    [SerializeField] private CharacterController characterController;
    //movement
    private Vector3 moveDirection;
    [SerializeField]    private float moveSpeed;
    public float gravityScale;
    //knockback
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackTime;
    private float knockBackCounter;

    private Player controllingPlayer_UseProperty;

    public Player ControllingPlayer
    {
        get { return controllingPlayer_UseProperty; }
        set
        {
            controllingPlayer_UseProperty = value;
        }
    }
    // Use this for initialization
    void Start () 
	{
        characterController = GetComponent<CharacterController>();
        myRB = GetComponent<Rigidbody>();
	}

    #region private properties
    private float HorizontalInput
    {
        get { return Input.GetAxisRaw(HorizontalInputName); }
    }

    private float VerticalInput
    {
        get { return Input.GetAxisRaw(VerticalInputName); }
    }

    // You must configure the Unity Input Manager
    // to have an axis for each control for each supported player.
    // Begin numbering at 1, as Unity numbers "joysticks" beginning at 1.
    // "Joystick" means gamepad in real life...
    private string HorizontalInputName
    {
        get
        {
            return "Horizontal" + ControllingPlayer.PlayerNumber;
        }
    }

    private string VerticalInputName
    {
        get
        {
            return "Vertical" + ControllingPlayer.PlayerNumber;
        }
    }

    private string FireInputName
    {
        get
        {
            return "Fire" + ControllingPlayer.PlayerNumber;
        }
    }
    #endregion

    // Update is called once per frame
    void Update () 
	{
        PlayerMovement();
	}

    void PlayerMovement()
    {
        //Allows player to move if they aren't currently being knocked back
        if (knockBackCounter<=0)
        {
            //moveDirection = (transform.forward * Input.GetAxisRaw("Vertical")) + (transform.right * Input.GetAxisRaw("Horizontal"));
            moveDirection = (transform.forward * VerticalInput) + (transform.right * HorizontalInput);
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
