using System;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.EventSystems;

public class LoadAsset : MonoBehaviour, IPointerClickHandler
{
    public async void OnPointerClick(PointerEventData eventData)
    {
        // タイプ指定しない場合Texture2Dアセットもロードされてしまい、その後のLoadAssetでエラーになる
        // var locations = await Addressables.LoadResourceLocationsAsync("OnePiece").Task;
        var locations = await Addressables.LoadResourceLocationsAsync("OnePiece", typeof(Sprite)).Task;
        
        foreach (var location in locations)
        {
            Addressables.LoadAssetAsync<Sprite>(location).Completed += (op =>
            {
                Debug.Log($"{op.Result.name} loaded");
            });
        }
    }
}
