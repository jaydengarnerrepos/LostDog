using Rewired;
using UnityEngine;

class DogMovement : MonoBehaviour
{
    private Player Playerinput;
    private Camera mainCamera;
    private float cameraYAngle;
    public float movmentScaling = 0.3f;
    public float playerRotainAngle;
    [Range(1,10)]
    public float turnSmoothing = 2;

    void Start()
    {
        mainCamera = Camera.main;
        cameraYAngle = mainCamera.transform.eulerAngles.y;
        Playerinput = Rewired.ReInput.players.GetPlayer(RewiredConsts.Player.System);
    }

    void Update()
    {
        Vector2 playerAxisInput = Playerinput.GetAxis2D("Horizontal", "Vertical") * movmentScaling;
         playerRotainAngle = Vector3.SignedAngle(Vector3.up, playerAxisInput,Vector3.back);
         if (playerAxisInput.magnitude >  0)
         {
             transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(0,playerRotainAngle,0),1/turnSmoothing);
         }
         //TODO add CameraYangle changes;

        Vector3 newpos = transform.position + new Vector3(playerAxisInput.x,0,  playerAxisInput.y);
        transform.position = newpos;
    }
}