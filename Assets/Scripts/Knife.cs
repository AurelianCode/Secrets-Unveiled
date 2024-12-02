using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;


public class Knife : MonoBehaviour
{
    public float knifeSpeed = 20;

    Rigidbody2D knifeRigidBody;




    private Transform playerTransform;

    ParticleSystem particleSystem;
    void Start()
    {

      particleSystem = GetComponent<ParticleSystem>();

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

    void OnTriggerEnter2D(Collider2D other)
    {
      if(other.gameObject.tag == "Enemy")
      {
        particleSystem.Play();
        Debug.Log("knife hit enemy");
        DestroyKnife();
      }
    }


     private IEnumerator DestroyKnife()
     {
       yield return new WaitForSeconds(0.1f);
       Destroy(gameObject);
     }
}
