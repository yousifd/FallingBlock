using UnityEngine;
using System.Collections;

public class PhysicsManager : MonoBehaviour {

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void left() {
        float x = Physics2D.gravity.x, y = Physics2D.gravity.y;
        float newX = x, newY = y;
        if (x == 0.0f && y == Constants.NEGDEFAULTGRAVITY) {
            newX = Constants.NEGDEFAULTGRAVITY; newY = 0;
        }
        else if (x == Constants.DEFAULTGRAVITY && y == 0.0f) {
            newX = 0; newY = Constants.NEGDEFAULTGRAVITY;
        }
        else if (x == 0.0f && y == Constants.DEFAULTGRAVITY) {
            newX = Constants.DEFAULTGRAVITY; newY = 0;
        }
        else if (x == Constants.NEGDEFAULTGRAVITY && y == 0.0f) {
            newX = 0; newY = Constants.DEFAULTGRAVITY;
        }
        else {
            // Something is really Wrong
        }
        //Debug.Log("X: " + newX + "Y: " + newY);
        Physics2D.gravity = new Vector2(newX, newY);
    }

    public void right() {
        float x = Physics2D.gravity.x, y = Physics2D.gravity.y;
        float newX = x, newY = y;
        if (x == 0.0f && y == Constants.NEGDEFAULTGRAVITY) {
            newX = Constants.DEFAULTGRAVITY; newY = 0;
        }
        else if (x == Constants.DEFAULTGRAVITY && y == 0.0f) {
            newX = 0; newY = Constants.DEFAULTGRAVITY;
        }
        else if (x == 0.0f && y == Constants.DEFAULTGRAVITY) {
            newX = Constants.NEGDEFAULTGRAVITY; newY = 0;
        }
        else if (x == Constants.NEGDEFAULTGRAVITY && y == 0.0f) {
            newX = 0; newY = Constants.NEGDEFAULTGRAVITY;
        }
        else {
            // Something is really Wrong
        }
        //Debug.Log("X: " + newX + "Y: " + newY);
        Physics2D.gravity = new Vector2(newX, newY);
    }
}
