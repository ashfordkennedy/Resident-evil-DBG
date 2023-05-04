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

    [SerializeField]Material enemyMaterial = null;
    [SerializeField] Material characterMaterial = null;
    public void GenerateCardMaterials()
    {
        for (int i = 0; i < cardDatabase.Count; i++)
        {
            Material material = null;
            switch (cardDatabase[i].cardType)
            {
                case CardType.Enemy:
                    material = enemyMaterial;
                    break;

                case CardType.Character:
                    material = characterMaterial;
                    break;

            }


            cardDatabase[i].GenerateMaterial(material);
        }
    }
}

#if UNITY_EDITOR
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
        Target = (CardData)target;
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        GUI.color = Color.red;
        if (GUILayout.Button("Ammo"))
        {
            Target.cardDatabase.Add(new Card_Ammo());
        }
        GUI.color = Color.yellow;
        if (GUILayout.Button("Item"))
        {
            Target.cardDatabase.Add(new Card_Item());
        }
        GUI.color = Color.cyan;
        if (GUILayout.Button("Weapon"))
        {
            Target.cardDatabase.Add(new Card_Weapon());
        }
        GUI.color = Color.green;
        if (GUILayout.Button("Enemy"))
        {
            Target.cardDatabase.Add(new Card_Enemy());
        }



        EditorGUILayout.EndHorizontal();

        serializedObject.ApplyModifiedProperties();
        EditorUtility.SetDirty(Target);
    }

}
#endif




public enum CardType {Character, Ammo, Item, Weapon, Action, Token, Enemy}
public enum EffectTrigger {none, Defeated, Undefeated , Appear}
public enum Effect {none, DamagePlayer, DamageAllPlayers, DamageSidePlayers, HealPlayer }

[System.Serializable]
public class CardClass
{
    public string Identifier;
    public string name;
    public CardType cardType = CardType.Weapon;
       
    public Material material;
    public Texture2D portrait;
    public int BackgroundID;


    public (bool istrue, string cuntname) testmethod()
    {
       
        return (true, "");

    } 
    
    public void GenerateMaterial(Material baseMaterial)
    {

        var newMaterial = new Material(baseMaterial);
        newMaterial.SetTexture("Portrait", this.portrait);

        this.material = newMaterial;
    }
}

public class Card_Ammo : CardClass
{
    public int Ammo = 30;
    public int Gold = 30;


    public Card_Ammo()
    {
        this.cardType = CardType.Ammo;
    }

    public Card_Ammo(int ammo, int gold)
    {
        this.Ammo = ammo;
        this.Gold = gold;
        this.cardType = CardType.Ammo;
    }

}

public class Card_Item : CardClass
{

    public Card_Item()
    {
        this.cardType = CardType.Item;
    }
}

public class Card_Enemy : CardClass
{

    public Effect effect = Effect.none;
    public string effectText = "";
    public int damage = 0;
    public int health = 1;
    public int decorations = 1;

    public Card_Enemy()
    {
        this.cardType = CardType.Enemy;
    }

    public Card_Enemy(Effect effect, string effectText, int damage, int health, int decorations)
    {
        this.effect = effect;
        this.effectText = effectText;
        this.damage = damage;
        this.health = health;
        this.decorations = decorations;
    }
    
}

public class Card_Action : CardClass
{
    
}

public class Card_Weapon : CardClass
{


}


