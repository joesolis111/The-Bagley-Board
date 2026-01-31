using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace DiningPhilosophers {
  public class Fork : MonoBehaviour {
    private bool _taken;
    SpriteRenderer _spriteRenderer;

    public void Awake() {
      _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    
    public void Update() {
      if (_taken) {
        _spriteRenderer.enabled = false;
      }
      else {
        _spriteRenderer.enabled = true;
      }
    }

    public void TakeFork(TextMeshProUGUI scoreText, int playerNumber) {

      if (_taken) {
        return;
      }

      scoreText.text = $"Player {playerNumber} Score: {Int32.Parse(scoreText.text[scoreText.text.Length - 1].ToString()) + 1}";
      _taken = true;
      StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer() {
      yield return new WaitForSeconds(3);
      _taken = false;
    }
  }
}