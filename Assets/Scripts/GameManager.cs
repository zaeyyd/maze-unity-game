using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI playeNameText;
    void Start()
    {
        playeNameText.text = PlayerPrefs.GetString("playerName");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
