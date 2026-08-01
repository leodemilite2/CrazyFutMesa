using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TeamCard : MonoBehaviour
{
    [SerializeField] private Image teamImage;
    [SerializeField] private TMP_Text teamName;
    [SerializeField] private GameObject lockIcon;
    [SerializeField] private TMP_Text unlockText;
    [SerializeField] private GameObject equippedText;
    [SerializeField] private Button button;
    private CosmeticData currentCosmetic;

    public void Setup(CosmeticData cosmetic)
    {
        currentCosmetic = cosmetic;
        bool unlocked =
            SaveManager.Instance.IsCosmeticUnlocked(cosmetic);

        unlockText.text =
            $"⭐ {SaveManager.Instance.GetTotalStars()}/{cosmetic.unlockValue}";

        teamName.text = cosmetic.itemName;

        bool selected = false;

        if (cosmetic is TeamData)
        {
            selected =
                SaveManager.Instance.GetSelectedTeamId() == cosmetic.id;
        }
        else if (cosmetic is BallData)
        {
            selected =
                SaveManager.Instance.GetSelectedBallId() == cosmetic.id;
        }

        equippedText.SetActive(selected);

        if (unlocked)
        {
            teamImage.gameObject.SetActive(true);
            teamImage.sprite = cosmetic.previewSprite;

            lockIcon.SetActive(false);
        }
        else
        {
            teamImage.gameObject.SetActive(false);

            lockIcon.SetActive(true);
        }

        button.onClick.RemoveAllListeners();

        if (unlocked)
        {
            button.interactable = true;
            button.onClick.AddListener(SelectCosmetic);
        }
        else
        {
            button.interactable = false;
        }
    }

  

    private void SelectCosmetic()
    {
        Debug.Log($"Cliquei em {currentCosmetic.itemName}");

        if (currentCosmetic is TeamData)
        {
            SaveManager.Instance.SelectTeam(currentCosmetic.id);
        }
        else if (currentCosmetic is BallData)
        {
            SaveManager.Instance.SelectBall(currentCosmetic.id);
        }

        SceneManager.LoadScene(
            SceneManager.GetActiveScene().name
        );
    }

}