using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCameraScript : MonoBehaviour
{
    public Transform playerBody;
    float mouseSensitivity = 500;

    public float xRotation = 0f;
    bool moveCube = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            moveCube = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (Input.GetMouseButtonUp(1))
        {
            moveCube = false;
            Cursor.lockState = CursorLockMode.None;
        }
        if (moveCube) { 
            // get mouse input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            playerBody.Rotate(Vector3.up * mouseX);
            playerBody.Rotate(Vector3.left * mouseY);

            float z = transform.eulerAngles.z;
            transform.Rotate(0, 0, -z);
            //Mathf.Clamp(transform.localEulerAngles.z, 0 ,0);
        }
    }


}
