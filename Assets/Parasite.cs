using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Snake : MonoBehaviour {
    // Current Movement Direction
    // This will move it to the right for testing.
    // Vector2 dir = Vector2.right;

        //Tail prefab
    public GameObject tailPrefab;

    // Did the sparasite eat anything.
   private bool ate = false;

    //Keeps track of the tail
    List<Transform> TailPrefab = new List<Transform>();


    // Use this for initialization
    void Start () {
        //moves the parasite every 300 ms
        InvokeRepeating("Move", 0.3f, 0.3f);
	}
	
	// Update is called once per frame
	void Update () {
        // Move in a new direction... Maybe replace with the cursor script so that it follows the cursor instead of keyboard input.
        if (Input.GetKey(KeyCode.RightArrow))
            Move(Vector2.right);
        else if (Input.GetKey(KeyCode.LeftArrow))
            Move(Vector2.left);
        else if (Input.GetKey(KeyCode.DownArrow))
            Move(-Vector2.up); // - is for down movement. it is negative.
        else if (Input.GetKey(KeyCode.UpArrow))
            Move(Vector2.up);
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        // Food?
        if (other.gameObject.CompareTag("foodpellet"))
        {
            // get longer in next move call
            ate = true;

            //remove food
            Destroy(gameObject);
        }
        //collided with border or tail
        else
        {
            // Add 'You Lose' screen here.
        }
    }

    void Move(Vector2 direction)
    {
        // transform.Translate(dir);
        // This worked before I commented the line above. Hopefully it doesnt fuck it up.

        Vector2 v = transform.position;

        // Move head into new direction (now there is a gap)
        transform.Translate(direction);

        // Ate something? Then instert new element into gap (aka new tail segment)
        if (ate)
        {
            // load prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            // keep track of it in the tail list
        //    tailPrefab.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }

        //Do we have a Tail?
      //  if (TailPrefab.Count > 0)
      //  {
            // Move last Tail Element to where the Head was
        //    TailPrefab.Last().position = v;

            // Add to front of list, remove the back
          //  TailPrefab.Insert(0, TailPrefab.Last());
          //  TailPrefab.RemoveAt(TailPrefab.Count -1);
       // }
    }

}
