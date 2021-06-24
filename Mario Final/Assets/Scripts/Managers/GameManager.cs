using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [Header("Variables to reset")]

    public BoolVar inventoryFull;

    public IntVar score;

    public Inventory inventory;

    [Header("Dead Mario Prefab")]
    public GameObject deadMario;
    private GameObject instantiatedDeadMario;

    private void Start() {
        inventoryFull.Set(false);    
    }

    public void PlayMarioDeathResponse(Vector3 location) 
    {
        instantiatedDeadMario = Instantiate(deadMario, location, deadMario.transform.rotation);
        StartCoroutine(RemoveDeadMario());
    }

    IEnumerator RemoveDeadMario() 
    {
        yield return new WaitForSeconds(2);
        Destroy(instantiatedDeadMario);
    }

    public void RestartGame()
    {
        score.Set(0);
        inventory.ClearAll();
    }
}
