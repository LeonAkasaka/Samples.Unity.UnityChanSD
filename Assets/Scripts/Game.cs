using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText = null;
    
    public int TotalScore
    {
        get { return _totalScore; }
        set
        {
            _totalScore = value;
            if (_scoreText != null) { _scoreText.text = value.ToString(); }
        }
    }
    private int _totalScore;

    private void Start()
    {
        TotalScore = 0;
    }
}