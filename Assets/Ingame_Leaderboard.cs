using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Ingame_Leaderboard : MonoBehaviour
{
    [SerializeField]private TMP_Text _playerName;
    [SerializeField] private TMP_Text _stats;
    [SerializeField] private Image _playerIcon;
   

    public void SetValues(string playerName, int decorations, int health, Sprite icon)
    {
        _playerName.text = playerName;


    }
}
