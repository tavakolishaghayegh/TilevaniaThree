using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float MoveSpeed=10f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody; 
    
    void Start()
    {
        myrigidbody= GetComponent<Rigidbody2D>();
        
    }

    
    void Update()
    {
        Run();
        
    }
    void OnMove(InputValue value)
    {
        moveInput=value.Get<Vector2>();
       
        
    }
    void Run()
    {
        Vector2 playervelocity= new Vector2(moveInput.x*MoveSpeed,myrigidbody.linearVelocity.y);
        myrigidbody.linearVelocity=playervelocity;
    }
}
