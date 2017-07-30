using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class View : MonoBehaviour
{
    public ShipController ship;

    public Thruster backLeftThruster;
    public Thruster backRightThruster;
    public Thruster frontThruster;

    public SpaceBrakes spaceBrakes;
    public LifeSupport lifeSupport;
    public Shields shields;

    public Color inactiveColor;
    public Color activeColor;

    public Slider powerBar;
    public Text powerBarText;
    public Image lifeSupportIndicator;
    public Image spaceBrakesIndicator;
    public Image backLeftThrusterIndicator;
    public Image backRightThrusterIndicator;
    public Image frontThrusterIndicator;
    public Image shieldsIndicator;
    
    void Update()
    {
        powerBar.value = ship.CurrentPower / ship.maxPower;
        powerBarText.text = string.Format("{0:F0}/{1:F0}", ship.CurrentPower, ship.maxPower);

        lifeSupportIndicator.color = lifeSupport.IsActivated ? activeColor : inactiveColor;
        spaceBrakesIndicator.color = spaceBrakes.IsActivated ? activeColor : inactiveColor;
        backLeftThrusterIndicator.color = backLeftThruster.IsActivated ? activeColor : inactiveColor;
        backRightThrusterIndicator.color = backRightThruster.IsActivated ? activeColor : inactiveColor;
        frontThrusterIndicator.color = frontThruster.IsActivated ? activeColor : inactiveColor;
        shieldsIndicator.color = shields.IsActivated ? activeColor : inactiveColor;
    }
}
