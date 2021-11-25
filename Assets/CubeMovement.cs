using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public Rigidbody RbPlayer;
    
    public float Speed;
    public float JumpForce;
    private float _jumpBuffer;

    private bool _touchGround = true;
    
    public static Action<float> OnPlayerMoved;
    public static Action<float> OnPlayerAir;
    public static Action OnPlayerJump;

    private Vector3 _lastFramePosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {
            float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
            
            float vertical = Input.GetAxis("Vertical") * Time.deltaTime * Speed;
            transform.Translate(horizontal, 0, vertical);

            OnPlayerMoved?.Invoke(Vector3.Distance(transform.position, _lastFramePosition));
            _lastFramePosition = transform.position;
        }

        /*if (!_touchGround)
        {
            OnPlayerAir?.Invoke(Time.deltaTime);
            if (transform.position.y <= 0.5f && _jumpBuffer <= Time.time) _touchGround = true;
        }
        if (Input.GetButtonDown("Jump") && _touchGround)
        {
            RbPlayer.AddForce(Vector3.up * JumpForce);
            _touchGround = false;
            _jumpBuffer = Time.time + 0.1f;
            OnPlayerJump?.Invoke();
        }*/
    }
}
