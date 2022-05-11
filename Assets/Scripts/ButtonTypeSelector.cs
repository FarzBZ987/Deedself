using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTypeSelector : MonoBehaviour
{

    public enum ButtonType
    {
        GOOD, NEUTRAL, BAD
    }

    [SerializeField] private ButtonType buttonType;

    private string checkButtonType()
    {
        if(buttonType == ButtonType.GOOD)
        {
            return "good";
        }else if (buttonType == ButtonType.NEUTRAL)
        {
            return "neutral";
        }else if (buttonType == ButtonType.BAD)
        {
            return "bad";
        }
        return null;
    }

    public void buttonAction()
    {
        GameManager.instance.selectedChoiceButton(checkButtonType());
    }
    
}
