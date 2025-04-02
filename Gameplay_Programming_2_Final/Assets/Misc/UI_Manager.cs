using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    public static UI_Manager Instance;
    public bool GameStarted;
    [SerializeField] public GameObject mainMenu;
    [SerializeField] private GameObject in_GameUI;
    [SerializeField] private GameObject Game_Over;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        if (GameStarted)
        {
            StartGame();
        }
    }

    public void StartGame()
    {
        var list = GameObject.FindGameObjectsWithTag("Spawner");
        foreach (var item in list)
        {
            item.GetComponent<SpawnerScript>().SpawnEntity();
        }
        mainMenu.SetActive(false);
        in_GameUI.SetActive(true);
        GameStarted = true;
    }

    public void EndGame(string CauseOfDeath)
    {
        in_GameUI.SetActive(false);
        Game_Over.SetActive(true);
        GameStarted = false;
        Game_Over.transform.GetChild(0).transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = CauseOfDeath;
    }

    public void RestartGame()
    {
        LevelMgr.instance.LoadLevel("GLOBAL");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
