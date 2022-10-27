using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

public class StartScene : MonoBehaviour
{
   
    private EcsWorld ecsWorld;
    private EcsSystems systems;
   

    [SerializeField] private CameraConfigSO cameraConfig;
    [SerializeField] private TouchJoysticConfigSO touchJoysticConfig;
    [SerializeField] private PhysicsConfigSO physicsConfig;

    [SerializeField] private LevelsPrefabsSO levelsPrefabs;
    [SerializeField] private BotCamponentPrefabsSO botComponentsPrefabs;
    
    private TouchJoysticView touchJoysticView;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    void StartGame()
    {
        ecsWorld = new EcsWorld();
        systems = new EcsSystems(ecsWorld);

        var gameData = new GameData();

        touchJoysticView=FindObjectOfType<TouchJoysticView>();


        touchJoysticConfig.joystick = touchJoysticView.joystick;
        touchJoysticConfig.joystickStick = touchJoysticView.joystickStick;
        gameData.touchJoysticConfig = touchJoysticConfig;

        gameData.cameraConfig = cameraConfig;
        gameData.levelsPrefabs=levelsPrefabs;
        gameData.botComponentsPrefabs = botComponentsPrefabs;

        gameData.physicsConfig = physicsConfig;

        systems
            .Add(new PlayerDataSystem())
            .Add(new SpawnSystem())
            .Add(new GravitySystem())
            .Add(new ChassisRotateSystem())
            .Add(new PlayerMoveSystem())
            .Add(new PlayerDataSystem())

            .Add(new PlayerSystem())
            .Add(new TouchJoysticSystem())
            .Add(new CameraSystem())
            .Add(new PlayerTargetingSystem())
            .Add(new TorsoRotateSystem())

            .Inject(gameData);
        
        #if UNITY_EDITOR
        EcsWorldObserver.Create(ecsWorld);
#endif

        systems.ProcessInjects();
        systems.Init();
       

#if UNITY_EDITOR
       EcsSystemsObserver.Create(systems);
     
#endif
    }
    private void Update()
    {
        systems.Run();
    }

    private void FixedUpdate()
    {
       
    }

    private void OnDestroy()
    {
        systems.Destroy();
        systems=null;
        ecsWorld.Destroy();
        ecsWorld=null;
    }
}
