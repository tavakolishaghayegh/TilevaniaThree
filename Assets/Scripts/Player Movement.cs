using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float MoveSpeed=10f;
    [SerializeField] float jumpSpeed=5f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
     Animator myanimator;
    
    void Start()
    {
        myrigidbody= GetComponent<Rigidbody2D>();
        myanimator= GetComponent<Animator>();
        
    }

    
    void Update()
    {
        Run();
        FlipSprite();
        
    }
    void OnMove(InputValue value)
    {
        moveInput=value.Get<Vector2>();
       
        
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed)
        myrigidbody.linearVelocity += new Vector2(0f,jumpSpeed);
     
        
    }
    void Run()
    {
        Vector2 playervelocity= new Vector2(moveInput.x*MoveSpeed,myrigidbody.linearVelocity.y);
        myrigidbody.linearVelocity=playervelocity;
        bool hasHorizontalSpeed=Mathf.Abs(myrigidbody.linearVelocity.x)>Mathf.Epsilon;
        myanimator.SetBool("isRunning",hasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool hasHorizontalSpeed=Mathf.Abs(myrigidbody.linearVelocity.x)>Mathf.Epsilon;
        if (hasHorizontalSpeed)
        {
            transform.localScale=new Vector2(Mathf.Sign(myrigidbody.linearVelocity.x),1f);
            
        }
        
        
    }
}
