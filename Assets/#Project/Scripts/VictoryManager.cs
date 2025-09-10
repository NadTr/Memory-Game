using System.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;


public class VictoryManager : MonoBehaviour
{
    [SerializeField] private float delayBeforeLoadingScene = 2f;
    private string sceneName;

    public void Initialize(string sceneName)
    {
        this.sceneName = sceneName.Trim();
    }
    
    public void LaunchVictory()
    {
        StartCoroutine(CO_LaunchVictory());
    }

    private IEnumerator CO_LaunchVictory()
    {
        yield return new WaitForSeconds(delayBeforeLoadingScene);
        SceneManager.LoadScene(sceneName);


    }
}
