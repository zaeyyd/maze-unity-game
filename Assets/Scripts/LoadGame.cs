using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;

//TODO: what is a namespace?
// namespace KartGame.UI

    public class LoadGame : MonoBehaviour
    {
        public string SceneName;
        public TMPro.TMP_InputField playerName;

        private void Start() {
            print("STARTED");


            GetComponent<Button>().interactable = false;

            playerName.text = PlayerPrefs.GetString("playerName");

            getHighScores();


            // // load data from player prefs
            // public string = "one:1,two:2,three:3"



            // var scores = new Dictionary<string, int>();
            // scores.Add("one", 1);
            // scores.Add("two", 2);
            // scores.Add("three", 3);

            // print(scores);

            // var scoreList = new List<KeyValuePair<string, int>>();
            // foreach (var pair in scores)
            // {
            //     print(pair);
            // }


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
            SaveName();
            SceneManager.LoadSceneAsync(SceneName);
        }

        private void SaveName()
        {
            PlayerPrefs.SetString("playerName", playerName.text);
        }

        
            // ops

            // add highscore for player
                // read string
                // convert to hashmap
                // set larger value for score
                // convert hashmap back to string
                // store string
            // diplay top 10
                // read string
                // convert to hashmap
                // convert to list
                // sort list
                // render top 10


        public string readHighScores()
        {
            //print(PlayerPrefs.GetString("highscores"))
            return "one:1,two:2,three:3";
        }

        public Dictionary<string, int> getHighScores()
        {
            string highscoresString = readHighScores();
            var highscores = new Dictionary<string, int>();

            foreach (string playerString in highscoresString.Split(","))
            {
                print(playerString);
                var list = playerString.Split(":");

                highscores[list[0]] = int.Parse(list[1]);
                
            }

            foreach (var item in highscores)
            {
                print(item.Key);
                print(item.Value);
            }

            return highscores;
        }

        
    }
