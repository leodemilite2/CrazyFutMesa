using UnityEngine;
using TMPro;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private LevelButton[] levelButtons;
    [SerializeField] private TMP_Text starsText;
    [SerializeField] private TMP_Text supportersText;

    private void Start()
    {
        int highestUnlockedLevel = SaveManager.Instance.GetHighestUnlockedLevel();

        foreach (LevelButton button in levelButtons)
        {
            bool unlocked = button.LevelNumber <= highestUnlockedLevel;
            int stars = SaveManager.Instance.GetStars(button.LevelNumber);

            button.Initialize(unlocked, stars);
        }

        starsText.text =
            $"⭐ {SaveManager.Instance.GetTotalStars()}";

        supportersText.text =
            $"👥 {SaveManager.Instance.GetSupporters():N0}";
    }
}