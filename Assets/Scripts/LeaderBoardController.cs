using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    string topTopString;
    public TextMeshProUGUI leaderboardString;
    void Start()
    {
        topTopString = getTopString(getTop(getHighScores()));
        if (leaderboardString != null)
        {
            leaderboardString.text = topTopString;
        }

    }

    public void saveScore(int score, string name)
    {
        Dictionary<string, int> highScores = getHighScores();

        if (highScores.ContainsKey(name))
        {
            highScores[name] = Mathf.Min(highScores[name], score);
        }
        else
        {
            highScores[name] = score;
        }

        scoreDictionaryToString(highScores);

    }

    public string readHighScores()
    {
        return PlayerPrefs.GetString("highscores");
    }

    public void scoreDictionaryToString(Dictionary<string, int> scoreDictionary)
    {
        string scoreDictionaryString = "";

        foreach (var item in scoreDictionary)
        {
            scoreDictionaryString = scoreDictionaryString + item.Key + ":" + item.Value.ToString() + ",";
        }

        PlayerPrefs.SetString("highscores", scoreDictionaryString);
    }
    public Dictionary<string, int> getHighScores()
    {
        string highscoresString = readHighScores();
        var highscores = new Dictionary<string, int>();

        foreach (string playerString in highscoresString.Split(","))
        {
            print(playerString);
            if (playerString != "")
            {
                var list = playerString.Split(":");

                highscores[list[0]] = int.Parse(list[1]);
            }


        }

        return highscores;
    }

    public List<KeyValuePair<string, int>> getTop(Dictionary<string, int> highscores)
    {
        var all = new List<KeyValuePair<string, int>>();

        foreach (var item in highscores)
        {
            all.Add(item);
        }

        all.Sort((x, y) => (y.Value.CompareTo(x.Value)));

        return all;

    }

    public string getTopString(List<KeyValuePair<string, int>> topList)
    {
        string top = "NAME: SCORE\n\n";

        for (int i = topList.Count - 1; i >= 0; i--)
        {

            string name = topList[i].Key.ToString();
            string score = topList[i].Value.ToString();
            top = top + name + ": " + score + "\n";
        }

        return top;
    }
}
