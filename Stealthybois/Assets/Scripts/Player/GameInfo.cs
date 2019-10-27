using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameInfo : MonoBehaviour {
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public static string PlayerName { get; set; }
    public static BaseCharClass PlayerClass { get; set; }
    public static bool PlayerDetected { get; set; }
    public static bool PlayerWon { get; set; }
    public static int PlayerLevel { get; set; }
    public static int AbilityCharges { get; set; }
    public static int PlayerDeaths { get; set; }
}
