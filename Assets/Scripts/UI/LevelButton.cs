using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int levelNumber;
    [SerializeField] private string sceneName;

    public int LevelNumber => levelNumber;

    [Header("UI")]
    [SerializeField] private TMP_Text levelText;

    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        button.onClick.AddListener(LoadLevel);
    }

    public void Initialize(bool unlocked)
    {
        button.interactable = unlocked;
        levelText.text = levelNumber.ToString("00");

        image.color = unlocked
            ? Color.white
            : Color.gray;
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}