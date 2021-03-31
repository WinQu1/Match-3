using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    public GameObject levelPanel;

    // Start is called before the first frame update
    void Start()
    {
        levelPanel.SetActive(true);
    }

    public void PlayGame()
    {
        levelPanel.SetActive(true); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
