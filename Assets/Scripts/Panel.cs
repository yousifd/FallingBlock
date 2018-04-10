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

    //public Panel (Panel panel) {
    //    gameObject = UnityEngine.GameObject.Instantiate(panel.gameObject);
    //}

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

        // Adjust Dimensions of Object
        gameObject.transform.localScale = new Vector2(Constants.PANELHIGHT, Constants.PANELWIDTH);

        boxCollider = gameObject.AddComponent<BoxCollider2D>() as BoxCollider2D;

        // Event Forwarder Used to Forward events to non-Monobehaviour Objects
        forwarder = gameObject.AddComponent<EventForwarder>();
        forwarder.OnTriggerEnter2DEvent += HandleTriggerEnter;

        UnityEngine.GameObject.Destroy(cube);
    }

    public void Transform(Vector2 vec) {
        gameObject.transform.position = vec;
    }

    public void SetTrigger() {
        boxCollider.isTrigger = true;
    }

    public void DestroySelf() {
        UnityEngine.GameObject.Destroy(gameObject);
        //UnityEngine.GameObject.Destroy(meshRend);
        //UnityEngine.GameObject.Destroy(boxCollider);
        //UnityEngine.GameObject.Destroy(meshFilter);
    }

    //static public Panel Copy(Panel panel) {
    //    return new Panel(panel);
    //}

}
