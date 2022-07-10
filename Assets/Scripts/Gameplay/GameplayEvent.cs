using UnityEngine;
using UnityEngine.Events;

public static class GameplayEvent
{
    public static UnityAction onPlayerHealth;

    public static void PlayerHealth() => onPlayerHealth?.Invoke();
}
