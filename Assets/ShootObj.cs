
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
  public class ShootObj : MonoBehaviour{

  private Vector3 startingPosition;
  public Material inactiveMaterial;
  public Material gazedAtMaterial;

  private Camera cam;
	public GvrBasePointer pointer;
  public Vector3 pointerPosition;

	private bool pick;
  private bool gazing;

    void Start() {
		SetGazedAt(false);
    pointer = GvrPointerInputModule.Pointer;
    pick = false;
    cam = Camera.main;
    }

	void Update() {
    
    //For Pick function
		if(pick == true){

      //Get center of viewport position to translate to world point position
      //Shoot a ray in direction of camera facing to determine item position while picked up
      Vector3 p = cam.ViewportToWorldPoint(new Vector3(0.5f,0.5f,cam.nearClipPlane));
      Ray r = new Ray(p,cam.transform.forward);
    
      //Disable gravity to prevent collision clipping between block and pointer
    	GetComponent<Rigidbody>().isKinematic = true;
      
      //Clamp item y-pos to 0.1 to prevent falling through floor
    	if(r.GetPoint(3).y < 0.1){
    		transform.localPosition = new Vector3(r.GetPoint(3).x,0.08f,r.GetPoint(3).z);
			}else{
				transform.localPosition = r.GetPoint(3);
			}

		if(!gazing){
			if(Input.GetButton("Fire1")) {
			pick = false;
			}
		}
		
    	//Enable gravity back to normal
    	//Enable detect collision just in case
  	}else {
  		GetComponent<Rigidbody>().isKinematic = false;
    	GetComponent<Rigidbody>().detectCollisions = true;
  	}

	}

  public void PickupDrop() {
    pick = !pick;
  }

    public void SetGazedAt(bool gazedAt) {
      gazing = gazedAt;
      if (inactiveMaterial != null && gazedAtMaterial != null) {
        GetComponent<Renderer>().material = gazedAt ? gazedAtMaterial : inactiveMaterial;
        return;
      }
      GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;
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


  }
}
