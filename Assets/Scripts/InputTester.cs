using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class InputTester : MonoBehaviour
{

    public Text N64Text;
    public Text N64ZText;
    public Text PS3LStickText;
    public Text PS3RStickText;
    public Text TriggerText;

    public void UpdateTest(string n64, string n64z, string ps3lstick, string ps3rstick, string trigger)
    {
        N64Text.text = n64;
        N64ZText.text = n64z;
        PS3LStickText.text = ps3lstick;
        PS3RStickText.text = ps3rstick;
        TriggerText.text = trigger;
    }
    

}
