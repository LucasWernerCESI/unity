using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float TiltX = 0;
    public float TiltAngle;
    public float Smooth;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse X") != 0) Rotate();
    }

    private void Rotate()
    {
        // Smoothly tilts a transform towards a target rotation.
        //TiltX += Input.GetAxis("Mouse X") * TiltAngle;

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(
            transform.rotation,
            Quaternion.Euler(TiltX, 0, 0),
            Smooth * Time.deltaTime
        );
    }
}
