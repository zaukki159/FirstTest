using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script rotates the player based on the mouse position
public class RotatePlayer : MonoBehaviour
{
    //Public variables
    public Camera playerCam;

    //Private variables
    private Ray camRay;
    private Plane groundPlane;
    private float rayLength;
    private Vector3 pointToLook;

    //Update is called once per frame
    private void Update()
    {
        //Sending a raycast
        camRay = playerCam.ScreenPointToRay(Input.mousePosition);

        //Setting groundPlane
        groundPlane = new Plane(Vector3.up, Vector3.zero);

        //Checking if the ray hit something
        if (groundPlane.Raycast(camRay, out rayLength))
        {
            pointToLook = camRay.GetPoint(rayLength);
        }

        //Rotating the player
        transform.LookAt(new Vector3(pointToLook.x, pointToLook.y, pointToLook.z));
    }
}