using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Panel {

    private static float PANELWIDTH = .1f;
    private static float PANELHIGHT = 1.05f;

    private GameObject gameObject;
    private MeshRenderer meshRend;
    private BoxCollider2D boxCollider;
    private MeshFilter meshFilter;
    private EventForwarder forwarder;
    static public GameObject parent;
    public enum TYPES {PANEL, HIDDEN, GRAVITY/*, DEATH, ONEDIRECTION, MOVING, LAZER*/};

	public Panel () {
        Init("Panel");
    }

	public Panel (string name, bool vertical) {
        Init(name);
        if (vertical) {
            Rotate(90);
        }
    }

    public Panel(Vector2 pos, bool vertical) {
        Init("Panel: " + pos);
        Transform(pos);
        if(vertical) {
            Rotate(90);
        }
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
        meshRend.material = cube.GetComponent<MeshRenderer>().material;

        boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;

        // Adjust Dimensions of Object
        gameObject.transform.localScale = new Vector3(PANELHIGHT, PANELWIDTH, 1);

        // Event Forwarder Used to Forward events to non-Monobehaviour Objects
        forwarder = gameObject.AddComponent<EventForwarder>();
        forwarder.OnTriggerEnter2DEvent += HandleTriggerEnter;

        UnityEngine.GameObject.Destroy(cube);
    }

    protected void Transform(Vector2 vec) {
        gameObject.transform.position = vec;
    }

    protected void Rotate(float deg) {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, deg);
    }

    protected void Color(Color color) {
        meshRend.material.color = color;
    }

    protected void SetTrigger() {
        boxCollider.isTrigger = true;
    }

    protected void DestroySelf() {
        UnityEngine.GameObject.Destroy(gameObject);
        boxCollider.isTrigger = false;
    }
}
