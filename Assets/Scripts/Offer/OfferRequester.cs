using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class OfferRequester : MonoBehaviour
{
    [SerializeField] private UnityEvent<OfferDto> _offer0Received = new UnityEvent<OfferDto>();
    [SerializeField] private float _testDelay;

    public void QueryOffer()
    {
        StartCoroutine(GetOffer());
    }

    private IEnumerator GetOffer()
    {
        yield return new WaitForSeconds(_testDelay);

        var randomQueryNumber = UnityEngine.Random.Range(0, 4);
        using var request = UnityWebRequest.Get($"https://kovgamedev.ru/TestTaskJustMoby/query{randomQueryNumber}.json");
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            _offer0Received.Invoke(OfferDto.CreateFromJson(request.downloadHandler.text));
        else
            throw new Exception($"Error during offer request: {request.error}");
    }

    private void OnDestroy()
    {
        _offer0Received.RemoveAllListeners();
    }
}
