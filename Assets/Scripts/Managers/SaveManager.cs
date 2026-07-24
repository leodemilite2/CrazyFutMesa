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
            Destroy(gameObject);
            return;
        }

        Instance = this;

        LoadGame();
    }

    private void LoadGame()
    {
        if (File.Exists(SavePath))
        {
            string json = File.ReadAllText(SavePath);
            saveData = JsonUtility.FromJson<SaveData>(json);

            Debug.Log("Save carregado.");
        }
        else
        {
            saveData = new SaveData();

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
        while (saveData.levels.Count < result.levelIndex)
        {
            saveData.levels.Add(new LevelSaveData());
        }

        LevelSaveData levelData = saveData.levels[result.levelIndex - 1];

        // Mantém sempre a melhor pontuação em estrelas
        levelData.stars = Mathf.Max(levelData.stars, result.stars);

        // Guarda o menor número de impulsos
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
        if (levelIndex <= 0 || levelIndex > saveData.levels.Count)
            return 0;

        return saveData.levels[levelIndex - 1].stars;
    }

    public int GetBestShots(int levelIndex)
    {
        if (levelIndex <= 0 || levelIndex > saveData.levels.Count)
            return 0;

        return saveData.levels[levelIndex - 1].bestShots;
    }
}