﻿using UnityEngine;
using System.Collections.Generic;

using RTS;

public class Player : MonoBehaviour {
	
	public string username;
	public bool human;
	public HUD hud;
	public int startMoney, startMoneyLimit, startPower, startPowerLimit;

	private Dictionary< ResourceType, int > resources, resourceLimits;

	public WorldObject SelectedObject { get; set; }


	void Awake() {
		resources = InitResourceList();
		resourceLimits = InitResourceList();
	}


	// Use this for initialization
	void Start () {
		hud = GetComponentInChildren<HUD>();
		AddStartResourceLimits();
		AddStartResources();
	}
	
	// Update is called once per frame
	void Update () {
		if(human) {
			hud.SetResourceValues(resources, resourceLimits);
		}
	}

	public void AddResource(ResourceType rtype, int amount) 
	{
		resources[rtype] += amount;
	}
	
	public void IncrementResourceLimit(ResourceType type, int amount) 
	{
		resourceLimits[type] += amount;
	}

	public void AddUnit(string unitName, Vector3 spawnPoint, Vector3 rallyPoint, Quaternion rotation) {
		Units units = GetComponentInChildren< Units >();
		GameObject newUnit = (GameObject)Instantiate(ResourceManager.GetUnit(unitName),spawnPoint, rotation);
		newUnit.transform.parent = units.transform;
		Unit unitObject = newUnit.GetComponent< Unit >();
		if(unitObject && spawnPoint != rallyPoint) unitObject.StartMove(rallyPoint);
	}

	private Dictionary< ResourceType, int > InitResourceList() 
	{
		Dictionary< ResourceType, int > list = new Dictionary< ResourceType, int >();
		list.Add(ResourceType.Money, 0);
		list.Add(ResourceType.Power, 0);
		return list;
	}

	private void AddStartResourceLimits() 
	{
		IncrementResourceLimit(ResourceType.Money, startMoneyLimit);
		IncrementResourceLimit(ResourceType.Power, startPowerLimit);
	}
	
	private void AddStartResources() 
	{
		AddResource(ResourceType.Money, startMoney);
		AddResource(ResourceType.Power, startPower);
	}
}
