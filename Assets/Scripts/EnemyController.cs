using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    Rigidbody2D enemyRigid;

    public float speed = 10;

    bool isAlive = true;

    void Start()
    {
        enemyRigid = GetComponent<Rigidbody2D>();

        StartCoroutine(Move());
    }

    
    void Update()
    {
        
    }

    private IEnumerator Move()
    {

        while(isAlive)

        MoveLeft();
        yield return new WaitForSeconds(2);

        MoveRight();
        yield return new WaitForSeconds(2);


    }

    void MoveLeft()
    {
        
        enemyRigid.linearVelocity = new Vector2(speed, 0);

    }

    void MoveRight()
    {

        enemyRigid.linearVelocity = new Vector2(-speed, 0);

    }
}
