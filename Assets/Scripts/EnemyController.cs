using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    Rigidbody2D enemyRigid;

    public float speed = 10;

    bool isAlive = true;

    bool isMovingLeft = false;
    bool isMovingRight = false;

    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();

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
}
