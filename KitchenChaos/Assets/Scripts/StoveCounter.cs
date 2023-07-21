using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static CuttingCounter;

public class StoveCounter : BaseCounter, IHasProgress
{
    public event EventHandler<OnStateChangeEventArgs> OnStateChange;
    public event EventHandler<IHasProgress.OnProgressChangeArgs> OnProgressChange;

    public class OnStateChangeEventArgs
    {
        public State state;
    }

    [SerializeField] private FryingRecipeSO[] fryingRecipeSOArray;
    private float fryingTimer;
     private FryingRecipeSO fryingRecipeSO;
    private float burningTimer;
     private BurningRecipeSO burningRecipeSO;
    [SerializeField] private BurningRecipeSO[] burningRecipeSOArray;

    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burn,

    }
    private State state;
    private void Start()
    {
        state = State.Idle;
    }

    private void Update()
    {
        if (HasKitchenObject())
        {
            switch (state)
            {
                case State.Idle:

                    break;

                case State.Frying:

                    fryingTimer += Time.deltaTime;
                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.timer
                    });

                    if (fryingTimer > fryingRecipeSO.timer)
                    {
                       
                       
                        GetKitchenObject().DestroySelf();
                        KitchenObject.SpawnKitchenObject(fryingRecipeSO.output, this);
                        
                        state = State.Fried;
                        burningTimer = 0;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectsSO());
                    }
                    break;
                case State.Fried:
                    burningTimer += Time.deltaTime;
                    
                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
                    {
                        progressNormalized = burningTimer / fryingRecipeSO.timer
                    });

                    if (burningTimer > burningRecipeSO.burningTimerMax)
                    {
                        GetKitchenObject().DestroySelf() ;
                        KitchenObject.SpawnKitchenObject(burningRecipeSO.output, this);
                        state = State.Burn;
                        OnStateChange?.Invoke(this, new OnStateChangeEventArgs()
                        {
                            state = state
                        });
                        OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
                        {
                            progressNormalized = 0
                        });
                    }
                    break;
                case State.Burn:
                    break;
                default:
                    break;
            }
            
        }
        else
        {
            OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
            {
                progressNormalized = 0
            });
        }
    }
            
    
    public override void Interact(Player player)
    {
        if (!HasKitchenObject())
        {
            if (player.HasKitchenObject())
            {
                if (HasRecipeWithInpu(player.GetKitchenObject().GetKitchenObjectsSO()))
                {
                    player.GetKitchenObject().SetKitchenObjectParent(this);
                    
                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectsSO());

                    state = State.Frying;
                    fryingTimer = 0;
                    
                    OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
                    {
                        progressNormalized = fryingTimer / fryingRecipeSO.timer
                    });

                    OnStateChange?.Invoke(this, new OnStateChangeEventArgs()
                    {
                        state = state
                    });

                }
            }
            else
            {

            }
        }
        else
        {
            if (player.HasKitchenObject())
            {
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectsSO()))
                    {
                        GetKitchenObject().DestroySelf();

                        state = State.Idle;
                        OnStateChange?.Invoke(this, new OnStateChangeEventArgs()
                        {
                            state = state
                        });
                        OnProgressChange?.Invoke(this, new IHasProgress.OnProgressChangeArgs
                        {
                            progressNormalized = 0
                        });


                    }
                }

            }
            else
            {
                GetKitchenObject().SetKitchenObjectParent(player);
                state = State.Idle;
                OnStateChange?.Invoke(this, new OnStateChangeEventArgs()
                {
                    state = state
                });
                

            }
        }
    }
    private KitchenObjectsSO GetOutputForInput(KitchenObjectsSO inputkitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputkitchenObjectSO);

        if (fryingRecipeSO != null)
        {
            return fryingRecipeSO.output;
        }
        else
        {
            return null;
        }


    }

    private bool HasRecipeWithInpu(KitchenObjectsSO inputkitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputkitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectsSO inputkitchenObjectSO)
    {
        foreach (FryingRecipeSO fryingRecipeSO in fryingRecipeSOArray)
        {
            if (fryingRecipeSO.input == inputkitchenObjectSO)
            {
                return fryingRecipeSO;
            }
        }
        return null;
    }
    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectsSO inputkitchenObjectSO)
    {
        foreach (BurningRecipeSO burningRecipeSO in burningRecipeSOArray)
        {
            if( burningRecipeSO.input == inputkitchenObjectSO)
            {
                return burningRecipeSO;
            }
        }
        return null;
    }
}
