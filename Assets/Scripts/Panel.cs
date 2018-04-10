using UnityEngine;
using System.Collections;

public class Panel : MonoBehaviour {

    private MeshRenderer meshRend;
    private BoxCollider2D boxCollider;
    private MeshFilter meshFilter;

	// Use this for initialization
	void Start () {
        meshFilter = gameObject.AddComponent<MeshFilter>() as MeshFilter;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        meshFilter.mesh = cube.GetComponent<MeshFilter>().mesh as Mesh;
        meshRend = gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;
        boxCollider.isTrigger = true;

        Destroy(cube);
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

}
