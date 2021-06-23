using UnityEngine;

[
    CreateAssetMenu(
        fileName = "GameConstants",
        menuName = "ScriptableObjects/GameConstants",
        order = 0)
]
public class GameConstants : ScriptableObject
{
    [Header("Camera")]
    public float upperBound = 30.0f;

    public float lowerBound = -5.5f;

    public float leftBound = -2.5f;

    public float smoothRate = 0.2f;

    [Header("Player Control")]
    public float moveSpeed = 12;

    public float jumpForce = 250;

    [Header("Booster Item")]
    public float boostMoveSpeed = 2;

    [Header("Lucky Box")]
    public float emitForce = 10f;
}
