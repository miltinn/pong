using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HiscoreManager : MonoBehaviour
{
    public static HiscoreManager Instance;

    private string _keyPlayer = "keyHiscore";

    [Header("References")]
    public TextMeshProUGUI uiTextHiscore;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        UpdateText();
    }

    private void OnEnable()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        uiTextHiscore.text = $"{PlayerPrefs.GetString(_keyPlayer, "No Hiscore")} Wins: {PlayerPrefs.GetInt("Wins", 0)}";

    }

    public void SaveWinner(Player p)
    {
        if (p.playerName == "") return;
        if (p.wins > PlayerPrefs.GetInt("Wins", 0))
        {
            PlayerPrefs.SetString(_keyPlayer, p.playerName);
            PlayerPrefs.SetInt("Wins", p.wins);
        }
        UpdateText();
    }
}
