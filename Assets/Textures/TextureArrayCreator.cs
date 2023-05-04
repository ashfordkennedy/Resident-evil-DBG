using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureArrayCreator : MonoBehaviour
{

    public List<Texture2D> textures;
    public Texture2DArray texture2DArray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Texture2DArray GenerateTexture2DArray()
    {
        for (int i = 0; i < textures.Count; i++)
        {
          //  texture2DArray.add
        }



        return texture2DArray;
    }
}
