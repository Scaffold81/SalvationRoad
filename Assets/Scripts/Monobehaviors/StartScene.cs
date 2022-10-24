using Leopotam.Ecs;
using Leopotam.Ecs.UnityIntegration;
using UnityEngine;

public class StartScene : MonoBehaviour
{
   
    private EcsWorld ecsWorld;
    private EcsSystems initSystems;
    private EcsSystems updateSystems;
    private EcsSystems fixedUpdateSystems;

    [SerializeField] private CameraConfigSO cameraConfig;
    [SerializeField] private LevelsPrefabsSO levelsPrefabs;
    [SerializeField] private BotCamponentPrefabsSO botComponentsPrefabs;

    // Start is called before the first frame update
    void Start()
    {
       
        StartGame();
    }
    void StartGame()
    {
        ecsWorld = new EcsWorld();
        var gameData = new GameData();
     

        gameData.cameraConfig = cameraConfig;
        gameData.levelsPrefabs=levelsPrefabs;
        gameData.botComponentsPrefabs = botComponentsPrefabs;

        initSystems = new EcsSystems(ecsWorld)
            .Add(new PlayerDataSystem())
            .Add(new SpawnSystem())
            .Add(new CameraSystem())
            .Inject(gameData);
        updateSystems = new EcsSystems(ecsWorld)
            .Add(new PlayerDataSystem())
            .Add(new CameraSystem())
            .Inject(gameData);
           
        fixedUpdateSystems = new EcsSystems(ecsWorld)
            .Inject(gameData);


#if UNITY_EDITOR
        EcsWorldObserver.Create(ecsWorld);
#endif

        initSystems.ProcessInjects();
        updateSystems.ProcessInjects();
        fixedUpdateSystems.ProcessInjects();

        initSystems.Init();
        updateSystems.Init();
        fixedUpdateSystems.Init();

#if UNITY_EDITOR
       EcsSystemsObserver.Create(initSystems);
       EcsSystemsObserver.Create(updateSystems);
       EcsSystemsObserver.Create(fixedUpdateSystems);
#endif
    }
    private void Update()
    {
        updateSystems.Run();
    }

    private void FixedUpdate()
    {
        fixedUpdateSystems.Run();
    }

    private void OnDestroy()
    {
        initSystems.Destroy();
        updateSystems.Destroy();
        fixedUpdateSystems.Destroy();
        ecsWorld.Destroy();
    }
}
