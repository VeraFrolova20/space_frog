using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrolling : MonoBehaviour
{
    private new Camera camera;
    private Transform player;

    public float maxLeft;
    public float maxRight;
    public float maxBottom;

    public float maxTop;

    private float cameraWidth;
    private float cameraHeight;


    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        camera = GetComponent<Camera>();
        cameraHeight = 2f * camera.orthographicSize;
        cameraWidth = cameraHeight*camera.aspect;

    }

    private void LateUpdate()
    {

        Vector3 cameraPosition = transform.position;
        cameraPosition.x = Mathf.Clamp(player.position.x, maxLeft+cameraWidth/2, maxRight-cameraWidth/2);
        cameraPosition.y = Mathf.Clamp(player.position.y, maxBottom+cameraHeight/2, maxTop-cameraHeight/2);
        transform.position = cameraPosition;
    }
}
