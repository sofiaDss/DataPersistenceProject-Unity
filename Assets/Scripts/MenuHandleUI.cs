using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[DefaultExecutionOrder(1000)]
public class MenuHandleUI : MonoBehaviour
{
    public TMP_Text titleScore;
    public TMP_InputField inputName;

    void Start()
    {
        if (UserExperience.Instance.bestUserScore != 0)
        {
            titleScore.text = $"Best Score: {UserExperience.Instance.bestUserName}: {UserExperience.Instance.bestUserScore}";
        }
    }

    public void StartNew()
    {
        if (inputName.text != "")
        {
            SceneManager.LoadScene(1);
            UserExperience.Instance.userName = inputName.text;
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
    }
}
