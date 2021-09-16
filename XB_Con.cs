/*********************************************************************************************************
 * Author: George Lecakes
 * Purpose:
 * -Create a consistent mapping of XBOX controller input in CAVE systems.
 * -Provide a method of mapping controller axis to button presses instead of using Axes.
 * Created: 7/29/2021
 * ********************************************************************************************************
 * Updates:
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XB_Con
{
    [SerializeField]
    [Tooltip("The threshold for an axis to register like a button (between 0 and 1)")]
    [Range(0.0f, 1.0f)]
    float axisThreshold = 0.1f;

    //Buttons
    public const string XB1_A = "XB1_A";
    public const string XB1_B = "XB1_B";
    public const string XB1_X = "XB1_X";
    public const string XB1_Y = "XB1_Y";
    public const string XB1_L_Bumper = "XB1_L_Bumper";
    public const string XB1_R_Bumber = "XB1_R_Bumber";
    public const string XB1_L_Stick = "XB1_L_Stick";
    public const string XB1_R_Stick = "XB1_R_Stick";
    public const string XB1_View = "XB1_View";
    public const string XB1_Menu = "XB1_Menu";
    //Axes
    public const string XB1_L_Horizontal = "XB1_L_Horizontal";
    public const string XB1_L_Vertical = "XB1_L_Vertical";
    public const string XB1_R_Horizontal = "XB1_R_Horionztal";
    public const string XB1_R_Vertical = "XB1_R_Vertical";
    public const string XB1_D_Horizontal = "XB1_D_Horizontal";
    public const string XB1_D_Vertical = "XB1_D_Vertical";
    public const string XB1_L_Trigger = "XB1_L_Trigger";
    public const string XB1_R_Trigger = "XB1_R_Trigger";

    //Iterates over the axes and checks for large changes in values to convert over to 'down presses'

    public enum Axes
    {
        L_Up = 0,
        L_Down = 1,
        L_Left = 2,
        L_Right = 3,
        R_Up = 4, 
        R_Down = 5, 
        R_Left = 6,
        R_Right = 7,
        D_Up = 8,
        D_Down = 9,
        D_Left = 10,
        D_Right = 11,
        L_Trigger = 12,
        R_Trigger = 13
	}

    bool[] axesDown = new bool[14]{ false, false,
                                    false, false,
                                    false, false,
                                    false, false,
                                    false, false,
                                    false, false,
                                    false, false};
	//Stores the previous axesDown state to allow for determining when an axes up event occurs										
	bool[] prevState = new bool[14]{false, false,
									false, false,
									false, false,
									false, false,
									false, false,
									false, false,
									false, false};

	//Occurs when a button is released, once
    bool[] axesUp = new bool[14]{ 	false, false,
									false, false,
									false, false,
									false, false,
									false, false,
									false, false,
									false, false};



	/*
	*Takes the currently queried values and checks them against the current values 
	*to determine if an Up Event has occured. 
	*Also applys them the current states to the previous state array for the next update.
	*/
	
	public void StoreStates()
	{
		for(int i = 0; i < axesDown.Length; i++)
		{
			//If we were previously down but have now released, we have an axes up event
			if(prevState[i] && !axesDown[i])
			{
				axesUp[i] = true;
			}
			
			prevState[i] = axesDown[i];
		}
	}

	public void Update()
	{
		CheckAxes();
		StoreStates();
	}

    public void CheckAxes()
    {

        //Left Stick 
        if(getReal3D.Input.GetAxis(XB_Con.XB1_L_Vertical) > axisThreshold)
        {
            axesDown[(int)Axes.L_Up] = true;
        }
        else
        {
            axesDown[(int)Axes.L_Up] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_L_Vertical) < -axisThreshold)
        {
            axesDown[(int)Axes.L_Down] = true;
        }
        else
        {
            axesDown[(int)Axes.L_Down] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_L_Horizontal) < -axisThreshold)
        {
            axesDown[(int)Axes.L_Left] = true;
        }
        else
        {
            axesDown[(int)Axes.L_Left] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_L_Horizontal) > axisThreshold)
        {
            axesDown[(int)Axes.L_Right] = true;
        }
        else
        {
            axesDown[(int)Axes.L_Right] = false;
        }

        //Right Stick

        if (getReal3D.Input.GetAxis(XB_Con.XB1_R_Vertical) > axisThreshold)
        {
            axesDown[(int)Axes.R_Up] = true;
        }
        else
        {
            axesDown[(int)Axes.R_Up] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_R_Vertical) < -axisThreshold)
        {
            axesDown[(int)Axes.R_Down] = true;
        }
        else
        {
            axesDown[(int)Axes.R_Down] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_R_Horizontal) < -axisThreshold)
        {
            axesDown[(int)Axes.R_Left] = true;
        }
        else
        {
            axesDown[(int)Axes.R_Left] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_R_Horizontal) > axisThreshold)
        {
            axesDown[(int)Axes.R_Right] = true;
        }
        else
        {
            axesDown[(int)Axes.R_Right] = false;
        }

        //D Pad
        if (getReal3D.Input.GetAxis(XB_Con.XB1_D_Vertical) > axisThreshold)
        {
            axesDown[(int)Axes.D_Up] = true;
        }
        else
        {
            axesDown[(int)Axes.D_Up] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_D_Vertical) < -axisThreshold)
        {
            axesDown[(int)Axes.D_Down] = true;
        }
        else
        {
            axesDown[(int)Axes.D_Down] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_D_Horizontal) < -axisThreshold)
        {
            axesDown[(int)Axes.D_Left] = true;
        }
        else
        {
            axesDown[(int)Axes.D_Left] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_D_Horizontal) > axisThreshold)
        {
            axesDown[(int)Axes.D_Right] = true;
        }
        else
        {
            axesDown[(int)Axes.D_Right] = false;
        }

        //Triggers
        if (getReal3D.Input.GetAxis(XB_Con.XB1_L_Trigger) > axisThreshold)
        {
            axesDown[(int)Axes.L_Trigger] = true;
        }
        else
        {
            axesDown[(int)Axes.L_Trigger] = false;
        }

        if (getReal3D.Input.GetAxis(XB_Con.XB1_R_Trigger) > axisThreshold)
        {
            axesDown[(int)Axes.R_Trigger] = true;
        }
        else
        {
            axesDown[(int)Axes.R_Trigger] = false;
        }
    }

    public bool GetAxisDown(Axes axis)
    {
        return axesDown[(int)axis];
    }
	
	public bool GetAxisUp(Axes axis)
	{
		return axesUp[(int)axis];
	}

}
