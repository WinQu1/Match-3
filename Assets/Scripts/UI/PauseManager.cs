using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    private Board board;
    public string newLevel;
    public bool paused = false;
    public Image musicButton;
    public Sprite musicOnSprite;
    public Sprite musicOffSprite;
    private SoundManager sound;

    // Start is called before the first frame update
    void Start()
    {
        sound = FindObjectOfType<SoundManager>();
        board = FindObjectOfType<Board>();
        pausePanel.SetActive(false);
        if (PlayerPrefs.HasKey("Sound"))
        {
            if(PlayerPrefs.GetInt("Sound") == 0)
            {
                musicButton.sprite = musicOffSprite;
            }
            else
            {
                musicButton.sprite = musicOnSprite;
            }
        }
        else
        {
            musicButton.sprite = musicOnSprite;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(paused && !pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(true);
            board.currentState = GameState.pause;
        }
        if (!paused && pausePanel.activeInHierarchy)
        {
            pausePanel.SetActive(false);
            board.currentState = GameState.move;
        }

    }
    public void Sound()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            if (PlayerPrefs.GetInt("Sound") == 0)
            {
                PlayerPrefs.SetInt("Sound", 1);
                musicButton.sprite = musicOnSprite;
                sound.adjustVolume();
            }
            else
            {
                PlayerPrefs.SetInt("Sound", 0);
                musicButton.sprite = musicOffSprite;
                sound.adjustVolume();
            }
        }
        else
        {
            PlayerPrefs.SetInt("Sound", 0);
            musicButton.sprite = musicOffSprite;
            sound.adjustVolume();
        }
    }
    public void PauseGame()
    {
        paused = !paused;
    }

    public void ExitGame()
    {
        SceneManager.LoadScene(newLevel);
    }
}
