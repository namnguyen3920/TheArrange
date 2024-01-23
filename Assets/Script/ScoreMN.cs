using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreMN : Singleton<ScoreMN>
{
    private int _score = 0;
    [SerializeField] private TextMeshProUGUI _currentScoreText;
    private void Start()
    {
        _currentScoreText.text = _score.ToString();
    }

    public void AddScore()
    {
        _score += 1;
        _currentScoreText.text = _score.ToString();
    }
}
