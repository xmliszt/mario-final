using UnityEngine;

[
    CreateAssetMenu(
        fileName = "GameConstants",
        menuName = "ScriptableObjects/GameConstants",
        order = 0)
]
public class GameConstants : ScriptableObject
{
    [Header("Score")]

    public int coinCollected = 1;

    public int gombaKilled = 3;

    [Header("Camera")]
    public float upperBound = 30.0f;

    public float lowerBound = -5.5f;

    public float leftBound = -2.5f;

    public float smoothRate = 0.2f;

    [Header("Player Control")]
    public float moveSpeed = 12;

    public float jumpForce = 250;

    [Header("Movement Configuration")]
    
    public float switchDirectionDelayMin = 2;
    public float switchDirectionDelayMax = 5;

    [Header("Booster Item")]
    public float boostMoveSpeed = 2;

    [Header("Lucky Box")]
    public float emitForce = 10f;

    public float emitOffsetY = 0.6f;

    [Header("Fireball")]

    public float fireballMoveSpeed = 10;
    public float destroyBoundY = 20;

    [Header("Enemy")]

    public float enemyMoveSpeed = 2;
}
