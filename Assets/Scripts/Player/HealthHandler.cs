using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthHandler : MonoBehaviour
{

    // public static event Action OnPlayerDeath;

    public GameOverHandler gameOverHandler;
    public GameObject player;

    [SerializeField] private List<Health_Icon_Handler> _Icons;
    [SerializeField] public static int _currentHealth;

    public int PlayerHealth
    {
        get { return _currentHealth; }
        set { _currentHealth = value; }
    }

    void Start()
    {
        CheckScene(SceneManager.GetActiveScene());
    }

    // Update is called once per frame
    void Update()
    {
        CheckHealth();
    }

    private void OnEnable()
    {
        EventManager.current.onAddingPlayerHealth += CheckAddingHealth;
        EventManager.current.onSubtractPlayerHealth += CheckSubractionHealth;
    }

    private void OnDisable()
    {
        EventManager.current.onAddingPlayerHealth -= CheckAddingHealth;
        EventManager.current.onSubtractPlayerHealth -= CheckSubractionHealth;
    }

    private void CheckScene(Scene sceneName)
    {
        if (sceneName.name == e_SceneName.Stage1.ToString())
        {
            _currentHealth = 3;
            return;
        }
        if (sceneName.name == e_SceneName.Stage2.ToString())
        {
            _currentHealth = Database.GetProgress("LastHealth");
            // _currentHealth = 3;

            return;
        }
        if (sceneName.name == e_SceneName.Stage3.ToString())
        {
            _currentHealth = Database.GetProgress("LastHealth");
            return;
        }
        _currentHealth = Database.GetProgress("LastHealth");
    }

    private void CheckSubractionHealth(int playerHealth) => _currentHealth -= playerHealth;
    private void CheckAddingHealth(int playerHealth) => _currentHealth += playerHealth;
    private void CheckHealth()
    {
        switch (_currentHealth)
        {
            // full
            case 3:
                for (int i = 0; i < _Icons.Count; i++)
                    _Icons[i].AddHealth();
                Debug.Log($"Tinggal 3");
                break;

            // tinggal 2
            case 2:
                for (int i = 0; i < _Icons.Count; i++)
                {
                    _Icons[i].AddHealth();

                    if (_Icons[i].id > _currentHealth)
                        _Icons[i].RemoveHealth();
                    Debug.Log($"Tinggal 2");

                }
                break;

            //tinggal 1
            case 1:
                for (int i = 0; i < _Icons.Count; i++)
                {
                    _Icons[i].AddHealth();

                    if (_Icons[i].id > _currentHealth)
                        _Icons[i].RemoveHealth();
                    Debug.Log($"Tinggal 1");
                }
                break;

            //abis
            case 0:
                for (int i = 0; i < _Icons.Count; i++)
                    _Icons[i].RemoveHealth();
                Debug.Log($"Habis");

                //  GameOver Panel
                gameOverHandler.EnabledGameOverPanel();
                // OnPlayerDeath?.Invoke();

                // GameOverHandler.isGameOver = true;


                player.SetActive(false);
                break;

            default:
                _currentHealth = _currentHealth > 3 ? 3 : _currentHealth;
                break;
        }
    }
}
