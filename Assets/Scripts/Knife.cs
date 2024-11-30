using UnityEngine;


public class Knife : MonoBehaviour
{
    public float knifeSpeed = 20;

    Rigidbody2D knifeRigidBody;


    private Transform playerTransform;
    void Start()
    {

      knifeRigidBody= GetComponent<Rigidbody2D>();

      playerTransform = GameObject.Find("Player").transform;

      if(playerTransform.localScale.x > 0)
        knifeRigidBody.linearVelocity = new Vector2(knifeSpeed, 0);

        if(playerTransform.localScale.x < 0)
        knifeRigidBody.linearVelocity = new Vector2(-knifeSpeed, 0);
        
    }

    
    void Update()
    { 
        
    }
}
