using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Pawn
{
    private List<Vector3> _aroundVectors = new List<Vector3>()
    {
        Vector3.forward, Vector3.left, Vector3.right, Vector3.back
    };

    private string _black = "Black";
    private string _white = "White";
    
    public override bool[,] PossibleMoves()
    {
        bool[,] r = new bool[9, 9];

        RaycastHit hit;


        if (1 > 2)
        {
            if (isWhite)
        {
            for (int i = 0; i < _aroundVectors.Count; i++)
            {
                //If there is no obstacles at this way
                if (!Physics.Raycast(GameObject.FindWithTag(_white).transform.position, _aroundVectors[i], out hit, 1.25f))
                {
                    Move(CurrentX + (int)_aroundVectors[i].x, CurrentY + (int)_aroundVectors[i].z, ref r); // Up
                }
                //If there is an obstacle
                else if (hit.collider.tag.Equals(_black))
                {
                    //if there is no obstacle at this way (with the origin point is the obstacle itself)
                    if (!Physics.Raycast(GameObject.FindWithTag(_black).transform.position, _aroundVectors[i], 1.25f))
                        Move(CurrentX + (int)(_aroundVectors[i].x * 2), CurrentY + (int)(_aroundVectors[i].z * 2), ref r); // Up 2
                    
                    else
                    {
                        Vector3 temp = new Vector3(_aroundVectors[i].z, 0, _aroundVectors[i].x);
                        Vector3 temp2 = new Vector3(-_aroundVectors[i].z, 0, -_aroundVectors[i].x);
                        
                        
                        if (!Physics.Raycast(GameObject.FindWithTag(_black).transform.position, Vector3.right, 1.25f))
                            Move(CurrentX + (int)temp.x, CurrentY + (int)_aroundVectors[i].z, ref r); // Go Right
                        if (!Physics.Raycast(GameObject.FindWithTag(_black).transform.position, Vector3.left, 1.25f))
                            Move(CurrentX + (int)temp2.x, CurrentY + (int)_aroundVectors[i].z, ref r); // Go Left
                    }
                }
            }
        }
        else
        {
            for (int i = 0; i < _aroundVectors.Count; i++)
            {
                //If there is no obstacles at this way
                if (!Physics.Raycast(GameObject.FindWithTag(_black).transform.position, _aroundVectors[i], out hit, 1.25f))
                {
                    Move(CurrentX + (int)_aroundVectors[i].x, CurrentY + (int)_aroundVectors[i].z, ref r); // Up
                }
                //If there is an obstacle
                else if (hit.collider.tag.Equals(_white))
                {
                    //if there is no obstacle at this way (with the origin point is the obstacle itself)
                    if (!Physics.Raycast(GameObject.FindWithTag(_white).transform.position, _aroundVectors[i], 1.25f))
                        Move(CurrentX + (int)(_aroundVectors[i].x * 2), CurrentY + (int)(_aroundVectors[i].z * 2), ref r); // Up 2
                    
                    else
                    {
                        Vector3 temp = new Vector3(_aroundVectors[i].z, 0, _aroundVectors[i].x);
                        Vector3 temp2 = new Vector3(-_aroundVectors[i].z, 0, -_aroundVectors[i].x);
                        
                        
                        if (!Physics.Raycast(GameObject.FindWithTag(_white).transform.position, Vector3.right, 1.25f))
                            Move(CurrentX + (int)temp.x, CurrentY + (int)_aroundVectors[i].z, ref r); // Go Right
                        if (!Physics.Raycast(GameObject.FindWithTag(_white).transform.position, Vector3.left, 1.25f))
                            Move(CurrentX + (int)temp2.x, CurrentY + (int)_aroundVectors[i].z, ref r); // Go Left
                    }
                }
            }
        }
        }
        
        
         
         
        if (isWhite)
        {
            //Check the block in front of the white
            if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.forward, out hit, 1.25f))
                Move(CurrentX, CurrentY + 1, ref r); // Up
            else if (hit.collider.tag.Equals("Black"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.forward, 1.25f))
                    Move(CurrentX, CurrentY + 2, ref r); // Up 2

                else 
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.right, 1.25f))
                        Move(CurrentX + 1, CurrentY + 1, ref r); // Go Right
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.left, 1.25f))
                        Move(CurrentX - 1, CurrentY + 1, ref r); // Go Left
                }
            }

            //Check the block behind the white
            if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.back, out hit, 1.25f))
                Move(CurrentX, CurrentY - 1, ref r); // Down
            else if (hit.collider.tag.Equals("Black"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.back, 1.25f))
                    Move(CurrentX, CurrentY - 2, ref r); // Down 2
                else 
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.right, 1.25f))
                        Move(CurrentX + 1, CurrentY - 1, ref r); // Go Right
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.left, 1.25f))
                        Move(CurrentX - 1, CurrentY - 1, ref r); // Go Left
                }
            }
            
            //Check the block in the right of the white
            if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.right, out hit, 1.25f))
                Move(CurrentX + 1, CurrentY, ref r); // Right
            else if (hit.collider.tag.Equals("Black"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.right, 1.25f))
                    Move(CurrentX + 2, CurrentY, ref r); // Right 2
                else 
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.forward, 1.25f))
                        Move(CurrentX + 1, CurrentY + 1, ref r); // Go Up
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.back, 1.25f))
                        Move(CurrentX + 1, CurrentY - 1, ref r); // Go Down
                }
            }

            //Check the block in the left of the white
            if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.left, out hit, 1.25f))
                Move(CurrentX - 1, CurrentY, ref r); // Left
            else if (hit.collider.tag.Equals("Black"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.left, 1.25f))
                    Move(CurrentX - 2, CurrentY, ref r); // Left 2
                else 
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.forward, 1.25f))
                        Move(CurrentX - 1, CurrentY + 1, ref r); // Go Up
                    if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.back, 1.25f))
                        Move(CurrentX - 1, CurrentY - 1, ref r); // Go Down
                }
            }
        }

        else
        {
            if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.forward, out hit, 1.25f))
                Move(CurrentX, CurrentY + 1, ref r); // Up
            else if (hit.collider.tag.Equals("White"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.forward, 1.25f))
                    Move(CurrentX, CurrentY + 2, ref r); // Up 2

                else
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.right, 1.25f))
                        Move(CurrentX + 1, CurrentY + 1, ref r); // Go Right
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.left, 1.25f))
                        Move(CurrentX - 1, CurrentY + 1, ref r); // Go Left
                }
            }

            if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.back, out hit, 1.25f))
                Move(CurrentX, CurrentY - 1, ref r); // Down
            else if (hit.collider.tag.Equals("White"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.back, 1.25f))
                    Move(CurrentX, CurrentY - 2, ref r); // Down 2
                else
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.right, 1.25f))
                        Move(CurrentX + 1, CurrentY - 1, ref r); // Go Right
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.left, 1.25f))
                        Move(CurrentX - 1, CurrentY - 1, ref r); // Go Left
                }
            }
            if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.right, out hit, 1.25f))
                Move(CurrentX + 1, CurrentY, ref r); // Right
            else if (hit.collider.tag.Equals("White"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.right, 1.25f))
                    Move(CurrentX + 2, CurrentY, ref r); // Right 2
                else
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.forward, 1.25f))
                        Move(CurrentX + 1, CurrentY + 1, ref r); // Go Up
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.back, 1.25f))
                        Move(CurrentX + 1, CurrentY - 1, ref r); // Go Down
                }
            }

            if (!Physics.Raycast(GameObject.FindWithTag("Black").transform.position, Vector3.left, out hit, 1.25f))
                Move(CurrentX - 1, CurrentY, ref r); // Left
            else if (hit.collider.tag.Equals("White"))
            {
                if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.left, 1.25f))
                    Move(CurrentX - 2, CurrentY, ref r); // Left 2
                else
                {
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.forward, 1.25f))
                        Move(CurrentX - 1, CurrentY + 1, ref r); // Go Up
                    if (!Physics.Raycast(GameObject.FindWithTag("White").transform.position, Vector3.back, 1.25f))
                        Move(CurrentX - 1, CurrentY - 1, ref r); // Go Down
                }
            }
        }
        

        return r;
    }
}