using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;
    
    [HideInInspector] public GameObject turret;
    [HideInInspector] public TurretBlueprint turretBlueprint;
    [HideInInspector] public bool isUpgraded = false;


    private Renderer rend;
    private Color startColor;

    private BuildManager _buildManager;
    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        
        _buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        

        if (turret != null)
        {
            _buildManager.SelectNode(this);
            return;
        }
        
        if (!_buildManager.CanBuild)
            return;

        BuildTurret(_buildManager.GetTurretToBuild());
        
    }

    void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
        {
            Debug.Log("not enough money to build that");
            return;
        }

        PlayerStats.Money -= blueprint.cost;
        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        turretBlueprint = blueprint;

        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);

        Destroy(effect, 5f);

        Debug.Log("Turret build!");
    }

    public void UpgradeTurret()
    {

        // upgrade just dmg and attack speed by changing numbers in the future 

        if (PlayerStats.Money < turretBlueprint.upgradeCost)
        {
            Debug.Log("not enough money to upgrade");
            return;
        }

        PlayerStats.Money -= turretBlueprint.upgradeCost;

        // Get rid of the old turret
        Destroy(turret);

        // Build upgraded turret
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(_buildManager.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        isUpgraded = true;

        Debug.Log("Turret upgraded!");
    }

    public void SellTurret()
    {
        PlayerStats.Money += turretBlueprint.GetSellAmount();
        // sell effect
        GameObject effect = (GameObject)Instantiate(_buildManager.sellEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Destroy(turret);
        turretBlueprint = null;
    }
        

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
    
    void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!_buildManager.CanBuild)
            return;

        if (_buildManager.HasMoney)
        {
            rend.material.color = hoverColor;
        }
        else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
