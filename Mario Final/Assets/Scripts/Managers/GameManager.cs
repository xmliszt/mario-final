using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    [Header("Variables to reset")]

    public BoolVar inventoryFull;

    public IntVar score;

    [Header("Dead Mario Prefab")]
    public GameObject deadMario;
    private GameObject instantiatedDeadMario;

    private void Start() {
        score.Set(0);
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
}
