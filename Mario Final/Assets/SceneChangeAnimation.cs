using UnityEngine;

public class SceneChangeAnimation : MonoBehaviour
{
    private void Update() {
        Vector3 camPosition = FindObjectOfType<Camera>().transform.position;
        transform.position = new Vector3(camPosition.x, camPosition.y, 0);
    }
    public Animator transitionAnimator;
    public void StartTransition()
    {
        transitionAnimator.SetTrigger("start");
    }
}
