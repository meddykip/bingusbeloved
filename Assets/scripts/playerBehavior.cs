using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBehavior : MonoBehaviour
{
    //PUBLIC tuning variables
    public float speed; //how fast the character moves
    public float jumpHeight; //how high the player can jump
    public float gravityMultiplier;
    public float jumpMultiplier;

    //REFERENCES to components
    Rigidbody2D myBody;
    BoxCollider2D myCollider;

    // SPRITES !!
    SpriteRenderer myRenderer;

    public Sprite jumpSprite;
    public Sprite walkSprite;

    //PRIVATE code + tunes
    float moveDir = 1;
    //by default the player will move right
    bool onFloor = true;
    public static bool faceRight = true;

    // to UNMANIFEST ...!

    public GameObject unmanifest1;
    public GameObject unmanifest2;
    public GameObject unmanifest3;
    public GameObject keyGET;

    // to UNLOCK the door ..!
    bool doorUNLOCK = false;

    // Start is called before the first frame update
    void Start()
    {
        myBody = gameObject.GetComponent<Rigidbody2D>();
        myCollider = gameObject.GetComponent<BoxCollider2D>();
        myRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){ // runs first
        if (onFloor && myBody.velocity.y > 1){
            onFloor = false; // automatically false!
        }
        ChecKeys();
        HandleMovement();
        JumpPhysics();
    }

    // checks what keys the player is pressing
    void ChecKeys(){
        if(Input.GetKey(KeyCode.D)){ // IF the player presses D , default direction
            moveDir = 1; // move forward !
            faceRight = true; // confirms direction
            myRenderer.flipX = true; // keeps the sprite direction
        } else if (Input.GetKey(KeyCode.A)){ // ELSE if the player presses A
            moveDir = -1; // go back ,
            faceRight = false; // unfinals the fantasy ,
            myRenderer.flipX = false; // flips the sprite !
        } else {
            moveDir = 0;
        }

        if(Input.GetKey(KeyCode.W) && onFloor){ // IF the player presses W,
            Debug.Log("WROW");
            myRenderer.sprite = jumpSprite;
            myBody.velocity = new Vector3(myBody.velocity.x, jumpHeight);
            // jumping movement !!!!
        } else if(!Input.GetKey(KeyCode.W) && myBody.velocity.y > 1){
            myBody.velocity += Vector2.up * Physics.gravity.y * (jumpMultiplier * 1f)* Time.deltaTime;
        }
    }

    // the jump code from the tutorial... :)
    void JumpPhysics(){
        if(myBody.velocity.y < 0){
            myBody.velocity += Vector2.up * Physics.gravity.y * (gravityMultiplier - 1f) * Time.deltaTime;
        }
    }

    // code to handle movement from the tutorial... :)
    void HandleMovement(){
        myBody.velocity = new Vector3(moveDir * speed, myBody.velocity.y);
    }

// PURE COLLISION code...!
    void OnCollisionEnter2D(Collision2D collisionInfo){
        if(collisionInfo.gameObject.tag == "floor"){ // IF the player collides with the floor , 
            myRenderer.sprite = walkSprite; // sprite = walk sprite
            onFloor = true; // walking CONFIRMED ...
        }
        
        if (collisionInfo.gameObject.tag == "key"){ // IF the player collides with the key ,
            Destroy(keyGET); // absorb the key
            doorUNLOCK = true; // you can unlock the door !! :)
            Debug.Log("kingdom hearts REAL"); // KINGDOM HEARTS 4 CONFIRMED
        }

        if (collisionInfo.gameObject.tag == "door" && doorUNLOCK){ // IF the player has the key + collides with the door
            Destroy(collisionInfo.gameObject); // kick the door down for BINGUS ...
            Debug.Log("no more door"); // the evil is defeated
        }

        if(collisionInfo.gameObject.tag == "enemy"){ // IF the player collides with the enemy ,
            Debug.Log("OOF"); // just lmk <3
        }
    }

// COLLISION (but TRIGGER) code...!
    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.name == "button1"){ // IF the player triggers the buttons ,
            Debug.Log("AYAYAYYA"); // lmk !
            Destroy(unmanifest1); // destroy the doorstops
        } else if (other.gameObject.name == "button2"){
            Debug.Log("UWUWUUWWU");
            Destroy(unmanifest2);
        } else if (other.gameObject.name == "button3"){
            Debug.Log("OWOWOWOOWO");
            Destroy(unmanifest3);
        }
    }
}
