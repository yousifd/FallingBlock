using UnityEngine;
using System.Collections;

public class HideOnTrigger : Panel {

    public HideOnTrigger (Vector2 pos, bool vertical) : base("Hide On Trigger: " + pos, vertical) {
        SetTrigger();
        Transform(pos);
        Color(UnityEngine.Color.green);
    }

    protected override void HandleTriggerEnter(Collider2D collider) {
        base.HandleTriggerEnter(collider);
        DestroySelf();
        // TODO: Make the block fade out instead of just disappear.
    }
}
