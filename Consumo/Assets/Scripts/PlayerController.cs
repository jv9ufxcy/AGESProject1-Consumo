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
    [SerializeField] float turnThreshold = 0.1f;
    public float gravityScale;
    //knockback
    [SerializeField] private float knockBackForce;
    [SerializeField] private float knockBackTime;
    private float knockBackCounter;

    //[SerializeField] private Transform pivot;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Transform pivot;
    [SerializeField] private GameObject playerModel;

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
        UpdateRotation();
        UpdateMovement();
    }

    void PlayerMovement()
    {
        //Allows player to move if they aren't currently being knocked back
        if (knockBackCounter<=0)
        {
            moveDirection = (transform.forward * VerticalInput) + (transform.right * HorizontalInput);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection = moveDirection.normalized * moveSpeed;
        }
        else
        {
            knockBackCounter -= Time.deltaTime;
        }
        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        characterController.Move(moveDirection * Time.deltaTime);


        //if (myRB.velocity != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.LookRotation(myRB.velocity);
        //}
        //if (HorizontalInput!=0||VerticalInput!=0)
        //{
        //    transform.rotation = Quaternion.Euler(0, pivot.rotation.eulerAngles.y, 0f);
        //    //TODO: Make player rotate in movement direction instead of rotating like a tank
        //    Quaternion newRotation = Quaternion.LookRotation(new Vector3(moveDirection.x,0,moveDirection.z));

        //    playerModel.transform.rotation = Quaternion.Slerp(playerModel.transform.rotation, newRotation, rotateSpeed * Time.deltaTime);
        //}
    }
    private void UpdateRotation()
    {
        // Debug.DrawRay(rigidbody.position, moveDirection * 3, Color.red);
        
        if (moveDirection.magnitude > turnThreshold)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveDirection);
            newRotation.eulerAngles = new Vector3(0, newRotation.eulerAngles.y, 0);
            myRB.transform.rotation = newRotation;
        }
    }
    private void UpdateMovement()
    {
        myRB.MovePosition(myRB.position + (moveDirection * moveSpeed * Time.deltaTime));
    }
    public void Knockback(Vector3 direction)
    {
        knockBackCounter = knockBackTime;

        moveDirection = direction * knockBackForce;
    }
}
