using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    public Camera playerCamera;
    public Transform camTrans;

    [Header("General")]
    public float gravitiScale = -20f;

    [Header("Move")]
    public float WalkSpeed = 5f;
    public float RunSpeed = 10f;

    [Header("Jump")]
    public float jumpHeight = 1.9f;

    [Header("Rotation")]
    public float rotationSens = 10f;

    [Header("Shoot")]
    public GameObject bullet;
    public Transform firePoint;
    

    private float cameraVertAngle;

    Vector3 rotationinput = Vector3.zero;
    Vector3 moveInput = Vector3.zero;
    CharacterController characterController;
   
    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        Look();
        CursorH();
        ShootGun();
    }

    private void Move()
    {
        if (characterController.isGrounded)
        {
            moveInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
            moveInput = Vector3.ClampMagnitude(moveInput, 1f);
            if (Input.GetButton("Sprint"))
            {
                moveInput = transform.TransformDirection(moveInput) * RunSpeed;
            }
            else
            {
                moveInput = transform.TransformDirection(moveInput) * WalkSpeed;
            }
            

            if (Input.GetButtonDown("Jump"))
            {
                moveInput.y = Mathf.Sqrt(jumpHeight * -2f * gravitiScale);
            }
        }

        moveInput.y += gravitiScale * Time.deltaTime;
        characterController.Move(moveInput * Time.deltaTime);
    }

    private void Look()
    {
        rotationinput.x = Input.GetAxis("Mouse X") * rotationSens * Time.deltaTime;
        rotationinput.y = Input.GetAxis("Mouse Y") * rotationSens * Time.deltaTime;

        cameraVertAngle = cameraVertAngle + rotationinput.y;
        cameraVertAngle = Mathf.Clamp(cameraVertAngle, -70, 70);

        transform.Rotate(Vector3.up * rotationinput.x);
        playerCamera.transform.localRotation = Quaternion.Euler(-cameraVertAngle, 0f, 0f);
    }

    private void CursorH()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
    public void ShootGun()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(camTrans.position,camTrans.forward, out hit, 50f))
            {
                if(Vector3.Distance(camTrans.position, hit.point)< 2f)
                {
                    firePoint.LookAt(hit.point);
                }
                else
                {
                    firePoint.LookAt(camTrans.position + (camTrans.forward *30f));
                }
            }
           
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }
}
