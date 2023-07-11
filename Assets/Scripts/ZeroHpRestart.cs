using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZeroHpRestart : MonoBehaviour
{
    //[SerializeField] private Wall _wall;
    [SerializeField] private GameObject _defeatCanvas;

    [SerializeField ]private int _testHp = 5;

    private void Update()
    {
        if(_testHp <= 0/*_wall.health <= 0 */)
        {
            Time.timeScale = 0;
            _defeatCanvas.SetActive(true);
        }
        else
        {
            return;
        }
    }

    public void OnRestartClicked()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
