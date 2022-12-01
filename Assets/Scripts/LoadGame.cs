using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

public class LoadGame : MonoBehaviour
{
    public string SceneName;
    public TMPro.TMP_InputField playerName;

    private void Start()
    {

        GetComponent<Button>().interactable = false;

        playerName.text = PlayerPrefs.GetString("playerName");
    }

    private void Update()
    {
        if (playerName.text.Length == 3)
        {
            GetComponent<Button>().interactable = true;
        }
        else
        {
            GetComponent<Button>().interactable = false;
        }
    }

    public void LoadTargetScene()
    {
        SaveName();
        SceneManager.LoadScene(SceneName);
    }

    private void SaveName()
    {
        PlayerPrefs.SetString("playerName", playerName.text);
    }

}
