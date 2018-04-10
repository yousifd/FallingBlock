using UnityEngine;
using System.Collections;

public class HideOnTrigger : Panel {

    public HideOnTrigger (Vector2 pos) : base("Hide On Trigger: " + pos) {
        SetTrigger();
    }

    protected override void HandleTriggerEnter(Collider2D collider) {
        base.HandleTriggerEnter(collider);
        DestroySelf();
        // TODO: Make the block fade out instead of just disappear.
    }
}
