using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Script making the camera follow the player
/// </summary>
public class CameraFollow : MonoBehaviour
{
    /// <summary>
    /// point where camera should be
    /// </summary>
    public Transform _target;

    /// <summary>
    /// value used for smoothing camera movement
    /// </summary>
    public float _smoothSpeed = 0.125f;

    /// <summary>
    /// used to offest camera so it is not inside of the player
    /// </summary>
    public Vector3 _offest;

    /// <summary>
    /// runs on set time frame
    /// </summary>
    private void FixedUpdate()
    {

        //postion we want camera to be
        Vector3 desiredPosition = _target.position + _offest;

        //takes in the starting and ending positions and uses a function to smooth the speed based on _smoothSpeed
        //lower _smoothSpeed = slower camera
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);

        //sets cameras position to the player
        transform.position = smoothedPosition;

        

    }

}
