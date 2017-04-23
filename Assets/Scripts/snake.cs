using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class snake : MonoBehaviour {

    List<Transform> tail = new List<Transform>();

    //Current Movement Direction
    // by default it will move to the right of the screen
    Vector2 dir = Vector2.right;

    private bool ate = false;

    // Score
    private int count;
    public Text countText;

    // Tail Prefab
    public GameObject tailPrefab;

	// Use this for initialization
	void Start () {
        // Move the Snake every 300ms
        InvokeRepeating("Move", 0.3f, 0.3f);

        // starts the score at 0
        count = 0;
        SetCountText();
       
		
	}
	
	// Update is called once per frame
	void Update () {
        // Move in a new direction
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up; // negative vector and up equals down because computers.
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; // negative vector and right equals left because computers.
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
		
	}

    void Move()
    {
        //Save current position (gap will be here)
        Vector2 v = transform.position;

        // Move the head into a new direction (now there is a gap)
        transform.Translate(dir);

        // Ate something? Then insert new element into gap
        if (ate)
        {
            //load prefab into the world
            GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);

            // keep track of it in our tail list
            tail.Insert(0, g.transform);

            // Reset the flag
            ate = false;
        }

        // Do we have a tail?

        if (tail.Count > 0)
        {
            // Move last Tail element to where Head was
            tail.Last().position = v;

            // Add to the front of list, remove from the back
            tail.Insert(0, tail.Last());
            tail.RemoveAt(tail.Count - 1);
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        // Food?
        if (coll.name.StartsWith("food"))
        {
            // Get Longer in next Move call
            ate = true;

            // Remove the food
            Destroy(coll.gameObject);

            //updating the score when destroying game object
            count = count + 1;
            SetCountText();
        }
        // Collided with tail or border
        else
        {
            // Add 'You Lose' screen here.
        }
    }

    void SetCountText()
    {
        countText.text = "Points: " + count.ToString();
    }
}
