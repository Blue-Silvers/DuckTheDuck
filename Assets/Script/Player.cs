using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float xSensitivity = 1f;
    public float ySensitivity = 1f;
    public bool sameSensitivity = true;
    public bool FOV = false;

    public Camera cam;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float Up_Down = Input.GetAxis("Vertical");
        float Left_Right = Input.GetAxis("Horizontal");

        Vector3 direction = (cam.transform.forward * Up_Down) + (cam.transform.right * Left_Right);
        rb.velocity = direction * speed;

        if (sameSensitivity) { ySensitivity = xSensitivity; }
        if (FOV) { }
        float rotateHorizontal = Input.GetAxis("Mouse X");
        float rotateVertical = Input.GetAxis("Mouse Y");
        Vector3 rotation = new Vector3(rotateVertical * xSensitivity, -rotateHorizontal * ySensitivity, 0);
        cam.transform.eulerAngles -= rotation;
    }
}
