using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//TODO: what is a namespace?
// namespace KartGame.UI

    public class LoadGame : MonoBehaviour
    {
        public string SceneName;
        public TMPro.TMP_InputField playerName;

        private void Start() {
            print("STARTED");

            GetComponent<Button>().interactable = false;
        }

        private void Update() {
            if (playerName.text.Length >= 3)
            {
                print(playerName.text);
                GetComponent<Button>().interactable = true;
            } 
            else
            {
                GetComponent<Button>().interactable = false;
            }


        }


        public void LoadTargetScene() 
        {
            SceneManager.LoadSceneAsync(SceneName);
        }

        
    }
