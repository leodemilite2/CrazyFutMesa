using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private SaveData saveData;

    private string SavePath =>
        Path.Combine(Application.persistentDataPath, "save.json");

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Debug.Log(
                $"Destruindo SaveManager duplicado: {GetEntityId()}");
            
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();

        Debug.Log($"Estrelas Totais: {GetTotalStars()}");
        Debug.Log($"Torcedores: {GetSupporters()}");
        
    }

    private void LoadGame()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            saveData = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Save carregado.");
            Debug.Log($"LOAD -> Team: {saveData.selectedTeamId} | Ball: {saveData.selectedBallId}"
        );
        }
        else
        {
            saveData = new SaveData();

            saveData.highestUnlockedLevel = 0;

            SaveGame();

            Debug.Log("Novo save criado.");
        }
    }

    public void SaveGame()
    {
        string json = JsonUtility.ToJson(saveData, true);

        Debug.Log(SavePath);

        File.WriteAllText(SavePath, json);

        Debug.Log(json);
    }

    public SaveData GetSaveData()
    {
        return saveData;
    }

    public void SaveLevelResult(LevelResult result)
    {
        // Garante que exista um registro para esta fase
        while (saveData.levels.Count <= result.levelIndex)
        {
            saveData.levels.Add(new LevelSaveData());
        }

        LevelSaveData levelData = saveData.levels[result.levelIndex];

        // Mantém sempre a maior quantidade de estrelas
        levelData.stars = Mathf.Max(levelData.stars, result.stars);

        // Mantém o menor número de impulsos
        if (levelData.bestShots == 0 || result.impulses < levelData.bestShots)
        {
            levelData.bestShots = result.impulses;
        }

        // Desbloqueia a próxima fase
        saveData.highestUnlockedLevel = Mathf.Max(
            saveData.highestUnlockedLevel,
            result.levelIndex + 1
        );

        SaveGame();
    }

    public int GetHighestUnlockedLevel()
    {
        return saveData.highestUnlockedLevel;
    }


    public int GetStars(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= saveData.levels.Count)
            return 0;

        return saveData.levels[levelIndex].stars;
    }

    public int GetBestShots(int levelIndex)
    {
        if (levelIndex < 0 || levelIndex >= saveData.levels.Count)
            return 0;

        return saveData.levels[levelIndex].bestShots;
    }

    public int GetSupporters()
    {
        return saveData.supporters;
    }

    public void AddSupporters(int amount)
    {
        saveData.supporters += amount;

        SaveGame();
    }

    public int GetTotalStars()
    {
        int total = 0;

        foreach (LevelSaveData level in saveData.levels)
        {
            total += level.stars;
        }

        return total;
    }

    public int RewardSupporters(int stars, float multiplier)
    {
        int baseReward = 0;

        switch (stars)
        {
            case 0:
                baseReward = Random.Range(0, 101);
                break;

            case 1:
                baseReward = Random.Range(100, 1001);
                break;

            case 2:
                baseReward = Random.Range(1000, 10001);
                break;

            case 3:
                baseReward = Random.Range(10000, 100001);
                break;
        }

        int finalReward = Mathf.RoundToInt(baseReward * multiplier);

        AddSupporters(finalReward);

        return finalReward;
    }

    public bool IsUnlocked(UnlockMethod method, int unlockValue)
    {
        switch (method)
        {
            case UnlockMethod.Stars:
                return GetTotalStars() >= unlockValue;

            case UnlockMethod.Supporters:
                return GetSupporters() >= unlockValue;

            default:
                return false;
        }
    }

    public bool IsTeamUnlocked(TeamData team)
    {
        return IsCosmeticUnlocked(team);
    }

    public bool IsBallUnlocked(BallData ball)
    {
        return IsCosmeticUnlocked(ball);
    }

    public bool IsCosmeticUnlocked(CosmeticData cosmetic)
    {
        return IsUnlocked(
            cosmetic.unlockMethod,
            cosmetic.unlockValue
        );
    }

    public void SelectTeam(int teamId)
    {
        saveData.selectedTeamId = teamId;
        Debug.Log($"SAVE TEAM -> {teamId}");
        SaveGame();
    }

    public void SelectBall(int ballId)
    {
        saveData.selectedBallId = ballId;
        Debug.Log($"SAVE BALL -> {ballId}");
        SaveGame();
    }

    public int GetSelectedTeamId()
    {
        return saveData.selectedTeamId;
    }

    public int GetSelectedBallId()
    {
        return saveData.selectedBallId;
    }

    public void SetShowingBalls(bool value)
    {
        saveData.showingBalls = value;

        SaveGame();
    }

    public bool IsShowingBalls()
    {
        return saveData.showingBalls;
    }

    public TeamData GetSelectedTeam()
    {
        TeamData[] teams =
            Resources.LoadAll<TeamData>("Teams");

        foreach (TeamData team in teams)
        {
            if (team.id == saveData.selectedTeamId)
            {
                return team;
            }
        }

        return null;
    }

    public BallData GetSelectedBall()
    {
        BallData[] balls =
            Resources.LoadAll<BallData>("Balls");

        foreach (BallData ball in balls)
        {
            if (ball.id == saveData.selectedBallId)
            {
                return ball;
            }
        }

        return null;
    }
}