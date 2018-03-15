
// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
namespace GoogleVR.GVRDemo {
	using System.Collections;
	using System.Collections.Generic;
  using UnityEngine;

  [RequireComponent(typeof(Collider))]
  public class DragDrop : MonoBehaviour{

  private Vector3 startingPosition;
  public Material inactiveMaterial;
  public Material gazedAtMaterial;

	private GvrBasePointer pointer;
  private Vector3 pointerPosition;

	private bool dragEnabled;

    void Start() {
		SetGazedAt(false);
		Drag(false);
    pointer = GvrPointerInputModule.Pointer;
    }

	void Update() {
    //update pointer position every tick
    pointerPosition = pointer.GetPointAlongPointer(3);

    //For Drag function
		if(dragEnabled == true){
      //Disable gravity to solve collision detection issue
      //if y-pos, clamp y-pos to 0.1 to prevent from falling through floor
      //Follow gaze if not
      GetComponent<Rigidbody>().isKinematic = true;
			if(pointerPosition.y < 0.1){
        transform.localPosition = new Vector3(pointerPosition.x,0.1f,pointerPosition.z);
      }else{
        transform.localPosition = pointerPosition;
      }
      //Enable gravity back to normal
      //Enable detect collision just in case
    }else {
      GetComponent<Rigidbody>().isKinematic = false;
      GetComponent<Rigidbody>().detectCollisions = true;
    }

	}

    public void SetGazedAt(bool gazedAt) {
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        return;
      }
      GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
    }

	public void Gazing() {
		
	}

    public void Reset() {
      transform.localPosition = startingPosition;
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

	public void Drag(bool dragging) {
		dragEnabled = dragging ? true : false;
	}

  }
}
