using UnityEngine;
using System.Collections;

public class ReverseGravity : Panel {

    public ReverseGravity (Vector2 pos) : base("Reverse Gravity " + pos) {
        SetTrigger();
    }

    protected override void HandleTriggerEnter(Collider2D collider) {
        base.HandleTriggerEnter(collider);
        Physics2D.gravity *= -1; // Reverse Gravity
        DestroySelf();
    }
}
