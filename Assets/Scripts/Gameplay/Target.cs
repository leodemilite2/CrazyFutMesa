using UnityEngine;
using UnityEngine.SceneManagement;

public class Target : MonoBehaviour
{
    [SerializeField] private GameObject winText;

    private bool levelCompleted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (levelCompleted)
            return;

        if (!other.CompareTag("BallTag"))
            return;

        levelCompleted = true;

        winText.SetActive(true);

        Time.timeScale = 0f;
    }

    private void Update()
    {
        if (levelCompleted && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

	if (levelCompleted == false && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}