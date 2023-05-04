using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Base_Card : MonoBehaviour
{
    public string identifier = "";
    //[SerializeField] Sprite _portrait = null;
    //[SerializeField] internal TMP_Text _type = null;
    [SerializeField] internal TMP_Text _name = null;
    [SerializeField]internal TMP_Text[] _iconText = null;
    [SerializeField] internal Renderer _renderer = null;



    public void SetCard(CardClass cardData)
    {
        identifier = cardData.Identifier;
        _name.text = cardData.name;
       // _type.text = "" + cardData.cardType;

       var materials = _renderer.sharedMaterials;
        materials[0] = cardData.material;
        _renderer.materials = materials;

    }





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
