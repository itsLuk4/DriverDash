using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float steerSpeed = 20f;
    


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steer = 0f;
        float move = 0f;

        if (Keyboard.current.wKey.isPressed)
        {
            move = 1f;
        }
        else if (Keyboard.current.sKey.isPressed)
        {
            move = -1f;
        }
        if (Keyboard.current.aKey.isPressed && Keyboard.current.wKey.isPressed
            || Keyboard.current.aKey.isPressed && Keyboard.current.sKey.isPressed)
        {
            steer = 150f;
        }
        else if (Keyboard.current.dKey.isPressed && Keyboard.current.wKey.isPressed
            || Keyboard.current.dKey.isPressed && Keyboard.current.sKey.isPressed)
        {
            steer = -150f;
        }

        float moveAmount = move * moveSpeed * Time.deltaTime;
        float steerAmount = steer * steerSpeed * Time.deltaTime;

        // Time.deltaTime multiplies depending on the speed of a PC (slow or fast)
        transform.Translate(0, moveAmount, 0);
        transform.Rotate(0, 0, steerAmount);
    }
}
