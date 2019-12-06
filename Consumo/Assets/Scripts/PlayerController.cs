using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    //movement
    private Vector3 moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] float turnThreshold = 0.1f;
    //knockback
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackTime;
    private float knockBackCounter;

    public Vector3 Velocity, PlayerVelocity;
    private Rigidbody myRB;

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
        //characterController = GetComponent<CharacterController>();
        myRB = GetComponent<Rigidbody>();
	}

    #region private properties
    // You must configure the Unity Input Manager
    // to have an axis for each control for each supported player.
    // Begin numbering at 1, as Unity numbers "joysticks" beginning at 1.
    // "Joystick" means gamepad in real life...
    private string HorizontalInputName
    {
        get { return "Horizontal" + ControllingPlayer.PlayerNumber; }
    }
    private string VerticalInputName
    {
        get { return "Vertical" + ControllingPlayer.PlayerNumber; }
    }
    private string FireInputName
    {
        get { return "Fire" + ControllingPlayer.PlayerNumber; }
    }
    private float HorizontalInput
    {
        get { return Input.GetAxisRaw(HorizontalInputName); }
    }
    private float VerticalInput
    {
        get { return Input.GetAxisRaw(VerticalInputName); }
    }

    #endregion

    // Update is called once per frame
    void Update ()
    {
        UpdateVelocityInput();
    }
    private void FixedUpdate()
    {
        PlayerMovementAndRotation();
    }

    private void UpdateVelocityInput()
    {
        Velocity.x = Input.GetAxisRaw(HorizontalInputName);
        Velocity.z = Input.GetAxisRaw(VerticalInputName);

        Velocity *= 0.9f;

        PlayerVelocity = Quaternion.Euler(0f, -135f, 0f) * Velocity;
    }
    private void PlayerMovementAndRotation()
    {
        if (Velocity.sqrMagnitude > 0)
        {
            transform.eulerAngles = new Vector3(0, Mathf.Atan2(Velocity.x, Velocity.z) * Mathf.Rad2Deg, 0);
            myRB.MovePosition(myRB.position + Vector3.ClampMagnitude(Velocity,1f) * moveSpeed * Time.deltaTime);
        }
    }


    void PlayerMovement()
    {
        //Allows player to move if they aren't currently being knocked back
        if (knockBackCounter <= 0)
        {
            PlayerMovementAndRotation();
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
    }
    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
    }
}
