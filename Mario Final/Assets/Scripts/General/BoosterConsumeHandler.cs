using UnityEngine;

public class BoosterConsumeHandler : MonoBehaviour
{
    public ObjectTypes.ObjectType _type;

    public BoolVar inventoryFull;

    public GameConstants constants;

    public IntegerGameEvent OnAddScore;

    public MushroomBooster booster;

    public MushroomGameEvent OnMushroomCollected;

    public GameEvent OnStompSoundPlay;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (!inventoryFull.Value)
            {
                OnAddScore.Raise(constants.mushroomCollected);
                OnMushroomCollected.Raise(booster);
                Destroy (gameObject);
                OnStompSoundPlay.Raise();
            }
        }
    }
}