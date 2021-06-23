using UnityEngine;

public class PlayerFollower : MonoBehaviour
{
    public FloatVar playerPositionX;
    public FloatVar playerPositionY;
    public GameConstants constants;
    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
            float camera_y = Mathf.Clamp(playerPositionY.Value,constants.lowerBound + cam.orthographicSize, constants.upperBound - cam.orthographicSize);
            float camera_x = Mathf.Clamp(playerPositionX.Value, constants.leftBound + cam.orthographicSize / 2, playerPositionX.Value + cam.orthographicSize / 2);
            transform.position = Vector3.Lerp(transform.position, new Vector3(camera_x, camera_y, transform.position.z), constants.smoothRate);
    }
}
