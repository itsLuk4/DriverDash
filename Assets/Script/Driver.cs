using JetBrains.Annotations;
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Driver : MonoBehaviour
{
    //Component
    TopDownCarController topDownCarController;

    void Awake()
    {
        topDownCarController = GetComponent<TopDownCarController>();
    }

    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        // Vertical axis
        if (Keyboard.current.wKey.isPressed)
        {
            inputVector.y = 1f;

        }
        if (Keyboard.current.sKey.isPressed)
        {
            inputVector.y = -1f;
        }

        // Horizontal axis
        if (Keyboard.current.dKey.isPressed)
        {
            inputVector.x = 1f;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            inputVector.x = -1f;
        }

        if (inputVector.magnitude > 1f)
        {
            inputVector = inputVector.normalized;
        }

        topDownCarController.SetInputVector(inputVector);
    }
}
