using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector3 m_InputVector;

    public Vector3 InputVector => m_InputVector;

    public MobileInput mobileInput;
    public PcInput pcInput;

    public bool isjumping { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        m_InputVector = new Vector3();
    }

    // Update is called once per frame
    void Update()
    {
        if (pcInput.IsJumping || mobileInput.IsJumping)
        {
            isjumping = true;
        }
        else
        {
            isjumping = false;
        }

        if (pcInput.HorizontalValue != 0 && !isjumping)
        {
            m_InputVector = new Vector3(pcInput.HorizontalValue, 0, 0);
        }
        else if (mobileInput.HorizontalValue != 0 && !isjumping)
        {
            m_InputVector = new Vector3(mobileInput.HorizontalValue, 0, 0);
        }
        else
        {
            m_InputVector = Vector3.zero;
        }

       
    }
}
