using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beamBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // KILLING CODE ...
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.gameObject.tag == "enemy"){ // if the beam collides with the "enemy" , 
            Destroy(other.gameObject); // destroy !!
            Destroy(gameObject); // then self distruct... :)
        }
    }

    // AUTO-DELETE CODE ...!
    void OnBecameInvisible(){ // if the beam is out of the screen , 
        Destroy(gameObject); // self distruct ... :)
    }
}
