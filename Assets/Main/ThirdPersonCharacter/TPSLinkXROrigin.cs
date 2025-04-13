using UnityEngine;

public class TPSLinkXROrigin : MonoBehaviour {
    [Header("Transform Source References")]
    [SerializeField] GameObject root;
    [SerializeField] GameObject CameraHead;
    [SerializeField] GameObject LeftController;
    [SerializeField] GameObject RightController;

    [Header("Transform Follower References")]
    [SerializeField] GameObject ThirdPersonCharacter;
    [SerializeField] GameObject HeadIKTarget;
    [SerializeField] GameObject LeftIKTarget;
    [SerializeField] GameObject RightIKTarget;
    float modelYawOffset;


    private void Awake() {

        SyncPosRotation(HeadIKTarget, CameraHead);
        SyncPosRotation(LeftIKTarget, LeftController);
        SyncPosRotation(RightIKTarget, RightController);
        modelYawOffset = ThirdPersonCharacter.transform.eulerAngles.y - CameraHead.transform.eulerAngles.y;


    }


    private void Update() {
        ThirdPersonCharacter.transform.position = root.transform.position;
        ThirdPersonCharacter.transform.rotation = Quaternion.Euler(0, CameraHead.transform.eulerAngles.y+ modelYawOffset, 0);

    }

    void SyncPosRotation(GameObject Follower, GameObject Source) {
        Follower.transform.SetParent(Source.transform);
        Follower.transform.localPosition = Vector3.zero;
        Follower.transform.localRotation = Quaternion.identity;
    }

}
