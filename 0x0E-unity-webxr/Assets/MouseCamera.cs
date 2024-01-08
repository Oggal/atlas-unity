using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCamera : MonoBehaviour
{
    public float verticalSpeed = 2.0f;
    public float horizontalSpeed = 2.0f;
    public float maxZoom = 5.0f, minZoom = -2.0f, zoomSpeed = 2.0f;
    float curZoom = 0.0f;
    Vector3 CameraRot = Vector3.zero;
    Vector3 CameraPos_Start, CameraRot_Start;

    // Start is called before the first frame update
    void Start()
    {   
        CameraPos_Start = transform.position;
        CameraRot_Start = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        CameraRot.x += Input.GetAxis("Mouse Y") * verticalSpeed * Time.deltaTime;;
        CameraRot.y += Input.GetAxis("Mouse X") * horizontalSpeed * Time.deltaTime;;
        curZoom += Input.GetAxis("Vertical") * Time.deltaTime * zoomSpeed;
        curZoom = Mathf.Clamp(curZoom, minZoom, maxZoom);
        transform.eulerAngles = CameraRot_Start + CameraRot;
        transform.position = CameraPos_Start + Vector3.forward * curZoom;
    }
}
