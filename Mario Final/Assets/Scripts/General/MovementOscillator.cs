using System.Collections;
using UnityEngine;

public class MovementOscillator : MonoBehaviour
{
    public enum ObjectType
    {
        gomba = 1,
        boost = 2
    }

    public GameConstants constants;

    public ObjectType _type;

    private float moveSpeed;

    private bool goRight; // true: right | false: left

    private bool disableSwitch = false;

    private void Start()
    {
        goRight = true;
        StartCoroutine(StartSwitching());
    }

    // Update is called once per frame
    void Update()
    {
        switch (_type)
        {
            case ObjectType.gomba:
                moveSpeed = constants.enemyMoveSpeed;
                break;
            case ObjectType.boost:
                moveSpeed = constants.boostMoveSpeed;
                break;
        }
        if (!goRight)
        {
            // move left
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        else
        {
            // move right
            transform.Translate(Vector2.right * Time.deltaTime * moveSpeed);
        }
    }

    IEnumerator StartSwitching()
    {
        while (true)
        {
            float timeDelay =
                Random
                    .Range(constants.switchDirectionDelayMin,
                    constants.switchDirectionDelayMax);
            yield return new WaitForSeconds(timeDelay);
            SwitchDirection();
        }
    }

    private void SwitchDirection()
    {
        if (!disableSwitch) {
            goRight = !goRight;
            disableSwitch = true;
            StartCoroutine(enableSwitch());
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SwitchDirection();
    }

    IEnumerator enableSwitch() {
        yield return new WaitForSeconds(1);
        disableSwitch = false;
    }
}
