using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

    // Spawns food in game
    public GameObject foodPrefab;

    // Borders
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    
    // Use for initialization
	void Start () {
        // Spawn food every 4 seconds, starting in 3 seconds
        InvokeRepeating("Spawn", 3, 4);
	}
	
	// Spawn in one piece of food
	void Spawn () {
        //x position between left and right border
        int x = (int)Random.Range(borderLeft.position.x,
                                   borderRight.position.x);
        // y position between top and bottom border
        int y = (int)Random.Range(borderLeft.position.y,
                                    borderRight.position.y);

        // Instantiate food at points
        Instantiate(foodPrefab,
            new Vector2(x, y),
            Quaternion.identity); // default rotation
		
	}
}
