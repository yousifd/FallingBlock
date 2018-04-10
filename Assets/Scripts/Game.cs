using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	public float transitionLock = 0.1f;

	private float elapsedTime;
    private PhysicsManager physMan;
    private Maze maze;

	// Use this for initialization
	void Start () {
        Physics2D.gravity = new Vector2(0.0f, Constants.NEGDEFAULTGRAVITY); // Initialize Gravity to Downwards
		elapsedTime = transitionLock; // Initialize elapsed time to transitionLock to allow for fast first move
        physMan = gameObject.AddComponent<PhysicsManager>() as PhysicsManager; // Map PhysicsManager to physMan

        // Generate a Maze
        maze = gameObject.AddComponent<Maze>() as Maze;
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime += Time.deltaTime; // Update elapsed time 
		if (elapsedTime >= transitionLock) {
			if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
			{
                physMan.right(); // Switch Gravity to the Right of current direction
				elapsedTime = 0; // Only reset time if button is pressed
			}
			else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
			{
                physMan.left(); // Switch Gravity to the Left of current direction
                elapsedTime = 0; // Only reset time if button is pressed
            }
		}
    }
}
