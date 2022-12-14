using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float maxSpeed = 1.0f;
    public float normalSpeed = 10.0f;
    public float sprintspeed = 20.0f;
    public float rotation = 0.0f;
    public float camRotation = 0.0f;
    GameObject cam;
    Rigidbody myRigidbody;

    bool isOnGround;
    public GameObject groundChecker;
    public LayerMask groundLayer;
    public float jumpForce = 300.0f;

    public float rotationSpeed = 0.5f;
    public float camRotationSpeed = 0.5f;

    public float maxSprint = 5.0f;
    float sprintTimer;
    internal float height;

    public AudioClip Forest;
    public AudioSource ForestPlayer;

   

    Animator myAnimator;

    void Start()
    {
        myAnimator = GetComponentInChildren<Animator>();

        Cursor.lockState = CursorLockMode.Locked;

        sprintTimer = maxSprint;

        cam = GameObject.Find("Main Camera");
        myRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        isOnGround = Physics.CheckSphere(groundChecker.transform.position, 0.1f, groundLayer);

        if (isOnGround == true && Input.GetKeyDown(KeyCode.Space))
        {
            myRigidbody.AddForce(transform.up * jumpForce);
        }

        if (Input.GetKey(KeyCode.LeftShift) && sprintTimer > 0.0f)
        {
            maxSpeed = sprintspeed;
            sprintTimer = sprintTimer - Time.deltaTime;
        } else
        {
            maxSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.LeftShift) == false)
            {
                sprintTimer = sprintTimer + Time.deltaTime;
            }
        }

        sprintTimer = Mathf.Clamp(sprintTimer, 0.0f, maxSprint);

       //transform.position = transform.position + (transform.forward * Input.GetAxis("Vertical") * maxSpeed);
       Vector3 newVelocity = transform.forward * Input.GetAxis("Vertical") * (maxSpeed) * maxSpeed + (transform.right * Input.GetAxis("Horizontal") * maxSpeed);

        myAnimator.SetFloat("speed", newVelocity.magnitude);
        Debug.Log("Sprint"); 

        myRigidbody.velocity = new Vector3(newVelocity.x, myRigidbody.velocity.y, newVelocity.z);

        rotation = rotation + Input.GetAxis("Mouse X") * rotationSpeed;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, rotation, 0.0f));

        camRotation = camRotation + Input.GetAxis("Mouse Y") * camRotationSpeed;
        cam.transform.localRotation = Quaternion.Euler(new Vector3(camRotation, 0.0f, 0.0f));

    }
}

