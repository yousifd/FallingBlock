﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Maze : MonoBehaviour {

    private List<Panel> panels; // Array of Maze Panels
    private Vector2[,] anchorPoints; // Anchor Panels to points within maze

	void Start () {
        Panel.parent = gameObject;
        panels = new List<Panel>();
        anchorPoints = new Vector2[10, 10];
        for(int i = 0; i < 10; i++) {
            for(int j = 0; j < 10; j++) {
                anchorPoints[i, j] = new Vector2(i, j);
                Panel panel = new HideOnTrigger(anchorPoints[i, j]);
                panel.Transform(anchorPoints[i, j]);
                panels.Add(panel);
            }
        }
    }

    void Update () {

    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Detected Collision!");
    }

    void OnDrawGizmos () {
        for (int i = 0; i < 10; i++) {
            for (int j = 0; j < 10; j++) {
                Gizmos.DrawSphere(anchorPoints[i, j], .1f);
            }
        }
    }

    public void AddPanel () {

    }
}
