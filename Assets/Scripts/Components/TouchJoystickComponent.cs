using UnityEngine;
using UnityEngine.UI;
public struct TouchJoystickComponent
{
    public RectTransform joystick;
    public RectTransform joystick_stick;

    public Vector3 joystick_start_point;
    public Vector3 joystick_touch_point;

    public float joystick_radius;
    public float joystic_blindspot_zone_vertical;
    public float joystic_blindspot_zone_horisontal;
    public float joystic_screen_border_value;
}