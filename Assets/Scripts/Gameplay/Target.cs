using UnityEngine;

public class Target : MonoBehaviour
{
/*
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("BallTag"))
            return;

        GameManager.Instance.LevelCompleted();
    }
*/
private void OnTriggerEnter2D(Collider2D other)
{
    Debug.Log("Entrou: " + other.name);

    if (other.CompareTag("BallTag"))
    {
        Debug.Log("GOOOOL!");

        GameManager.Instance.LevelCompleted();
    }
}
}