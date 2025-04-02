using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMgr : MonoBehaviour
{
    public static LevelMgr instance;                // look at a more generic singleton pattern after the break;
    [SerializeField] private List<string> levels;   // lvls to load by name

    [Header("state")]
    Scene GlobalScene = default;                              // need to ensure global sticks around
    Scene CurrentScene = default;
    Scene PrevScene = default;

    public void LoadLevel(string s)
    {
        SceneManager.LoadSceneAsync(s, LoadSceneMode.Single); // multiple scene files at same time
    }

    public void OnSceneLoaded(Scene newScene, LoadSceneMode mode)
    {
        // track the state of the scenes coming in, and implement our scene file strategy
        CurrentScene = newScene;

        // do some cleanup
        // implement lvl switch so we can go from 1 to 2 to ....
        // aka : auto unload prev level
        if (PrevScene.name != null)
            SceneManager.UnloadSceneAsync(PrevScene);
        else
        {
            if (CurrentScene != GlobalScene)
                PrevScene = CurrentScene;
        }
    }
    public void OnSceneLoaded2(Scene newScene, LoadSceneMode mode)
    {

    }
    public void OnSceneLoaded3(Scene newScene, LoadSceneMode mode)
    {

    }

    public void OnEnable()
    {
        if (instance == null)
            instance = this;

        // keep track of global scene, assume entry point is global scene
        GlobalScene = SceneManager.GetActiveScene();    // because we start in global, it is active

        // we need to subscribe to scene loaded and  unloaded events, use delegates
        SceneManager.sceneLoaded += OnSceneLoaded;
        SceneManager.sceneLoaded += OnSceneLoaded3;
        SceneManager.sceneLoaded += OnSceneLoaded2;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        SceneManager.sceneLoaded -= OnSceneLoaded2;
        SceneManager.sceneLoaded -= OnSceneLoaded3;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
