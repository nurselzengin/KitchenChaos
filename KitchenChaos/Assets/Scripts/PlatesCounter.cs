using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;

    public KitchenObjectsSO plateObjectsSO;

    public float spawnTimer;
    public float spawnTimerMax = 4f;
    private int plateCount;
    private int plateCountMax = 4;

    private void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer > spawnTimerMax)
        {
            spawnTimer = 0;

            if(plateCount<plateCountMax)
            {
                plateCount++;
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player)
    {
        if (!player.HasKitchenObject())
        {
            if (plateCount > 0)
            {
                plateCount--;
                KitchenObject.SpawnKitchenObject(plateObjectsSO, player);
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);

            }
        }
    }


}
