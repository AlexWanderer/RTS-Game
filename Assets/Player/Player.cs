using UnityEngine;
using System.Collections.Generic;

using RTS;

public class Player : MonoBehaviour {
	
	public string username;
	public bool human;
	public HUD hud;
	public int startMoney, startMoneyLimit, startPower, startPoserLimit;

	private Dictionary< ResourceType, int> resources, resourceLimits;

	public WorldObject SelectedObject { get; set; }


	void Awake(){
		resources = InitResourceList ();
		resourceLimits = InitResourceList ();
	}


	// Use this for initialization
	void Start () {
		hud = GetComponentInChildren<HUD>();
	}
	
	// Update is called once per frame
	void Update () {
		if (human) {
			hud.SetResourceValues(resources, resourceLimits);
		}	
	}

	public void AddResources(ResourceType type, int amount)
	{
		resources [type] += amount;
	}

	public void IncrementResourceLimit(ResourceType type, int amount)
	{
		resourceLimits [type] += amount;
	}

	private Dictionary < ResourceType, int> InitResourceList()
	{
		Dictionary < ResourceType, int> list = new Dictionary<ResourceType, int> ();
		list.Add (ResourceType.Money, 0);
		list.Add (ResourceType.Power, 0);
		return list;
	}

	private void AddStartResourceLimits()
	{
		IncrementResourceLimit (ResourceType.Money, startMoneyLimit);
		IncrementResourceLimit (ResourceType.Power, startPoserLimit);

	}

	private void AddStartResources()
	{
		AddResources (ResourceType.Money, startMoney);
		AddResources (ResourceType.Power, startPower);
	}
}
