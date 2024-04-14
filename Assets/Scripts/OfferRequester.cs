using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class OfferRequester : MonoBehaviour
{
    public UnityEvent<OfferDto> _offerReceived = new UnityEvent<OfferDto>();

    private void Start()
    {
        QueryOffer();
    }

    public void QueryOffer()
    {
        StartCoroutine(GetOffer());
    }

    private IEnumerator GetOffer()
    {
        using var request = UnityWebRequest.Get("https://kovgamedev.ru/TestTaskJustMoby/query0.json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            _offerReceived.Invoke(OfferDto.CreateFromJson(request.downloadHandler.text));
        else
            throw new Exception($"Error during offer request: {request.error}");
    }

    private void OnDestroy()
    {
        _offerReceived.RemoveAllListeners();
    }
}
