using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private bool isPlayerEnter = false;

    private void Update() {
        bool isDownPressed = (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S));
        if (isPlayerEnter && isDownPressed){

        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            isPlayerEnter = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            isPlayerEnter = false;
        }
    }

    IEnumerator ChangeScene()
    {
        AsyncOperation newSceneOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        while (!newSceneOperation.isDone)
        {
            yield return null;
        }
    }
}
