using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Panel {

    private GameObject gameObject;
    private MeshRenderer meshRend;
    private BoxCollider2D boxCollider;
    private MeshFilter meshFilter;
    private EventForwarder forwarder;
    static public GameObject parent;

	public Panel () {
        Init("Panel");
    }

	public Panel (string name) {
        Init(name);
	}

    public Panel(Vector2 pos) {
        Init("Panel: " + pos);
    }

    protected virtual void HandleTriggerEnter(Collider2D collider) {
        forwarder.OnTriggerEnter2DEvent -= HandleTriggerEnter;
    }

    protected void Init (string name) {
        gameObject = new GameObject();
        gameObject.name = name;
        gameObject.transform.parent = parent.transform;

        // Get Basic Mesh Components from Cube Premitive
        meshFilter = gameObject.AddComponent<MeshFilter>() as MeshFilter;
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        meshFilter.mesh = cube.GetComponent<MeshFilter>().mesh;
        meshRend = gameObject.AddComponent<MeshRenderer>() as MeshRenderer;
        meshRend.material = cube.GetComponent<MeshRenderer>().sharedMaterial;

        boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;

        // Adjust Dimensions of Object
        gameObject.transform.localScale = new Vector2(Constants.PANELHIGHT, Constants.PANELWIDTH);

        // Event Forwarder Used to Forward events to non-Monobehaviour Objects
        forwarder = gameObject.AddComponent<EventForwarder>();
        forwarder.OnTriggerEnter2DEvent += HandleTriggerEnter;

        UnityEngine.GameObject.Destroy(cube);
    }

    public void Transform(Vector2 vec) {
        gameObject.transform.position = vec;
    }

    protected void SetTrigger() {
        boxCollider.isTrigger = true;
    }

    protected void DestroySelf() {
        UnityEngine.GameObject.Destroy(gameObject);
    }
}
