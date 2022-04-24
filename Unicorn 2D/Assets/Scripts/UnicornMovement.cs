using UnityEngine;

public class UnicornMovement : MonoBehaviour {

    private Vector3 mousePos;
    private Camera camera;

    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        rotateToCamera();

    }
    void rotateToCamera()
    {
        mousePos = camera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z - camera.transform.position.z));
        transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePos.y - transform.position.y), (mousePos.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}

