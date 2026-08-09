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
    [SerializeField] private float winDelay = 0.5f;

	private bool levelCompleted = false;

[SerializeField] private TMP_Text starsText;
[SerializeField] private TMP_Text shotResultText;
[SerializeField] private TMP_Text threeStarsText;
[SerializeField] private TMP_Text twoStarsText;
[SerializeField] private TMP_Text oneStarText;
[SerializeField] private TMP_Text bestShotsText;
[SerializeField] private TMP_Text totalStarsText;
[SerializeField] private TMP_Text supportersText;

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
    UpdateBestShotsHUD();
    UpdateProgressPanel();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    public void OpenLevelSelect()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("LevelSelect");
    }

    public void OpenMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
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
        SceneManager.LoadScene("MainMenu");
    }
}

	public void LevelCompleted()
    {
        if (levelCompleted)
            return;

        levelCompleted = true;

        Debug.Log($"LevelCompleted - ShotCount = {ShotCount}");

        UpdateHUD();

        // Espera a bola entrar no gol antes de mostrar a vitória
        StartCoroutine(ShowWinScreenAfterDelay());
    }

    private System.Collections.IEnumerator ShowWinScreenAfterDelay()
    {
        yield return new WaitForSecondsRealtime(winDelay);

        winPanel.SetActive(true);

        Time.timeScale = 0f;

        Debug.Log($"Estrelas conquistadas: {GetStars()}");

        LevelResult result = GetLevelResult();

        SaveManager.Instance.SaveLevelResult(result);

        int supportersEarned = SaveManager.Instance.RewardSupporters(
            result.stars,
            currentLevel.supportersMultiplier
        );

        UpdateProgressPanel();

        Debug.Log($"Multiplicador: {currentLevel.supportersMultiplier}");
        Debug.Log($"Torcedores ganhos: {supportersEarned}");
        Debug.Log($"Total: {SaveManager.Instance.GetSupporters()}");

        UpdateBestShotsHUD();

        starsText.text = BuildStarsString(result.stars);
        shotResultText.text = $"Qtd. Impulsos: {result.impulses}";
    }
    public bool IsLevelCompleted()
    {
        return levelCompleted;
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
        levelIndex = currentLevel.levelNumber,
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

private void UpdateBestShotsHUD()
{
    int bestShots = SaveManager.Instance.GetBestShots(currentLevel.levelNumber);

    if (bestShots > 0)
        bestShotsText.text = $"Best: {bestShots:00}";
    else
        bestShotsText.text = "Best: --";
}

private void UpdateProgressPanel()
{
    totalStarsText.text =
        $"⭐ {SaveManager.Instance.GetTotalStars()}";

    supportersText.text =
        $"👥 {SaveManager.Instance.GetSupporters():N0}";
}

}