using System.Collections;
using UnityEngine;

public class MovementOscillator : MonoBehaviour
{

    public GameConstants constants;

    public ObjectTypes.ObjectType _type;
    private float moveSpeed;

    private int goRight; // 1: right | 0: left

    private bool disableSwitch = false;

    private void Start()
    {
        goRight = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        switch (_type)
        {
            case ObjectTypes.ObjectType.gomba:
                moveSpeed = constants.enemyMoveSpeed;
                break;
            case ObjectTypes.ObjectType.goldenMushroom:
                moveSpeed = constants.goldenMushroomMoveSpeed;
                break;
            case ObjectTypes.ObjectType.speedMushroom:
                moveSpeed = constants.speedMushroomMoveSpeed;
                break;
            case ObjectTypes.ObjectType.jumperMushroom:
                moveSpeed = constants.jumperMushroomMoveSpeed;
                break;
        }
        if (goRight == 0)
        {
            transform.Translate(Vector2.left * Time.deltaTime * moveSpeed);
        }
        else
        {
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
            if (goRight == 0) goRight = 1;
            else goRight = 0;
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
