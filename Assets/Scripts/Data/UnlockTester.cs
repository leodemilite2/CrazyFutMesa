using UnityEngine;

public class UnlockTester : MonoBehaviour
{
    [SerializeField] private TeamData team;

    private void Start()
    {
        bool unlocked =
            SaveManager.Instance.IsTeamUnlocked(team);

        Debug.Log(
            $"{team.itemName}: {unlocked}"
        );
    }
}