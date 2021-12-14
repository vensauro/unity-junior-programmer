using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
  public List<GameObject> targets;
  private int score;
  public TextMeshProUGUI scoreText;
  private float spawnRate = 1;
  public TextMeshProUGUI gameOverText;
  public Button restartButton;
  public bool isGameActive;
  public GameObject titleScreen;

  void Start() { }

  public void StartGame(int difficulty)
  {
    spawnRate /= difficulty;
    isGameActive = true;
    StartCoroutine(SpawnTarget());
    score = 0;
    UpdateScore(0);
    titleScreen.gameObject.SetActive(false);
  }

  IEnumerator SpawnTarget()
  {
    while (isGameActive)
    {
      yield return new WaitForSeconds(spawnRate);
      int index = Random.Range(0, targets.Count);
      Instantiate(targets[index]);
    }
  }

  public void UpdateScore(int scoreToAdd)
  {
    score += scoreToAdd;
    scoreText.text = "Score: " + score;
  }

  public void GameOver()
  {
    gameOverText.gameObject.SetActive(true);
    restartButton.gameObject.SetActive(true);
    isGameActive = false;
  }

  public void RestartGame()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
  }

  void Update()
  {

  }
}
