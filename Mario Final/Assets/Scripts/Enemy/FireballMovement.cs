using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    public GameConstants constants;
    void Update()
    {
        if (transform.position.y > constants.destroyBoundY)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector2.up * Time.deltaTime * constants.fireballMoveSpeed);
    }
}
