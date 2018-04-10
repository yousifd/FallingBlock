using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

    private static int GRIDX = 25;
    private static int GRIDY = 25;

    private List<Panel> panels; // Array of Maze Panels
    private Vector2[,] anchorPoints; // Anchor Panels to points within maze

    // TODO: Spwan Point
    // TODO: Set Spwan Point
    // TODO: Spwan Player on Spawn Point

	void Start () {
        Panel.parent = gameObject;
        panels = new List<Panel>();
        anchorPoints = new Vector2[GRIDX, GRIDY];
        for(int i = 0; i < GRIDX; i++) {
            for(int j = 0; j < GRIDY; j++) {
                anchorPoints[i, j] = new Vector2(i, j);

                Panel panelH = GenerateHorizontal(anchorPoints[i, j]);
                Panel panelV = GenerateVertical(anchorPoints[i, j]);
            }
        }
    }

    void Update() {
        // TODO: Dynamically Expand
    }

    Panel GenerateHorizontal (Vector2 pos) {
        pos.x += 0.5f;
        return GetPanel(pos, false);
    }

    Panel GenerateVertical (Vector2 pos) {
        pos.y -= 0.5f;
        return GetPanel(pos, true);
    }

    Panel GetPanel(Vector2 pos, bool vertical) {
        // TODO: Smarter Panel Generation
        Panel.TYPES rand = (Panel.TYPES) Random.Range(0, System.Enum.GetValues(typeof(Panel.TYPES)).Length);
        Panel panel = null;
        switch (rand) {
            case Panel.TYPES.PANEL:
                panel = new Panel(pos, vertical);
                break;
            case Panel.TYPES.HIDDEN:
                panel = new HideOnTrigger(pos, vertical);
                break;
            case Panel.TYPES.GRAVITY:
                panel = new ReverseGravity(pos, vertical);
                break;
            //case Panel.TYPES.DEATH:
            //    // TODO:
            //    break;
            //case Panel.TYPES.ONEDIRECTION:
            //    // TODO:
            //    break;
            //case Panel.TYPES.MOVING:
            //    // TODO:
            //    break;
            //case Panel.TYPES.LAZER:
            //    // TODO:
            //    break;
            default:
                break;
        }

        panels.Add(panel);

        return panel;
    }

    void OnDrawGizmos () {
        for (int i = 0; i < GRIDX; i++) {
            for (int j = 0; j < GRIDY; j++) {
                Gizmos.DrawSphere(anchorPoints[i, j], .1f);
            }
        }
    }
}
