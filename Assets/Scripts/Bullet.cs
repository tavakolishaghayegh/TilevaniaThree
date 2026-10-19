using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float bulletspeed=20f;
    Rigidbody2D myrigidbody;
    PlayerMovment player;
    float xSpeed; 
    
    void Start()
    {
        myrigidbody= GetComponent<Rigidbody2D>();
        player= FindAnyObjectByType<PlayerMovment>();
        xSpeed=player.transform.localScale.x * bulletspeed;
        
    }

        void Update()
    {
        myrigidbody.linearVelocity=new Vector2(xSpeed,0f);
        
    }
      void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject );
        }
        Destroy(gameObject);
        
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
         Destroy(gameObject,1f);
        
    }
}
