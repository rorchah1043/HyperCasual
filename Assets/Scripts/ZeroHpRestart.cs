using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroHpRestart : MonoBehaviour
{
    [SerializeField] private Wall wall;
    [SerializeField] private GameObject defeatCanvas;

    private void Update()
    {
        if (wall.health <= 0 && !defeatCanvas.activeSelf)
        {
            Time.timeScale = 0;
            defeatCanvas.SetActive(true);
        }
    }

    public void OnRestartClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}