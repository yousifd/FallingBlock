using UnityEngine;
using System.Collections;

public class ReverseGravity : Panel {

    void OnTriggerEnter2D(Collider2D other) {
        Physics2D.gravity *= -1; // Reverse Gravity
        Destroy(gameObject);
    }
}
