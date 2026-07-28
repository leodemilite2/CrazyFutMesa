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
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private Image[] stars;

    [SerializeField] private Sprite filledStar;
[SerializeField] private Sprite emptyStar;

    private Button button;
    private Image image;

    private void Awake()
    {
        button = GetComponent<Button>();
        image = GetComponent<Image>();

        button.onClick.AddListener(LoadLevel);
    }

    public void Initialize(bool unlocked, int starCount)
    {
        button.interactable = unlocked;

        image.color = unlocked
            ? Color.white
            : Color.gray;

        levelText.text = levelNumber.ToString("00");

        lockIcon.SetActive(!unlocked);

        for (int i = 0; i < stars.Length; i++)
        {
            stars[i].gameObject.SetActive(unlocked);

            stars[i].sprite = i < starCount
                ? filledStar
                : emptyStar;
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneName);
    }
}