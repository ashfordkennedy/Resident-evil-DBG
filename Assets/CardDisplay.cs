using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum DisplayOrientation {Row, Column, stacked, Grid, Radial}
public enum DisplayAlignment {Center,Left,Right}
public class CardDisplay : MonoBehaviour
{

    public DisplayOrientation displayOrientation = DisplayOrientation.Row;
    public DisplayAlignment displayOrigin = DisplayAlignment.Center;
    [SerializeField] Transform container;
    [SerializeField] float _cardWidth = 16f;
    [SerializeField] float _cardHeight = 22.5f;
    [SerializeField] float _cardDepth = 0.1f;

    [SerializeField] float _offset = 0.5f;

    [SerializeField] float _radialFill = 360;
    [SerializeField] int _columnWidth = 10;


    [SerializeField] float rotation = 0;
    [SerializeField] float _verticalOffset = 0f;

    [SerializeField] bool autoUpdate = false;
    [SerializeField]  bool _interactable = false;
   
    public bool interactable { get { return _interactable; } set { _interactable = value; SetInteractable(value); } }


    //Properties
    public float VerticalOffset { get { return _verticalOffset; } set { _verticalOffset = value; SetVerticalOffset(value); } }
    public float offset { get { return _offset; } set { _offset = value;} }
    public float cardDepth { get { return _cardDepth; } set { _cardDepth = value; } }
    public float cardHeight { get { return _cardHeight; } set { _cardHeight = value; } }
    public float cardWidth { get { return _cardWidth; } set { _cardWidth = value; } }
    public float radialFill { get { return _radialFill; } set { _radialFill = value; } }
    public int columnWidth { get { return _columnWidth; } set { _columnWidth = value; } }


    /// <summary>
    /// master method for setting and performing auto layout commands
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="CardWidth"></param>
    /// <param name="CardHeight"></param>
    /// <param name="CardDepth"></param>
    /// <param name="orientation"></param>
    /// <param name="RadialFill"></param>
    public void OrganiseCards(float Offset = 0.1f, float CardWidth = 1f, float CardHeight = 1f, float CardDepth = 0.1f, DisplayOrientation orientation = DisplayOrientation.Row, float RadialFill = 360)
    {

        switch (orientation)
        {
            case DisplayOrientation.Row:
                RowOrganise(Offset, CardWidth);
                break;

            case DisplayOrientation.Column:
                ColumnOrganise(Offset, CardHeight);
                break;

            case DisplayOrientation.stacked:
                StackOrganise(Offset, CardDepth);
                break;

            case DisplayOrientation.Radial:
                RadialOrganise(Offset, CardWidth, RadialFill);
                break;

            case DisplayOrientation.Grid:
                GridOrganise(Offset, CardWidth, CardHeight, columnWidth);
                break;

        }
        
    }

    /// <summary>
    /// Instant organiser for Radial layout
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="CardWidth"></param>
    /// <param name="RadialFill"></param>
    private void RadialOrganise(float Offset = 0.1f, float CardWidth = 1f, float RadialFill = 360)
    {
        float increment = (RadialFill / container.childCount);
        print(increment);
        Vector3 startPosition = container.position;
        

        Vector3 startRotation = container.rotation.eulerAngles;

        Vector3 incrementPosition = startPosition;
        incrementPosition.z += Offset;

        Vector3 incrementRotation = Vector3.zero;
        float incrementStep = 0;



       
        

        for (int i = 0; i < container.childCount; i++)
        {
            var x = Offset * Mathf.Cos(incrementStep * Mathf.Deg2Rad);
            var y = Offset * Mathf.Sin(incrementStep * Mathf.Deg2Rad);
            var newPosition = startPosition;
            newPosition.x += x;
            newPosition.z += y;

            container.GetChild(i).position = newPosition;
            incrementStep += increment;
            

        }
   

      
    }





    private float CalculateSize(float Offset, float Size, Vector3 StartPosition )
    {


        return 0;
    }


    /// <summary>
    /// Instant organiser for row layout
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="CardWidth"></param>
    private void RowOrganise(float Offset = 0.1f, float CardWidth = 1f)
    {
        float length = ((CardWidth + Offset) * container.childCount);

        Vector3 startPosition = container.position;
        float newStart = (length / 2 - ((CardWidth / 2) + (Offset / 2)));
        startPosition.x -= newStart;

        Vector3 incrementPosition = startPosition;

       

        for (int i = 0; i < container.childCount - 1; i++)
        {

            container.GetChild(i).position = incrementPosition;
            incrementPosition.x += CardWidth + Offset;

            //incrementPosition.x += CardWidth;
        }
        container.GetChild(container.childCount - 1).position = incrementPosition;

       
    }

    /// <summary>
    /// Instant organiser for column layout
    /// </summary>
    /// <param name="Offset"></param>
    /// <param name="CardHeight"></param>
    private void ColumnOrganise(float Offset = 0.1f, float CardHeight = 1f)
    {
        float length = ((CardHeight + offset) * container.childCount);
        print("length = " + length + " || child count = " + container.childCount);

        Vector3 startPosition = container.position;
        float newStart = (length / 2 - ((CardHeight / 2) + (Offset / 2)));
        startPosition.z -= newStart;

        Vector3 incrementPosition = startPosition;

      

        for (int i = 0; i < container.childCount - 1; i++)
        {

            container.GetChild(i).position = incrementPosition;
            incrementPosition.z += CardHeight + Offset;

            //incrementPosition.x += CardWidth;
        }
        container.GetChild(container.childCount - 1).position = incrementPosition;

    }

    private void StackOrganise(float Offset = 0.1f, float CardDepth = 1f)
    {
        float length = ((CardDepth + offset) * container.childCount);
        print("length = " + length + " || child count = " + container.childCount);

        Vector3 startPosition = container.position;
       // float newStart = (length / 2 - ((CardDepth / 2) + (Offset / 2)));
       // startPosition.y -= newStart;

        Vector3 incrementPosition = startPosition;

      

        for (int i = 0; i < container.childCount - 1; i++)
        {

            container.GetChild(i).position = incrementPosition;
            incrementPosition.y += CardDepth + Offset;

            //incrementPosition.x += CardWidth;
        }
        container.GetChild(container.childCount - 1).position = incrementPosition;

    }


    public void GridOrganise(float Offset = 0.1f, float CardWidth = 1f, float CardHeight = 1f, int ColumnMaxWidth = 10)
    {
        // not enough cards to make grid
        if(container.childCount < ColumnMaxWidth)
        {
            RowOrganise(Offset, CardWidth);
        }

        // need to perform grid spacing
        else
        {
            float length = ((CardWidth + offset) * ColumnMaxWidth);


           // calculate full columns and adds extra if only a fraction of a final column can be completed
           float requiredColumns = Mathf.Floor(container.childCount / ColumnMaxWidth);
            if(container.childCount % ColumnMaxWidth != 0)
            {
                requiredColumns ++;
            }

           List<Vector3> rowStarts = GenerateColumnPositions(CardHeight, Offset, (int)requiredColumns);

            print(rowStarts.Count + " is the amount of positions avaiable");
            // int requiredRows = container.childCount / ColumnMaxWidth;

            float height = ((CardHeight + offset) * container.childCount);
            Vector3 startPosition = container.position;

           // RowOrganise();

            startPosition.x = startPosition.x - (length / 2 - ((CardWidth / 2) + (Offset / 2)));
          //  float incrementSize = length / 
            float xIncrement = startPosition.x;
            float yIncrement = rowStarts[0].z;
            int columnIncrement = 0;
            float rowIncrement = 0;
           

            for (int i = 0; i < container.childCount; i++)
            {
                Transform card = container.GetChild(i);
                card.position = new Vector3(xIncrement, container.position.y, yIncrement);                
                xIncrement += (CardWidth + Offset);
                rowIncrement++;
                print(rowIncrement + " is the new increment " + i + " is the current card");
                if (rowIncrement == ColumnMaxWidth && i != container.childCount -1)
                {
                    xIncrement = startPosition.x;
                    columnIncrement++;
                    rowIncrement = 0;
                    yIncrement = rowStarts[columnIncrement].z;
                    print("yincrement increased");
                }
            }

        }

    }


    /// <summary>
    /// calls organise cards using the stored values of the display component
    /// </summary>
    public void UpdateLayout()
    {
        OrganiseCards(offset, _cardWidth, _cardHeight, _cardDepth, displayOrientation, radialFill);
    }




    private void OnValidate()
    {
        SetInteractable(interactable);
        if (autoUpdate == true) {
            OrganiseCards(offset, _cardWidth, _cardHeight, _cardDepth, displayOrientation, radialFill);
            RotateCards(rotation);

            
            if (displayOrientation != DisplayOrientation.stacked)
            {
                SetVerticalOffset(_verticalOffset);
            }
            
        }
        
    }

    private void RotateCards(float rotation)
    {
        for (int i = 0; i < container.childCount; i++)
        {
            Vector3 rot = container.GetChild(i).rotation.eulerAngles;
            rot.z = rotation;
            container.GetChild(i).rotation = Quaternion.Euler(rot);

            //incrementPosition.x += CardWidth;
        }
    }


    public void SetVerticalOffset(float VerticalOffset)
    {
        float tempOffset = 0f;
        for (int i = 0; i < container.childCount; i++)
        {
            Vector3 cardPosition = container.GetChild(i).position;
            cardPosition.y = (container.position.y + tempOffset);
            container.GetChild(i).position = cardPosition;
            tempOffset += VerticalOffset;

            //incrementPosition.x += CardWidth;
        }

    }


    public IEnumerator RepositionAnimation(float duration = 2f, float zRotation = 0)
    {
        List<Vector3> Positions = new List<Vector3>();
        switch (displayOrientation)
        {
            case DisplayOrientation.Row:
                Positions = GenerateRowPositions();
                break;

            case DisplayOrientation.Radial:
                Positions = GenerateRadialPositions();
                break;

            case DisplayOrientation.Column:
                Positions = GenerateColumnPositions();
                break;

            case DisplayOrientation.Grid:
                Positions = GenerateGridPositions();
                break;

        }


        float startTime = Time.time;
        float endTime = Time.time + duration;

        while (Time.time < endTime)
        {
            float pos = Mathf.InverseLerp(startTime, endTime, Time.time);
            for (int i = 0; i < container.childCount; i++)
            {
                Transform child = container.GetChild(i);

                child.position = Vector3.Slerp(child.position, Positions[i], pos);
                child.rotation = Quaternion.Euler(new Vector3(child.rotation.eulerAngles.x, child.rotation.eulerAngles.y, Mathf.Lerp(child.rotation.eulerAngles.z,zRotation,pos)));
            }
            yield return null;
        }





        yield return null;
    }





    #region Position Generators

    private List<Vector3> GenerateRowPositions()
    {
        List<Vector3> Positions = new List<Vector3>();

        float length = ((_cardWidth + offset) * container.childCount);

        Vector3 startPosition = container.position;
        float newStart = (length / 2 - ((_cardWidth / 2) + (offset / 2)));
        startPosition.x -= newStart;

        Vector3 incrementPosition = startPosition;

        for (int i = 0; i < container.childCount; i++)
        {
            Positions.Add(incrementPosition);
            incrementPosition.x += _cardWidth + offset;
        }
        return Positions;
    }

    private List<Vector3> GenerateColumnPositions()
    {
        List<Vector3> Positions = new List<Vector3>();

        float height = ((_cardHeight + offset) * container.childCount);

        Vector3 startPosition = container.position;
        float newStart = (height / 2 - ((_cardWidth / 2) + (offset / 2)));
        startPosition.z -= newStart;

        Vector3 incrementPosition = startPosition;

        for (int i = 0; i < container.childCount; i++)
        {
            Positions.Add(incrementPosition);
            incrementPosition.z += _cardWidth + offset;
        }
        return Positions;
    }



    private List<Vector3> GenerateRadialPositions()
    {
        List<Vector3> Positions = new List<Vector3>();

        float incrementSize = (_radialFill / container.childCount);

        Vector3 startPosition = container.position;       
        

        float angle = 0;
        Vector3 direction = angle * container.forward;

        Vector3 incrementPosition = startPosition;
            
        // generate the new point using the angle and offset and add to positions
        for (int i = 0; i < container.childCount; i++)
        {
            var x = offset * Mathf.Cos(angle * Mathf.Deg2Rad);
            var y = offset * Mathf.Sin(angle * Mathf.Deg2Rad);
            var newPosition = startPosition;
            newPosition.x += x;
            newPosition.z += y;
            Positions.Add(newPosition);
            angle += incrementSize;
            
        }
        return Positions;
    }


    private List<Vector3> GenerateGridPositions()
    {
        List<Vector3> Positions = new List<Vector3>();

        // not enough cards to make grid
        if (container.childCount < _columnWidth)
        {
             Positions = GenerateRowPositions();
        }

        // need to perform grid spacing
        else
        {
            float length = ((_cardWidth + offset) * _columnWidth);


            // calculate full columns and adds extra if only a fraction of a final column can be completed
            float requiredColumns = Mathf.Floor(container.childCount / _columnWidth);
            if (container.childCount % _columnWidth != 0)
            {
                requiredColumns++;
            }

            List<Vector3> rowStarts = GenerateColumnPositions(_cardHeight, _offset, (int)requiredColumns);

            print(rowStarts.Count + " is the amount of positions avaiable");


            Vector3 startPosition = container.position;


            startPosition.x = startPosition.x - (length / 2 - ((_cardWidth / 2) + (_offset / 2)));
            float xIncrement = startPosition.x;
            float yIncrement = rowStarts[0].z;
            int columnIncrement = 0;

            //how far along the row the loop is
            float rowIncrement = 0;


            for (int i = 0; i < container.childCount; i++)
            {
                //add new position
                Positions.Add(new Vector3(xIncrement, container.position.y, yIncrement));


                xIncrement += (_cardWidth + _offset);
                rowIncrement++;


                // Reset row increment and move down by one column to generate next positions
                if (rowIncrement == _columnWidth && i != container.childCount - 1)
                {
                    xIncrement = startPosition.x;
                    columnIncrement++;
                    rowIncrement = 0;
                    yIncrement = rowStarts[columnIncrement].z;
                }
            }

        }
        return Positions;
    }
    #endregion


    private List<Vector3> GenerateColumnPositions(float cardHeight, float offset, int cardCount)
    {
        List<Vector3> Positions = new List<Vector3>();

        float height = ((cardHeight + offset) * cardCount);

        Vector3 startPosition = container.position;
        float newStart = (height / 2 - ((cardHeight / 2) + (offset / 2)));
        startPosition.z += newStart;

        Vector3 incrementPosition = startPosition;

        for (int i = 0; i < cardCount; i++)
        {
            Positions.Add(incrementPosition);
            incrementPosition.z -= cardHeight + offset;
        }
        return Positions;
    }



    private List<Vector3> GenerateGridPositions(float Offset = 0.1f, float CardWidth = 1f, float CardHeight = 1f, int ColumnMaxWidth = 10)
    {
        List<Vector3> Positions = new List<Vector3>();

        // not enough cards to make grid
        if (container.childCount < ColumnMaxWidth)
        {
        // Positions = GenerateRowPositions(Offset, CardWidth);
        }

        // need to perform grid spacing
        else
        {
            float length = ((CardWidth + offset) * ColumnMaxWidth);


            // calculate full columns and adds extra if only a fraction of a final column can be completed
            float requiredColumns = Mathf.Floor(container.childCount / ColumnMaxWidth);
            if (container.childCount % ColumnMaxWidth != 0)
            {
                requiredColumns++;
            }

            List<Vector3> rowStarts = GenerateColumnPositions(CardHeight, Offset, (int)requiredColumns);

            print(rowStarts.Count + " is the amount of positions avaiable");


            Vector3 startPosition = container.position;


            startPosition.x = startPosition.x - (length / 2 - ((CardWidth / 2) + (Offset / 2)));
            float xIncrement = startPosition.x;
            float yIncrement = rowStarts[0].z;
            int columnIncrement = 0;

            //how far along the row the loop is
            float rowIncrement = 0;


            for (int i = 0; i < container.childCount; i++)
            {
                //add new position
                Positions.Add(new Vector3(xIncrement, container.position.y, yIncrement));


                xIncrement += (CardWidth + Offset);
                rowIncrement++;


                // Reset row increment and move down by one column to generate next positions
                if (rowIncrement == ColumnMaxWidth && i != container.childCount - 1)
                {
                    xIncrement = startPosition.x;
                    columnIncrement++;
                    rowIncrement = 0;
                    yIncrement = rowStarts[columnIncrement].z;
                }
            }

        }
        return Positions;
    }




    public void SetInteractable(bool interactable)
    {

        foreach (Transform card in this.transform){
            Mesh_Interactable iCard = null;
          if(card.TryGetComponent<Mesh_Interactable>(out iCard)){
                iCard.interactable = interactable;
            }
        }
    }








    // Start is called before the first frame update
    void Start()
    {
      //  UpdateLayout();
    }

    // Update is called once per frame
    void Update()
    {
       // OnValidate();
        if (Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(RepositionAnimation(2,rotation));
        }
    }
}
