using Leopotam.Ecs;
using UnityEngine;


public class TouchJoysticSystem :  IEcsInitSystem,IEcsRunSystem
{
    private EcsWorld ecsWorld;
    private GameData gameData;

    private EcsFilter<PlayerComponent> playerFilter;

  
    private TouchJoystickComponent joysticComponent;

    public void Init()
    {
        var joysticEntity = ecsWorld.NewEntity();
        ref var _joysticComponent = ref joysticEntity.Get<TouchJoystickComponent>();
        joysticComponent = _joysticComponent;

        var joysticView = MonoBehaviour.FindObjectOfType<TouchJoysticView>();

        joysticComponent.joystick_stick = gameData.touchJoysticConfig.joystickStick;
        joysticComponent.joystick = gameData.touchJoysticConfig.joystick;
        joysticComponent.joystick_radius = gameData.touchJoysticConfig.joystick_radius;

        joysticComponent.joystic_blindspot_zone_horisontal = gameData.touchJoysticConfig.joystic_blindspot_zone_horisontal;
        joysticComponent.joystic_blindspot_zone_vertical = gameData.touchJoysticConfig.joystic_blindspot_zone_vertical;

        joysticComponent.joystic_screen_border_value = gameData.touchJoysticConfig.joystic_screen_border_value;
        
        joysticComponent.joystick.gameObject.SetActive(false);
        joysticComponent.joystick_stick.gameObject.SetActive(false);
    }

    public void Run()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            if (Input.mousePosition.x > joysticComponent.joystic_screen_border_value && Input.mousePosition.x < Screen.width - joysticComponent.joystic_screen_border_value)
            {
                JoysticActive();
            }
        }
        else
        {
            joysticComponent.joystick_direction = Vector3.zero;
            joysticComponent.joystick.gameObject.SetActive(false);
            joysticComponent.joystick_stick.gameObject.SetActive(false);
        }

#else
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > joysticComponent.joystic_screen_border_value && Input.GetTouch(0).position.x < Screen.width - joysticComponent.joystic_screen_border_value)
            {
                JoysticActive();
            }
        }
        else
        {
            joysticComponent.joystick_direction = Vector3.zero;
            joysticComponent.joystick.gameObject.SetActive(false);
            joysticComponent.joystick_stick.gameObject.SetActive(false);
        }
#endif
        foreach (var i in playerFilter)
        {
            ref var playerComponent = ref playerFilter.Get1(i);
          
            playerComponent.moveDirection = new Vector3(joysticComponent.joystick_direction.x, 0, joysticComponent.joystick_direction.y);
        }
    }
    private void JoysticActive()
    {
#if UNITY_EDITOR
       
        if (Input.GetMouseButtonDown(0))
        {
            joysticComponent.joystick_start_point = Input.mousePosition;
            joysticComponent.joystick.transform.position = joysticComponent.joystick_start_point;
        }

        if (Input.GetMouseButton(0))
        {
            joysticComponent.joystick.gameObject.SetActive(true);
            joysticComponent.joystick_stick.gameObject.SetActive(true);

            joysticComponent.joystick_touch_point = Input.mousePosition;
        }
        

        if (Vector3.Distance(joysticComponent.joystick_start_point, joysticComponent.joystick_touch_point) <= joysticComponent.joystick_radius / 2)
        {
            joysticComponent.joystick_stick.transform.position = joysticComponent.joystick_touch_point;
        }
        else
        {
            Vector3 dir_stick = (joysticComponent.joystick_touch_point - joysticComponent.joystick_start_point).normalized;
           
            joysticComponent.joystick_stick.transform.position = dir_stick;
            joysticComponent.joystick_stick.transform.position = joysticComponent.joystick_start_point + (dir_stick.normalized * joysticComponent.joystick_radius / 2);
        }
        Vector3 dir = (joysticComponent.joystick_touch_point - joysticComponent.joystick_start_point).normalized;
        joysticComponent.joystick_direction = dir;
#else
        if (Input.GetTouch(0).phase == TouchPhase.Began)
        {
            joysticComponent.joystick_start_point = Input.GetTouch(0).position;
            joysticComponent.joystick.transform.position = joysticComponent.joystick_start_point;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            joysticComponent.joystick.gameObject.SetActive(true);
            joysticComponent.joystick_stick.gameObject.SetActive(true);

            joysticComponent.joystick_touch_point = Input.GetTouch(0).position;
        }
        else if (Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            joysticComponent.joystick.gameObject.SetActive(false);
            joysticComponent.joystick_stick.gameObject.SetActive(false);
        }
        if (Vector3.Distance(joysticComponent.joystick_start_point, joysticComponent.joystick_touch_point) <= joysticComponent.joystick_radius / 2)
        {
            joysticComponent.joystick_stick.transform.position = joysticComponent.joystick_touch_point;
        }
        else
        {
            Vector3 dir = (joysticComponent.joystick_touch_point - joysticComponent.joystick_start_point).normalized;
            joysticComponent.joystick_direction = dir;
            joysticComponent.joystick_stick.transform.position = dir;
            joysticComponent.joystick_stick.transform.position = joysticComponent.joystick_start_point + (dir.normalized * joysticComponent.joystick_radius / 2);
        }

        
        

#endif
    }

    
}
