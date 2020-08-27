using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamera : MonoBehaviour
{
    public float flySpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Stop camera movement on phone
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            return;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position = transform.position + (-transform.right * flySpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position = transform.position + (transform.right * flySpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position = transform.position + (transform.forward * flySpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position = transform.position + (-transform.forward * flySpeed);
        }


        if (Input.GetKey(KeyCode.R))
        {
            transform.Translate(Vector3.up * flySpeed);
        }
        else if (Input.GetKey(KeyCode.F))
        {
            transform.Translate(Vector3.down * flySpeed);
        }
        float newRotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X");
        float newRotationY = transform.localEulerAngles.x - Input.GetAxis("Mouse Y");
        transform.localEulerAngles = new Vector3(newRotationY, newRotationX, 0f);
    }
}
