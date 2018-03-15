using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenView : MonoBehaviour {

    public GameObject player;

    public Material inactiveMaterial;

    public Material gazedAtMaterial;

    private Vector3 localPos;

    void Start() {
      localPos = transform.localPosition;
      SetGazedAt(false);
    }

    public void SetGazedAt(bool gazedAt) {
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        return;
      }
      GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }

    public void TeleportTo() {
      player.transform.localPosition = new Vector3(transform.localPosition.x,transform.localPosition.y + 1f, transform.localPosition.z );
    }

    public void Recenter() {
#if !UNITY_EDITOR
      GvrCardboardHelpers.Recenter();
#else
      if (GvrEditorEmulator.Instance != null) {
        GvrEditorEmulator.Instance.Recenter();
      }
#endif  // !UNITY_EDITOR
    }

  
}
