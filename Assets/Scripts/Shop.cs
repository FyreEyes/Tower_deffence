using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{

    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;
    
    private BuildManager _buildManager;

    private void Start()
    {
        _buildManager = BuildManager.instance;
    }

    public void SelectStandardTurret()
    {
        Debug.Log("Standard turret selected");
        _buildManager.SelectTurretToBuild(standardTurret);
    }   
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile launcher selected");
        _buildManager.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer selected");
        _buildManager.SelectTurretToBuild(laserBeamer);
    }
}
