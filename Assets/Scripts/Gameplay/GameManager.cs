using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

[Header("Level")]
[SerializeField] private LevelData currentLevel;

    public static GameManager Instance;

    public int ShotCount { get; private set; }

	[SerializeField] private GameObject winPanel;
	[SerializeField] private TMP_Text shotCountText;

	private bool levelCompleted = false;

[SerializeField] private TMP_Text starsText;
[SerializeField] private TMP_Text shotResultText;
[SerializeField] private TMP_Text threeStarsText;
[SerializeField] private TMP_Text twoStarsText;
[SerializeField] private TMP_Text oneStarText;



private void Awake()
{
    if (Instance != null && Instance != this)
    {
        Destroy(gameObject);
        return;
    }

    Instance = this;

    if (currentLevel == null)
    {
        Debug.LogError("GameManager: Current Level não foi atribuído!");
    }

    levelCompleted = false;
    Time.timeScale = 1f;

    ShotCount = 0;

    UpdateHUD();
UpdateStarsGoalPanel();
}

    public void RegisterShot()
    {
        ShotCount++;
	UpdateHUD();
        Debug.Log($"Impulsos: {ShotCount}");
    }

  	public void ResetLevel()
	{
	    Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

    public void LoadNextLevel()
{
    Time.timeScale = 1f;

    int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

    if (nextScene < SceneManager.sceneCountInBuildSettings)
    {
        SceneManager.LoadScene(nextScene);
    }
    else
    {
        Debug.Log("Última fase concluída!");
    }
}

	public void LevelCompleted()
	{
	    if (levelCompleted)
	        return;
	
	    levelCompleted = true;

	    Debug.Log($"LevelCompleted - ShotCount = {ShotCount}");

            UpdateHUD();
	
	    winPanel.SetActive(true);
	
	    Time.timeScale = 0f;

	    Debug.Log($"Estrelas conquistadas: {GetStars()}");

	    LevelResult result = GetLevelResult();

	    starsText.text = BuildStarsString(result.stars);
	    shotResultText.text = $"Qtd. Impulsos: {result.impulses}";
    }
private void Update()
{
    if (Input.GetKeyDown(KeyCode.R))
    {
        ResetLevel();
        return;
    }

    if (!levelCompleted)
        return;

    if (Input.GetKeyDown(KeyCode.N))
    {
        LoadNextLevel();
    }
}

public int GetStars()
{
    if (ShotCount <= currentLevel.threeStarShots)
        return 3;

    if (ShotCount <= currentLevel.twoStarShots)
        return 2;

    if (ShotCount <= currentLevel.oneStarShots)
        return 1;

    return 0;
}

private string BuildStarsString(int stars)
{
    switch (stars)
    {
        case 3: return "3 ESTRELAS!";
        case 2: return "2 ESTRELAS!";
        case 1: return "1 ESTRELA!";
        default: return "PRÓXIMA FASE!";
    }
}

public LevelResult GetLevelResult()
{
    return new LevelResult
    {
        stars = GetStars(),
        impulses = ShotCount
    };
}

private void UpdateHUD()
{
    if (shotCountText == null)
    {
        Debug.LogError("ShotCountText não foi atribuído no GameManager.");
        return;
    }

    shotCountText.text = $"Impulsos: {ShotCount:00}";
}

private void UpdateStarsGoalPanel()
{
    if (currentLevel == null)
        return;

    if (threeStarsText == null || twoStarsText == null || oneStarText == null)
    {
        Debug.LogError("StarsGoalPanel não está configurado no GameManager.");
        return;
    }

    threeStarsText.text = $"★★★ {currentLevel.threeStarShots:00}";
    twoStarsText.text   = $"★★  {currentLevel.twoStarShots:00}";
    oneStarText.text    = $"★   {currentLevel.oneStarShots:00}";
}

}