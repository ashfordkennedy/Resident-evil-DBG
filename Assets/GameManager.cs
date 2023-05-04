using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Player> players = new List<Player>();
    public int CurrentActivePlayer = 0;
    public CardData cardData = null;
    private void Awake()
    {
        GenerateCardMaterials();

    }


    public void GenerateCardMaterials()
    {
        cardData.GenerateCardMaterials();
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //OnCompleteTurn();
    }

    /// <summary>
    /// Publicly called when the current active player reports the end of their turn
    /// </summary>
    public void OnCompleteTurn()
    {
        CurrentActivePlayer++;
        if(CurrentActivePlayer >= players.Count)
        {
            CurrentActivePlayer = 0;
        }

    }
}


[System.Serializable]
public class Player
{
    public string playerName = "";
    public PlayerArea playerArea = null;


    public Player(string playerName, PlayerArea playerArea)
    {
        this.playerName = playerName;
        this.playerArea = playerArea;
    }
}
