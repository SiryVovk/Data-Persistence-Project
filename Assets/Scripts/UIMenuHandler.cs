using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIMenuHandler : MonoBehaviour
{
    public InputField Field;

    private void Start()
    {
        Field.text = GameMange.Instant.name;
    }
    public void OnPlay()
    {
        SceneManager.LoadScene(1);
    }

    public void OnExit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif

    }

    public void AddName(string name)
    {
        GameMange.Instant.name = Field.text;
        GameMange.Instant.Save();
    }
}
