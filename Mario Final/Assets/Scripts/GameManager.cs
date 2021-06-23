using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{    
    public GameObject deadMario;
    private GameObject instantiatedDeadMario;
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
