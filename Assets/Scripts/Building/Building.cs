using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public float Length { get; private set; }
    [SerializeField]
    private Transform _mainParent;

    private void Awake()
    {
        Length = CalculateLength();

    }


    private float CalculateLength()
    {
        float width = 0f;
        foreach (Renderer childRenderer in _mainParent.GetComponentsInChildren<Renderer>())
        {
            width += childRenderer.bounds.size.x;
        }
        //for (int i = 0; i < _mainParent.childCount; i++)
        //{
        //    Renderer r = _mainParent.GetChild(i).GetComponent<Renderer>();
        //    if(r !=null)
        //        width += r.bounds.size.x;
        //}
        return width/2;
    }
}
