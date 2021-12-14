using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDown : MonoBehaviour
{
  public float countdown = 60.0f;
  private GameManagerX gameManagerX;
  private TextMeshProUGUI countdownText;

  void Start()
  {
    gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();
    countdownText = GetComponent<TextMeshProUGUI>();
  }

  void Update()
  {
    var roundedCountdown = Mathf.Round(countdown);
    if (gameManagerX.isGameActive)
    {
      countdown -= Time.deltaTime;
      countdownText.text = $"Time: {roundedCountdown}";
    }
    if (roundedCountdown <= 0)
    {
      gameManagerX.GameOver();
    }
  }
}
