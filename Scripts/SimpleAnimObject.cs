using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Omnilatent.SimpleAnimation
{
    public class SimpleAnimObject : MonoBehaviour
    {
        SimpleAnimBase[] simpleAnim;

        private void Awake()
        {
            simpleAnim = GetComponents<SimpleAnimBase>();
        }

        public void Show()
        {
            foreach(var i in simpleAnim)
            {
                i.Show();
            }
        }

        public void Hide()
        {
            foreach (var i in simpleAnim)
            {
                i.Hide();
            }
        }
    }
}
