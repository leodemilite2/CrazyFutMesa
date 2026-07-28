using UnityEngine;

public class LevelSelectManager : MonoBehaviour
{
    [SerializeField] private LevelButton[] levelButtons;

    private void Start()
    {
        int highestUnlockedLevel = SaveManager.Instance.GetHighestUnlockedLevel();

        foreach (LevelButton button in levelButtons)
        {
            bool unlocked = button.LevelNumber <= highestUnlockedLevel;
            int stars = SaveManager.Instance.GetStars(button.LevelNumber);

            button.Initialize(unlocked, stars);
        }
    }
}