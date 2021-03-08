using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unfreezeBehavior : MonoBehaviour
{
    Rigidbody2D rbody; // references the object's rigidbody >:)
    
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   // COLLISION + UNFREEZE CODE 
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.gameObject.tag == "open"){ // if the object collides with the "opener" , 
            rbody.constraints = RigidbodyConstraints2D.None; // unfreeze :)
        }
    }
}
