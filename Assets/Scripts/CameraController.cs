using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Tilemap theMap;
    public Vector3 bottomLeftLimit;
    public Vector3 topRightLimit;

    private float halfHeight; //to control camera aspect
    private float halfWidth; 

    // Start is called before the first frame update
    void Start() {
        target = PlayerController.instance.transform;

        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        bottomLeftLimit = theMap.localBounds.min + new Vector3(halfWidth, halfHeight, 0f);
        topRightLimit = theMap.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0f);
    }

    // Update is called once per frame
    void LateUpdate() {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        //keep the camera inside the level
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x),
            Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }
}
