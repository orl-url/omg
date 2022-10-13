using System;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public WavesManager wavesManager;
    public GameObject cardCanvas;
    
    private void Update()
    {
    }

    private void Start()
    {
    }

    public void CreateCards()
    {
        cardCanvas.SetActive(true);
    }

    public void PlayGame()
    {
        cardCanvas.SetActive(false);
        Time.timeScale = 1;
    }
}
