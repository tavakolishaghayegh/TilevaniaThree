using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float MoveSpeed=1f;
    Rigidbody2D  myRigidbody;
        void Start()
    {
        myRigidbody=GetComponent<Rigidbody2D>();
         
        
    }

    
    void Update()
    {
        myRigidbody.linearVelocity=new Vector2(MoveSpeed,0f);
        
    }
    void OnTriggerExit2D(Collider2D collision) 
    {
         MoveSpeed = -MoveSpeed; 
        FlipEnemyFacing(); 
    }

    

    void FlipEnemyFacing()
    {
        transform.localScale=new Vector2(-(Mathf.Sign(myRigidbody.linearVelocity.x)),1f);
            
    }
}
