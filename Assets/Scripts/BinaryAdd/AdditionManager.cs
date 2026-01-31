using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BinaryAdd {
  public class AdditionManager : MonoBehaviour {
    [SerializeField]
    private TextMeshProUGUI player1Text;
    [SerializeField]
    private TextMeshProUGUI player2Text;

    [SerializeField]
    private TextMeshProUGUI player1ScoreText;
    [SerializeField]
    private TextMeshProUGUI player2ScoreText;

    private readonly ConvertToBinary _convertToBinary = new();

    private (Dictionary<BinaryKeys, string>, Dictionary<BinaryKeys, string>) _currentP1Set;
    private (Dictionary<BinaryKeys, string>, Dictionary<BinaryKeys, string>) _currentP2Set;

    private string _input;

    public void Awake() {
      _currentP1Set = ResetSet();
      _currentP2Set = ResetSet();

      AssignText(1);
      AssignText(2);
    }

    private (Dictionary<BinaryKeys, string>, Dictionary<BinaryKeys, string>) ResetSet() {
      return (_convertToBinary.GetBinaryNumber(), _convertToBinary.GetBinaryNumber());

    }

    public void ResetPlayerSet(int playerNumber) {
      if (playerNumber == 1) {
        _currentP1Set = ResetSet();
      }
      else {
        _currentP2Set = ResetSet();
      }

      AssignText(playerNumber);
    }

    public void processAnswer(string answer, int playerNumber) {
      _input = answer;
      int numAnswer = int.Parse(answer);

      bool isPlayer1 = playerNumber == 1;

      bool correct = isPlayer1 ? int.Parse(_currentP1Set.Item1[BinaryKeys.DecNumber]) + int.Parse(_currentP1Set.Item2[BinaryKeys.DecNumber]) == numAnswer : int.Parse(_currentP2Set.Item1[BinaryKeys.DecNumber]) + int.Parse(_currentP2Set.Item2[BinaryKeys.DecNumber]) == numAnswer;

      if (correct) {
        if (isPlayer1) {
          char currentScore = player1ScoreText.text[player1ScoreText.text.Length - 1];
          player1ScoreText.text = $"Player {playerNumber} Score: {int.Parse(currentScore.ToString()) + 1}";
        }
        else {
          char currentScore = player2ScoreText.text[player2ScoreText.text.Length - 1];
          player2ScoreText.text = $"Player {playerNumber} Score: {int.Parse(currentScore.ToString()) + 1}";
        }
      }

      ResetPlayerSet(playerNumber);
    }

    private void AssignText(int playerNumber) {
      if (playerNumber == 1) {
        player1Text.text = $"{_currentP1Set.Item1[BinaryKeys.BinNumber]}\n + \n {_currentP1Set.Item2[BinaryKeys.BinNumber]}";
      }
      else {
        player2Text.text = $"{_currentP2Set.Item1[BinaryKeys.BinNumber]}\n + \n {_currentP2Set.Item2[BinaryKeys.BinNumber]}";
      }
    }
  }
}