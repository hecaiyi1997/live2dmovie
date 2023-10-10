using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Live2D.Cubism.Framework.MouthMovement;
using Live2D.Cubism.Core;

namespace Live2D.Cubism.Framework.MouthMovement
{
    public class AudiosourceBinding : MonoBehaviour
    {
        public Transform mouth;
        // Start is called before the first frame update
        void Start()
        {
            CubismAudioMouthInput input = gameObject.GetComponent<CubismAudioMouthInput>();

            input.AudioInput = gameObject.GetComponent<AudioSource>();

            //CubismModel model = gameObject.GetComponent<CubismModel>();
            var model = this.FindCubismModel();
            var tags = model
                      .Parameters
                      .GetComponentsMany<CubismMouthParameter>();

            if (tags.Length > 0)
            {
                mouth=tags[0].GetComponent<Transform>();

            }
            else
            {
                mouth= model.GetComponent<Transform>();
            }
        }
        public static Transform FindChild(Transform trans, string goName)
        {
            Transform child = trans.Find(goName);
            if (child != null)
                return child;

            Transform go = null;
            for (int i = 0; i < trans.childCount; i++)
            {
                child = trans.GetChild(i);
                go = FindChild(child, goName);
                if (go != null)
                    return go;
            }
            return null;
        }


        // Update is called once per frame
        void Update()
        {

        }
    }
}
