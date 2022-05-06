using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour
{
    private void Start()
    {
        SceneManager.LoadScene("SceneSettings", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneAudio", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneUI", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneGamePlay", LoadSceneMode.Additive);
        SceneManager.LoadScene("SceneEnviroment", LoadSceneMode.Additive);
    }
}
