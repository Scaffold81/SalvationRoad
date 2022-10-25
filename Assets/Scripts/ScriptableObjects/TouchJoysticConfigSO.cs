using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TouchJoysticConfig", menuName = "CostomScriptableObjects/TouchJoysticConfigSO")]
public class TouchJoysticConfigSO : ScriptableObject
{
    public float joystick_radius;
    public float joystic_blindspot_zone_vertical;
    public float joystic_blindspot_zone_horisontal;
    public float joystic_screen_border_value;
    internal RectTransform joystick;
    internal RectTransform joystickStick;
}
