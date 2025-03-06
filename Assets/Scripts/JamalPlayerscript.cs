// using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class JamalPlayerscript : MonoBehaviour
{
    public float speed = 3;

    public InputActionAsset actionAsset;
    private InputActionMap gameplayMap;
    private InputAction moveAction;

    void Start() 
    {
        // Activer les actions
        // moveAction.Enable();

        // ou avec l'asset
        gameplayMap = actionAsset.FindActionMap("Player");
        moveAction= gameplayMap.FindAction("Move");
        gameplayMap.Enable();
    }
    
    void Update()
    {
        // Vector2 direction = moveAction.ReadValue<Vector2>();
        // transform.Translate(new Vector3(direction.x, 0, direction.y) * Time.deltaTime * speed);
        
    }
    
    private void OnMove(InputValue value) 
    {
        Vector2 moveInput = value.Get<Vector2>();
        transform.Translate(new Vector3(moveInput.x, moveInput.y, 0) * Time.deltaTime * speed);
    }
}

        // Vector2 direction = new Vector2(0, 0);
        // if (Input.GetKey(KeyCode.E)) {
        //     direction += new Vector2(0, 1);
        // }
        // if (Input.GetKey(KeyCode.S)) {
        //     direction += new Vector2(-1, 0);
        // }
        // if (Input.GetKey(KeyCode.D)) {
        //     direction += new Vector2(0, -1);
        // }
        // if (Input.GetKey(KeyCode.F)) {
        //     direction += new Vector2(1, 0);
        // }
        // print(direction);

        // myBod.linearVelocity = direction * speed;