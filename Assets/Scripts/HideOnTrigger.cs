using UnityEngine;
using System.Collections;

public class HideOnTrigger : Panel {

    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(gameObject);
        // TODO: Make the block fade out instead of just disappear.
    }
}
