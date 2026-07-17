using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int ShotCount { get; private set; }

	[SerializeField] private GameObject winPanel;
	[SerializeField] private TMP_Text shotCountText;

	private bool levelCompleted = false;

private void Awake()
{
    Instance = this;

    levelCompleted = false;
    Time.timeScale = 1f;
}

    public void RegisterShot()
    {
        ShotCount++;
        Debug.Log($"Impulsos: {ShotCount}");
    }

  	public void ResetLevel()
	{
	    ShotCount = 0;
	}

	public void LevelCompleted()
	{
	    if (levelCompleted)
	        return;
	
	    levelCompleted = true;

	    Debug.Log($"LevelCompleted - ShotCount = {ShotCount}");

            shotCountText.text = $"Impulsos: {ShotCount}";
	
	    winPanel.SetActive(true);
	
	    Time.timeScale = 0f;
	}

private void Update()
{
    // Reinicia a fase a qualquer momento
    if (Input.GetKeyDown(KeyCode.R))
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        return;
    }

    // Só permite avançar após concluir a fase
    if (!levelCompleted)
        return;

    if (Input.GetKeyDown(KeyCode.N))
    {
        Time.timeScale = 1f;

        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        if (nextScene < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
}