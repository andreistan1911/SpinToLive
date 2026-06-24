using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState State { get; private set; }

    private static GameManager instance;
  
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        State = GameState.MainMenu;
        EnterState(State);
    }

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameManager>();
                if (instance == null)
                {
                    GameObject obj = new("GameManager");
                    instance = obj.AddComponent<GameManager>();
                }
            }
            return instance;
        }
    }

    public void ChangeState(GameState newState)
    {
        ExitState(State);

        State = newState;

        EnterState(State);
    }

    private void EnterState(GameState state)
    {
        switch (state)
        {
            //case GameState.MainMenu:
            //    ShowMainMenu();
            //    break;

            case GameState.Playing:
                GameStateActions.StartPlaying();
                break;

            //case GameState.LevelUpMenu:
            //    ShowLevelUpMenu();
            //    break;

            //case GameState.FirstBoss:
            //    SpawnFirstBoss();
            //    break;

            //case GameState.SecondBoss:
            //    SpawnSecondBoss();
            //    break;

            //case GameState.GameOverMenu:
            //    ShowGameOver();
            //    break;
        }
    }

    private void ExitState(GameState state)
    {
        switch (state)
        {
            //case GameState.MainMenu:
            //    HideMainMenu();
            //    break;

            //case GameState.LevelUpMenu:
            //    HideLevelUpMenu();
            //    break;

            //case GameState.GameOverMenu:
            //    HideGameOverMenu();
            //    break;
        }
    }
}
