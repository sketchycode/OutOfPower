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
    public HullRepair hullRepair;

    public Color buttonInactiveColor;
    public Color shipDisplayInactiveColor;
    public Color activeColor;

    public ProgressBar powerBar;
    public ProgressBar hullStrength;
    public ProgressBar crewHealth;
    public Image lifeSupportIndicator;
    public Image spaceBrakesIndicator;
    public Image backLeftThrusterIndicator;
    public Image backRightThrusterIndicator;
    public Image frontThrusterIndicator;
    public Image shieldsIndicator;
    public Image shieldsButtonIndicator;
    public Image hullRepairIndicator;
    
    void Update()
    {
        powerBar.value = ship.CurrentPower / ship.maxPower;
        hullStrength.value = ship.hullStrength;
        crewHealth.value = ship.crewHealth;

        lifeSupportIndicator.color = lifeSupport.IsActivated ? activeColor : buttonInactiveColor;
        spaceBrakesIndicator.color = spaceBrakes.IsActivated ? activeColor : buttonInactiveColor;
        backLeftThrusterIndicator.color = backLeftThruster.IsActivated ? activeColor : shipDisplayInactiveColor;
        backRightThrusterIndicator.color = backRightThruster.IsActivated ? activeColor : shipDisplayInactiveColor;
        frontThrusterIndicator.color = frontThruster.IsActivated ? activeColor : shipDisplayInactiveColor;
        shieldsIndicator.color = shields.IsActivated ? activeColor : shipDisplayInactiveColor;
        shieldsButtonIndicator.color = shields.IsActivated ? activeColor : buttonInactiveColor;
        hullRepairIndicator.color = hullRepair.IsActivated ? activeColor : buttonInactiveColor;
    }
}
