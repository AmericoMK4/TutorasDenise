using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    private float speed = 20f;
    private float turnSpeed = 45f;
    private float horizontalInput;
    private float verticalInput;
    private InputSystem_Actions controls;  
    public InputActionAsset InputActions;
    private Vector2 rawMoveInput;
    void Awake()
    {
        controls = new InputSystem_Actions();
    }
        private void OnEnable()
    {
        controls.Player.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
    }
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        InputReader();


        if (verticalInput > 0)
        {
            // Move o ve�culo para frente a partir do Input vertical
        transform.Translate(Vector3.forward * Time.deltaTime * speed * rawMoveInput.y);
        }
        // Rotaciona o carro a partir do Input horizontal
        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * rawMoveInput.x);
    }
    void InputReader()
    {
      rawMoveInput = controls.Player.Move.ReadValue<Vector2>();
      horizontalInput = rawMoveInput.x;
      verticalInput = rawMoveInput.y;
    }
}