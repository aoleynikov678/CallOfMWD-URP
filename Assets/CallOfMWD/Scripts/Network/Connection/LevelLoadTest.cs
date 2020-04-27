using lab.core;
using Photon.Pun;
using UnityEngine;

namespace lab.mwd
{
    public class LevelLoadTest : MonoBehaviour
    {
        [SerializeField] private string levelName;

        private NetworkEventsBus networkEventsBus;

        private void Awake()
        {
            networkEventsBus = ServiceLocator.Current.Get<NetworkEventsBus>();
            networkEventsBus.AddListener<OnChangeLevel>(OnChangeLevel);
        }

        private void OnDestroy()
        {
//            eventsReceiverService.OnChangeLevel -= OnChangeLevel;
        }

        private void Update()
        {
            if (PhotonNetwork.IsMasterClient)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    //.LoadLevel(levelName);
                    networkEventsBus.Fire(new OnChangeLevel(levelName, true));
                }
            }
        }
        
        private void OnChangeLevel(OnChangeLevel onChangeLevel)
        {
            Debug.Log($"Received level change {onChangeLevel.LevelPath}");
        }
    }
}