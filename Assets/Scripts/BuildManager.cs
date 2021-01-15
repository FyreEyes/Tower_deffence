using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }
    
    
    public GameObject buildEffect;
    public GameObject sellEffect;

    private TurretBlueprint _turretToBuild;
    private Node _selectedNode;
    
    public NodeUI nodeUI;

    public bool CanBuild => _turretToBuild != null;
    public bool HasMoney => PlayerStats.Money >= _turretToBuild.cost;
    
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        _turretToBuild = turret;
        
        DeselectNode();
    }

    public void SelectNode(Node node)
    {
        if (_selectedNode == node)
        {
            DeselectNode();
            return;
        }
        
        _selectedNode = node;
        _turretToBuild = null;

        nodeUI.SetTarget(node);
    }

    public void DeselectNode()
    {
        _selectedNode = null;
        nodeUI.Hide();
    }

    public TurretBlueprint GetTurretToBuild()
    {
        return _turretToBuild;
    }
}
