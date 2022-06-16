using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    private bool loadScene;
    [SerializeField] Image _loadingBar;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space)&& loadScene == false)
        {
            loadScene = true;

            StartCoroutine(LoadNextLevel());
        }
        
    }

    IEnumerator LoadNextLevel()
    {
        AsyncOperation loadLevel = SceneManager.LoadSceneAsync("Level-1");
        
        while (!loadLevel.isDone)
        {
            _loadingBar.fillAmount = Mathf.Clamp01(loadLevel.progress / 1f);
            yield return null;
        }
    }

    
}
