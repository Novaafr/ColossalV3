
using Colossal.Menu;
using Colossal.Patches;
using GorillaLocomotion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.XR;
using Valve.VR;
namespace Colossal.Mods
{
    public class PullMod : MonoBehaviour
    {
        public void FixedUpdate()
        {
            if (PluginConfig.pullmod)
            {
                string bind = CustomBinding.GetBinds("pullmod"); 

                if (string.IsNullOrEmpty(bind) || bind == "UNBOUND")
                {
                    return; 
                }

                if (ControlsV2.GetControl(bind))
                {
                    Vector3 plrTrans = GTPlayer.Instance.transform.position;
                    if (GTPlayer.Instance.IsHandTouching(false) || GTPlayer.Instance.IsHandTouching(true))
                    {
                        GTPlayer.Instance.transform.forward += new Vector3(plrTrans.x * 10f, 0, plrTrans.z * 10f);
                    }
                    return;
                }
            }
            else
            {
                UnityEngine.Object.Destroy(this.GetComponent<PullMod>());
            }
        }
    }
}
