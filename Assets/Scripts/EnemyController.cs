using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;



public class EnemyController : MonoBehaviour
{
    
    Rigidbody2D enemyRigid;

    public float hp = 90;

    public float speed = 10;

    bool isAlive = true;

    bool isMovingLeft = false;
    bool isMovingRight = false;

    bool HasBeenHit = false;

    SpriteRenderer enemySprite;

    BoxCollider2D enemyCollider;

    ParticleSystem particleSystem;

    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();

        enemyCollider = GetComponent<BoxCollider2D>();

        enemySprite = GetComponent<SpriteRenderer>();

        particleSystem = GetComponent<ParticleSystem>();

        StartCoroutine(Move());
    }

    
    void Update()
    {
        FlipEnemy();
    }

    private IEnumerator Move()
    {

        while(isAlive)
        {

        MoveLeft();

        
        
        yield return new WaitForSeconds(2);

        MoveRight();

        

        yield return new WaitForSeconds(2);

        }
    }

    void MoveLeft()
    {
        
        enemyRigid.linearVelocity = new Vector2(speed, 0);
        isMovingRight=false;
        isMovingLeft = true;

    }

    void MoveRight()
    {

        enemyRigid.linearVelocity = new Vector2(-speed, 0);
        isMovingLeft = false;
        isMovingRight=true;

    }

    void FlipEnemy()
    {
        if(isMovingLeft)
        {
            transform.localScale = new Vector3(1,1,1);
            
        }
        if(isMovingRight)
        {
            transform.localScale = new Vector3(-1,1,1);
        }

    }

     void OnCollisionEnter2D(Collision2D collision)
     {
         if(collision.gameObject.tag == "Player")
        {
            //Destroy(collision.gameObject);
        }
     }
    
    void OnTriggerEnter2D(Collider2D other)
{
    if (other != null && other.gameObject.CompareTag("knife") && hp > 0)
    {
        HasBeenHit = true;
        hp = Mathf.Max(0, hp - 20); 
        enemySprite.color = Color.red;
        Invoke(nameof(ResetHit),0.3f);
        enemySprite.color = Color.cyan;
        particleSystem.Play();
        
    }

    if (other != null && other.gameObject.CompareTag("knife") && hp <= 0)
    {
        
        Die();   
    }
}

void ResetHit()
{
    HasBeenHit= false;
}

void Die()
{

    if(isMovingLeft)
    {
    enemySprite.color = Color.red;
    enemyCollider.enabled = false;
    enemyRigid.linearVelocity = new Vector2(enemyRigid.linearVelocity.x ,5);
    
    Destroy(gameObject, 0.1f);
    }

    if(isMovingRight)
    {
        enemySprite.color = Color.red;
        enemyCollider.enabled = false;
        enemyRigid.linearVelocity = new Vector2(enemyRigid.linearVelocity.x , 5);
        
        Destroy(gameObject, 0.1f);
    }


}

}

