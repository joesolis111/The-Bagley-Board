using System.Collections;
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

    public void TakeFork() {
      _taken = true;
      StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer() {
      yield return new WaitForSeconds(3);
      _taken = false;
    }
  }
}