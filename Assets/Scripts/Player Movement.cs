using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovment : MonoBehaviour
{
    [SerializeField] float MoveSpeed=10f;
    [SerializeField] float jumpSpeed=5f;
    [SerializeField] float climbSpeed=5f;
    Vector2 moveInput;
    Rigidbody2D myrigidbody;
     Animator myanimator;
     
     CapsuleCollider2D mybodyCollider;
    float gravityScaleAtstart;
    BoxCollider2D myFeetCollider;
    
    void Start()
    {
        myrigidbody= GetComponent<Rigidbody2D>();
        myanimator= GetComponent<Animator>();
        mybodyCollider=GetComponent<CapsuleCollider2D>();
        gravityScaleAtstart=myrigidbody.gravityScale;
        myFeetCollider=GetComponent<BoxCollider2D>();
        
    }

    
    void Update()
    {
        Run();
        FlipSprite();
        ClimbLadder();
        
        
    }
    void OnMove(InputValue value)
    {
        moveInput=value.Get<Vector2>();
       
        
    }

    void OnJump(InputValue value)
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            
            return;
            
        }
         
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
    void ClimbLadder()
    {
        if (!myFeetCollider.IsTouchingLayers(LayerMask.GetMask("climbing")))
        {
            myrigidbody.gravityScale=gravityScaleAtstart;
            myanimator.SetBool("isClimbing", false);
            return;
            
        }
        myrigidbody.gravityScale=0f;
        Vector2 Climbvelocity= new Vector2(myrigidbody.linearVelocity.x,moveInput.y*climbSpeed);
        myrigidbody.linearVelocity= Climbvelocity;

        bool hasVerticalSpeed=Mathf.Abs(myrigidbody.linearVelocity.y)>Mathf.Epsilon;
        myanimator.SetBool("isClimbing",hasVerticalSpeed);
        
    }
}
