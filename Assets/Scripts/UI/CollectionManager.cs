using TMPro;
using UnityEngine;

public class CollectionManager : MonoBehaviour
{
    [Header("Times")]
    [SerializeField] private TeamData[] teams;

    [Header("Bolas")]
    [SerializeField] private BallData[] balls;

    [Header("Prefab")]
    [SerializeField] private TeamCard teamCardPrefab;

    [Header("UI")]
    [SerializeField] private Transform grid;

    [SerializeField] private TMP_Text starsText;

    [SerializeField] private TMP_Text supportersText;
    private bool showingBalls = false;

    private void Start()
    {
        UpdateProgressPanel();

        if (SaveManager.Instance.IsShowingBalls())
        {
            ShowBalls();
        }
        else
        {
            ShowTeams();
        }
    }

    private void UpdateProgressPanel()
    {
        starsText.text =
            $"⭐ {SaveManager.Instance.GetTotalStars()}";

        supportersText.text =
            $"👥 {SaveManager.Instance.GetSupporters():N0}";
    }

    public void ShowTeams()
    {
        SaveManager.Instance.SetShowingBalls(false);
        showingBalls = false;
        

        ClearGrid();

        foreach (TeamData team in teams)
        {
            TeamCard card = Instantiate(teamCardPrefab, grid);

            card.Setup(team);
        }
    }

    public void ShowBalls()
    {
        SaveManager.Instance.SetShowingBalls(true);
        showingBalls = true;

        ClearGrid();

        foreach (BallData ball in balls)
        {
            TeamCard card = Instantiate(teamCardPrefab, grid);

            card.Setup(ball);
        }
    }

    private void ClearGrid()
    {
        foreach (Transform child in grid)
        {
            Destroy(child.gameObject);
        }
    }
}