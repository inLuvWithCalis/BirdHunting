using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverScreenView;
    [SerializeField] private Button _restartButton;
    [SerializeField] private AudioClip scoringSound;
    [SerializeField] private AudioClip gameOverSound;
    private AudioSource _audio;
    private int _score;
    public bool isGameOver; // manage the element action when player lose.
    
    
    
    private void Awake()
    {
        _audio = GetComponent<AudioSource>();
        _restartButton.onClick.AddListener(RestartGame);
        
        // For setup singleton.
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(gameObject); // active object through scenes.
    }
    
    public void AddScore(int score)
    {
        _score += score;
        scoreText.text = _score.ToString();
        _audio.PlayOneShot(scoringSound);
    }

    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ActiveGameOver()
    {
        isGameOver = true;
        gameOverScreenView.SetActive(true);
        _audio.PlayOneShot(gameOverSound);
        
    }
}
