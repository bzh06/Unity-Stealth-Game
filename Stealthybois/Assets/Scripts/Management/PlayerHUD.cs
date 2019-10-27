using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour {
    public Text abilityCharges;
    // Update is called once per frame
    void Update () {
        abilityCharges.text = "Ability Charges: " + GameInfo.AbilityCharges.ToString();
	}
}
