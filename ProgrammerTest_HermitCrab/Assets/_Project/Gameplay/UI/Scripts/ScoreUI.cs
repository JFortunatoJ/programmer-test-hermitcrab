using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void DisplayScore(int totalEnemies, int enemiesDefeated)
    {
        _scoreText.text = $"{enemiesDefeated}/{totalEnemies}";
    }
}
