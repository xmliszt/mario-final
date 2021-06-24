using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{    
    [Header("UI Control")]
    public GameObject GameOverScreen;

    public GameObject WinScreen;

    [Header("Variables to reset")]

    public BoolVar inventoryFull;

    public IntVar score;

    public Inventory inventory;

    [Header("Dead Mario Prefab")]
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

    public void GoHome()
    {
        SceneManager.LoadScene("Start");
    }

    public void StartGame()
    {
        ResetAll();
        SceneManager.LoadScene("Level1");
    }

    public void GameOver()
    {
        GameObject gameOverPage = Instantiate(GameOverScreen);
        
    }

    public void GameWin()
    {
        GameObject winPage = Instantiate(WinScreen);
    }

    private void ResetAll()
    {
        inventoryFull.Set(false);
        score.Set(0);
        inventory.ClearAll();

    }
}
