using UnityEngine;
using System.Collections;

public class Player {

    static private float PLAYERHEIGHT = 0.5f;
    static private float PLAYERWIDTH = 0.5f;

    public GameObject gameObject;
    private MeshRenderer meshRend;
    private BoxCollider2D boxCollider;
    private MeshFilter meshFilter;
    //private Rigidbody2D rigBody;

    // Use this for initialization
    public Player (Vector2 spawnPoint) {
        gameObject = new GameObject();
        gameObject.name = "Player";

        // Get Basic Mesh Components from Cube Premitive
        meshFilter = gameObject.AddComponent<MeshFilter>();
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        meshFilter.mesh = cube.GetComponent<MeshFilter>().mesh;
        meshRend = gameObject.AddComponent<MeshRenderer>();
        meshRend.material = cube.GetComponent<MeshRenderer>().material;

        boxCollider = gameObject.AddComponent<BoxCollider2D>();

        /*rigBody = */gameObject.AddComponent<Rigidbody2D>();

        gameObject.transform.localScale = new Vector3(PLAYERHEIGHT, PLAYERWIDTH, 1);

        spawnPoint.x -= 0.5f;
        spawnPoint.y -= 0.5f;
        gameObject.transform.Translate(spawnPoint);

        UnityEngine.GameObject.Destroy(cube);
    }

    public GameObject GetPlayer() {
        return gameObject;
    }
}
