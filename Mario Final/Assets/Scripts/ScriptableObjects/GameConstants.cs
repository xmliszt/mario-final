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

    public int mushroomCollected = 2;

    [Header("Inventory Manager")]
    public int capacity = 4;

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
    public float goldenMushroomMoveSpeed = 4;

    public float goldenMushroomSizeUpMultiplier = 1.5f;

    public float goldenMushroomEffectDuration = 5; // seconds

    public Color goldenMushroomEffectColor;

    public float goldenMushroomEffectIntensity = 1.5f;

    public float speedMushroomMoveSpeed = 2;

    public float speedMushroomGainSpeed = 10;

    public float speedMushroomEffectDuration = 5; // seconds

    public Color speedMushroomEffectColor;

    public float speedMushroomEffectIntensity = 1.5f;

    public float jumperMushroomMoveSpeed = 3;

    public float jumperMushroomJumpForceGain = 100;

    public float jumperMushroomEffectDuration = 5; // seconds

    public Color jumperMushroomEffectColor;

    public float jumperMushroomEffectIntensity = 1.5f;

    [Header("Lucky Box")]
    public float emitForce = 10f;

    public float emitOffsetY = 0.6f;

    [Header("Fireball")]
    public float fireballMoveSpeed = 10;

    public float destroyBoundY = 20;

    [Header("Enemy")]
    public float enemyMoveSpeed = 2;
}
