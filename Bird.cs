using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public float speed = 3.5f;
    public float jumpForce = 300f;

    public bool dead = false;

    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dead){
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;
            return;
        }

        //move forward
        GetComponent<Rigidbody>().velocity = new Vector3(
            0,
            GetComponent<Rigidbody>().velocity.y, 
            speed
        );

        //make bird jump
        //GvrViewer.Instance.Triggered 
        if (Input.GetKeyDown("space")){ 
            GetComponent<Rigidbody>().velocity = new Vector3(
            0, jumpForce,
                GetComponent<Rigidbody>().velocity.z);

        }
	}

    void OnTriggerEnter (Collider otherCollider){
        if (otherCollider.tag == "Obstacle"){
            dead = true;
        }

    }

}

