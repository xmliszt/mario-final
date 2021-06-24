using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public GameEvent OnGameWin;
    private bool isPlayerEnter = false;

    private void Update()
    {
        bool isDownPressed =
            (
            Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)
            );
        if (isPlayerEnter && isDownPressed)
        {
            StartCoroutine(ChangeScene());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }

    IEnumerator ChangeScene()
    {
        // Not the last scene
        if (SceneManager.GetActiveScene().name != "Level3")
        {
            AsyncOperation newSceneOperation =
                SceneManager
                    .LoadSceneAsync(SceneManager.GetActiveScene().buildIndex +
                    1);
            while (!newSceneOperation.isDone)
            {
                yield return null;
            }
        }
        else
        {
            // trigger gameover event
            OnGameWin.Raise();
        }
    }
}
