using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerShoot : MonoBehaviour
{

    public GameObject beam; // to Manifest a new object
    public float shootSpeed; // kill speed >:)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){ // if the player presses the SPACE bar
            GameObject newBeam = Instantiate(beam, transform.position, transform.rotation); // manually create a new beam!
            newBeam.transform.SetParent(gameObject.transform);
            newBeam.transform.localPosition = new Vector3(0, -0.2f);

            // BEAM DIRECTION CODE
            float dir = 0;
            if (playerBehavior.faceRight){ // if the player faces RIGHT,
                dir = 1; // go to that direction
            } else { // else!
                newBeam.GetComponent<SpriteRenderer>().flipX = true; // flip the other way ...
                dir = -1;
            }
            newBeam.GetComponent<Rigidbody2D>().velocity = new Vector3(dir * shootSpeed, newBeam.transform.localPosition.y); // beam body...?
        }
    }
}
