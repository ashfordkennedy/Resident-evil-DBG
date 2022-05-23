using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardData") ]
public class CardData : ScriptableObject
{
    [SerializeReference]
    public List<CardClass> cardDatabase = new List<CardClass>();
    public Dictionary<string, int> cardDictionary = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[CustomEditor(typeof (CardData))]
public class CardDataEditor : Editor
{
    CardData Target;
   // SerializedProperty m_CardList;


    private void OnEnable()
    {
        //  m_CardList = serializedObject.FindProperty("cardDatabase");
        // EditorGUILayout.PropertyField(m_CardList);
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();





       

       
        Target = (CardData)target;

       

        EditorGUILayout.BeginHorizontal();
        GUI.color = Color.red;
        if (GUILayout.Button("Ammo"))
        {
            Target.cardDatabase.Add(new Card_Ammo());
        }
        GUI.color = Color.yellow;
        if (GUILayout.Button("Item"))
        {
            Target.cardDatabase.Add(new Card_Ammo());
        }
        if (GUILayout.Button("Ammo"))
        {
            Target.cardDatabase.Add(new Card_Ammo());
        }
        if (GUILayout.Button("Ammo"))
        {
            Target.cardDatabase.Add(new Card_Ammo());
        }



        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(Target);
    }

}





public enum CardType {Character, Ammo, Item, Weapon, Action, Token}
public enum EffectTrigger {none, Defeated, Undefeated , Appear}
public enum Effect {none, DamagePlayer, DamageAllPlayers, DamageSidePlayers, HealPlayer }

public class CardClass
{
    public string Identifier;
    public string name;
    public Material cardMaterial;
    

    public (bool istrue, string cuntname) testmethod()
    {
       
        return (true, "");

    }

    
    

}

public class Card_Ammo : CardClass
{
    public int Ammo = 30;
    public int Gold = 30;
}

public class Card_Item : CardClass
{

}

public class Card_Enemy : CardClass
{

    
}

public class Card_Action : CardClass
{
    
}

public class Card_Weapon : CardClass
{


}


