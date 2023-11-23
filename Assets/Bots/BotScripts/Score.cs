using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] private Base _base;
    [SerializeField] private TMP_Text _score;

    private void OnEnable()
    {
        _base.ScoreChanged += WriteScore;
    }

    private void OnDisable()
    {
        _base.ScoreChanged -= WriteScore;
    }

    private void WriteScore(int value)
    {
        _score.text = value.ToString();
    }
}
