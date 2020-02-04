using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    /// <summary>
    /// Field for player movement speed
    /// </summary>
    public float _moveSpeed = 5f;

    /// <summary>
    /// stores a rigidbody component so that we can change values and interact with the player
    /// </summary>
    public Rigidbody2D _rb;

    /// <summary>
    /// Vector used to store movement inputs, and move player based on them
    /// </summary>
    Vector2 _movement;

    /// <summary>
    /// Used to store location of the mouse for aiming player
    /// </summary>
    Vector2 _mousePos;

    /// <summary>
    /// Reference to the camera to help aim the character
    /// </summary>
    public Camera _cam;


    // Update is called once per frame
    void Update()
    {

        //getting input for x and y axis
        //gets input based on unity set controls so wasd works but so would arrow keys I believe
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");

        //gets input from location of mouse
        _mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);

    }

    void FixedUpdate()
    {
        //moves player based on stored input for movement and a fixed time so that the movement does not lag with frame droppage
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);

        //direction the player is trying to look
        Vector2 lookDir = _mousePos - _rb.position;

        //rotation of player in degrees (constant value used to find starting direction of player)
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = angle;

    }
}
