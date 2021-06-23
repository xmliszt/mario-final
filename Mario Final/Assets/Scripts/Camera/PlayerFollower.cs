using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public GameConstants constants;
    public GameObject player;
    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
            float camera_y = Mathf.Clamp(player.transform.position.y,constants.lowerBound + cam.orthographicSize, constants.upperBound - cam.orthographicSize);
            float camera_x = Mathf.Clamp(player.transform.position.x, constants.leftBound + cam.orthographicSize / 2, player.transform.position.x + cam.orthographicSize / 2);
            transform.position = Vector3.Lerp(transform.position, new Vector3(camera_x, camera_y, transform.position.z), constants.smoothRate);
    }
}
