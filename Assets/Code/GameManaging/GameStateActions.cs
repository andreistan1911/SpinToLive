using System.Collections;
using UnityEngine;


public class GameStateActions : MonoBehaviour
{
    private static GameStateActions instance;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static GameStateActions Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindAnyObjectByType<GameStateActions>();
                if (instance == null)
                {
                    GameObject obj = new("GameManager");
                    instance = obj.AddComponent<GameStateActions>();
                }
            }
            return instance;
        }
    }

    public static void StartPlaying()
    {
        // TODO: Implement logic to start the game, such as initializing player stats, spawning enemies, etc.
    }
}