using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 記得把 Managers scene 加到 Build Settings 的 Scenes 裡
/// </summary>
public class SceneInstantiate : MonoBehaviour
{
    [SerializeField]
    private Object persistentScene;

    private void Awake()
    {
        SceneManager.LoadSceneAsync(persistentScene.name, LoadSceneMode.Additive);
    }

    [ContextMenu("ChangeScene")]
    public void NextScene()
    {
        SceneManager.UnloadSceneAsync("FirstScene");
        SceneManager.LoadSceneAsync("SecondScene", LoadSceneMode.Additive);
    }
}
