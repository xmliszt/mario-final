using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomMovement : MonoBehaviour
{
    public GameConstants constants;
    public BoxCollider2D[] colliders;
    private bool goRight; // true: right | false: left
    private void Start()
    {
        goRight = true;
        InvokeRepeating("StartSwitching", 0, 5);
    }
    // Update is called once per frame
    void Update()
    {

        if (!goRight)
        {
            // move left
            transform.Translate(Vector2.left * Time.deltaTime * constants.boostMoveSpeed);
        }
        else
        {
            // move right
            transform.Translate(Vector2.right * Time.deltaTime * constants.boostMoveSpeed);
        }

    }

    private void StartSwitching()
    {
        float timeDelay = Random.Range(2.0f, 5.0f);
        Invoke("SwitchDirection", timeDelay);
    }

    private void SwitchDirection()
    {
        goRight = !goRight;
    }

}
