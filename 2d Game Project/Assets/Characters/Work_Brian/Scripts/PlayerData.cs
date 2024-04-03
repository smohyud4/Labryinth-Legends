using UnityEngine;
[CreateAssetMenu(menuName = "Scriptable Objects/Player Data")]
public class PlayerData : ScriptableObject
{
    public float health;
    public float maxHealth = 100;

    public float move_speed = 100;
}


