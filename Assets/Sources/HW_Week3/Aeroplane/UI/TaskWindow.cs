using UnityEngine;
using TMPro;

public class TaskWindow : MonoBehaviour
{
    [SerializeField] private AeroplaneGameLogic _gameLogic;
    [SerializeField] private TMP_Text _goalText;

    private void Start()
    {
        _goalText.text = _gameLogic.CoinsToWin.ToString();
    }
}