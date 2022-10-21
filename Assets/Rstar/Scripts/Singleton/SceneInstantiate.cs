using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// �O�o�� Managers scene �[�� Build Settings �� Scenes ��
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
