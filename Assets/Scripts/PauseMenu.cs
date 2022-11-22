using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    [Tooltip("Root GameObject of the menu used to toggle its activation")]
    public GameObject menuRoot;

    [Tooltip("Master volume when menu is open")]
    [Range(0.001f, 1f)]
    public float volumeWhenMenuOpen = 0.5f;


    void Start()
    {
        menuRoot.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown("escape"))
        {
            SetPauseMenuActivation(!menuRoot.activeSelf);
        }
    }

    // public void ClosePauseMenu()
    // {
    //     SetPauseMenuActivation(false);
    // }

    // public void TogglePauseMenu()
    // {
    //     SetPauseMenuActivation(!menuRoot.activeSelf);
    // }

    void SetPauseMenuActivation(bool active)
    {
        menuRoot.SetActive(active);

        // if (menuRoot.activeSelf)
        // {
        //     Time.timeScale = 0f;
        //     AudioUtility.SetMasterVolume(volumeWhenMenuOpen);

        //     EventSystem.current.SetSelectedGameObject(null);
        // }
        // else
        // {
        //  //   Cursor.lockState = CursorLockMode.Locked;
        //  //   Cursor.visible = false;
        //     Time.timeScale = 1f;
        //     AudioUtility.SetMasterVolume(1);
        // }

    }

    // void OnShadowsChanged(bool newValue)
    // {
    //     QualitySettings.shadows = newValue ? ShadowQuality.All : ShadowQuality.Disable;
    // }

    // void OnFramerateCounterChanged(bool newValue)
    // {
    //     m_FramerateCounter.uiText.gameObject.SetActive(newValue);
    // }

    // public void OnShowControlButtonClicked(bool show)
    // {
    //     controlImage.SetActive(show);
    // }
}
