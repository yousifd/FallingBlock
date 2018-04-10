using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

    public float speed = 0.005f;
    public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        float x = Physics2D.gravity.x, y = Physics2D.gravity.y;
        if (y < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 0), Time.time * speed);
        }
        else if (y > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 180), Time.time * speed);
        }
        else if (x < 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 270), Time.time * speed);
        }
        else if (x > 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, 90), Time.time * speed);
        }
        else {
            // Something it wrong
            Debug.Log("Gravity Value Invalid");
        }

        Vector3 currentPosition = transform.position,
        playerPosition = player.transform.position,
        destination = new Vector3(playerPosition.x, playerPosition.y, currentPosition.z),
        velocity = Vector3.zero;
        transform.position = Vector3.SmoothDamp(currentPosition, destination, ref velocity, speed);
    }
}
