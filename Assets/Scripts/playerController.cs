using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour {

    private Vector3 _velocity = Vector3.zero;
    private Vector3 _rotation = Vector3.zero;
    private Vector3 _cameraRotation = Vector3.zero;
    private float Speed = 5f;
    private float MouseSensitivity = 4f;
    public Camera cam;
    private Rigidbody rigi;

    // Use this for initialization
    void Start ()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rigi = this.GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {
        float posX = Input.GetAxisRaw("Horizontal");
        float posZ = Input.GetAxisRaw("Vertical");
        float rotY = Input.GetAxisRaw("Mouse X");
        float rotX = Input.GetAxisRaw("Mouse Y");

        Vector3 moveHorizontal = transform.right * posX;
        Vector3 moveVertical = transform.forward * posZ;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * Speed;
        _velocity = velocity;

        Vector3 rotation = new Vector3(0f, rotY, 0f) * MouseSensitivity;
        _rotation = rotation;

        Vector3 cameraRotation = new Vector3(rotX, 0f, 0f) * MouseSensitivity;
        _cameraRotation = cameraRotation;
    }


    void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    private void Movement()
    {
        if (_velocity != Vector3.zero)
        {
            rigi.MovePosition(rigi.position + _velocity * Time.fixedDeltaTime);
        }
    }
    private void Rotation()
    {
        rigi.MoveRotation(rigi.rotation * Quaternion.Euler(_rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-_cameraRotation);
        }
    }
}
