using Live2D.Cubism.Framework.LookAt;
using UnityEngine;
using Live2D.Cubism.Core;
//using Live2D.Cubism.Framework.MouthMovement;



namespace Live2D.Cubism.Framework.MouthMovement
{
    public class CubismLookTarget : MonoBehaviour, ICubismLookTarget
    {
        public Transform target=null;//to对应的那个gameobject

        public Vector3 GetPosition()
        {

            if (target == null) return Vector3.zero;
            var model = target.GetChild(0).GetComponent<AudiosourceBinding>().FindCubismModel();
            var tags = model
                      .Parameters
                      .GetComponentsMany<CubismLookParameter>();

            if (tags.Length > 0)
            {
                return tags[0].GetComponent<Transform>().position;

            }
            else
            {
                return model.GetComponent<Transform>().position;
            }
        }
        public bool IsActive()
        {
            return true;
        }
    }
}