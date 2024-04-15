using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class OfferRequester : MonoBehaviour
{
    public UnityEvent<OfferDto> _offer0Received = new UnityEvent<OfferDto>();
    public UnityEvent<OfferDto> _offer1Received = new UnityEvent<OfferDto>();

    [SerializeField] private float _testDelay;

    public void QueryOffer()
    {
        StartCoroutine(GetOffer0());
        StartCoroutine(GetOffer1());
    }

    private IEnumerator GetOffer0()
    {
        using var request = UnityWebRequest.Get("https://kovgamedev.ru/TestTaskJustMoby/query0.json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            _offer0Received.Invoke(OfferDto.CreateFromJson(request.downloadHandler.text));
        else
            throw new Exception($"Error during offer request: {request.error}");
    }

    private IEnumerator GetOffer1()
    {
        yield return new WaitForSeconds(_testDelay);

        using var request = UnityWebRequest.Get("https://kovgamedev.ru/TestTaskJustMoby/query1.json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            _offer1Received.Invoke(OfferDto.CreateFromJson(request.downloadHandler.text));
        else
            throw new Exception($"Error during offer request: {request.error}");
    }

    private void OnDestroy()
    {
        _offer0Received.RemoveAllListeners();
        _offer1Received.RemoveAllListeners();
    }
}
