using UnityEngine;

public class CanvasCameraAttachment : MonoBehaviour
{
    public Canvas canvas;
    void Start()
    {
        Camera mainCamera = FindObjectOfType<Camera>();
        canvas.worldCamera = mainCamera;
    }
}
