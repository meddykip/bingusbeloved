using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freezeBehavior : MonoBehaviour
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

   // COLLISION + FREEZE CODE 
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.gameObject.tag == "ministop"){ // if the object collides with the "ministop" , 
            rbody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; // freeze :)
        }
    }
}
