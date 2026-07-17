using UnityEngine;

public class Target : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("BallTag"))
            return;

        GameManager.Instance.LevelCompleted();
    }
}