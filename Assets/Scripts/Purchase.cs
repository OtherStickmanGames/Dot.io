using System.Collections;
using System.Collections.Generic;
using UnityEngine.Purchasing;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Purchasing.Extension;
using System;

public class Purchase : MonoBehaviour, IDetailedStoreListener
{
    [SerializeField] Button buttonNoAds;

    IStoreController m_StoreController; // The Unity Purchasing system.

    //Your products IDs. They should match the ids of your products in your store.
    string noAdsProductID = "com.otherstickmangames.dot.io.noads";

    private void Start()
    {
        InitializePurchasing();

        buttonNoAds.onClick.AddListener(NoAds_Clicked);
    }

    private void NoAds_Clicked()
    {
        m_StoreController.InitiatePurchase(noAdsProductID);
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Add products that will be purchasable and indicate its type.
        builder.AddProduct(noAdsProductID, ProductType.NonConsumable);

        UnityPurchasing.Initialize(this, builder);
    }



    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        OnInitializeFailed(error, null);
    }



    public void OnInitializeFailed(InitializationFailureReason error, string message)
    {
        var errorMessage = $"Purchasing failed to initialize. Reason: {error}.";

        if (message != null)
        {
            errorMessage += $" More details: {message}";
        }

        Debug.Log(errorMessage);
    }


    public void OnPurchaseFailed(Product product, PurchaseFailureDescription failureDescription)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}'," +
                $" Purchase failure reason: {failureDescription.reason}," +
                $" Purchase failure details: {failureDescription.message}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }



    private void RemoveAds()
    {
        PlayerPrefs.SetInt("removeads", 1);
        PlayerPrefs.Save();
        Debug.Log("Purchase: removeads");
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        //Retrieve the purchased product
        var product = purchaseEvent.purchasedProduct;

        //Add the purchased product to the players inventory
        if (product.definition.id == noAdsProductID)
        {
            RemoveAds();
        }
        

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        //We return Complete, informing IAP that the processing on our side is done and the transaction can be closed.
        return PurchaseProcessingResult.Complete;
    }
}
