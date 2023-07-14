using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallax : MonoBehaviour
{
    public Transform[] backgrounds; //Array (list) of all back- and forceground to be parallaxed
    private float[] paralaxScales;
    public float smoothing = 1f;
    
    // reference to the main cameras transform
    private Transform cam;
    
    // the position of the camera in the previous frame
    private Vector3 previousCamPos;

    // Awake is caleed before  Start(). Great for reference
    void Awake()
    {
        // set up camera the reference
        cam = Camera.main.transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        previousCamPos = cam.position;
        
        paralaxScales = new float[backgrounds.Length];
        for (int i = 0; i < backgrounds.Length; i++) {
            paralaxScales[i] = backgrounds[i].position.z* - 1;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        // for each background
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // the parallax is the opposite of the camera movement because the previous frame multiplied by the scale
            float parallax = (previousCamPos.x - cam.position.x) * paralaxScales[i];
            
            // set a target x position which is the current position plus the parallax
            float bgTargetPosX = backgrounds[i].position.x + parallax;

            // create a target position which is the background's  current position with it's target x position
            Vector3 bgTargetPos = new Vector3(bgTargetPosX, backgrounds[i].position.y, backgrounds[i].position.z);
            
            // fade between current position and the target position using lerp
            backgrounds[i].position = Vector3.Lerp(backgrounds[i].position, bgTargetPos, smoothing * Time.deltaTime);
            
        }
        
        // set the previousCamPos to the camera's position at the end of the frame
        previousCamPos = cam.position;
        
    }
}
