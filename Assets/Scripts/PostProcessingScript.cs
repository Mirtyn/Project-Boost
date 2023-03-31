using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingScript : ProjectBehaviour
{
    //[SerializeField] PostProcessProfile postProcessingProfile;
    //[SerializeField] new List<PostProcessProfile> postProcessingProfiles;
    [SerializeField] PostProcessProfile[] postProcessingProfiles;

    void Start()
    {
        foreach (PostProcessProfile profile in postProcessingProfiles)
        {
            if (ProjectBehaviour.UseAmbientOcclusion)
            {
                profile.GetSetting<AmbientOcclusion>().active = true;
            }
            else
            {
                profile.GetSetting<AmbientOcclusion>().active = false;
            }

            if (ProjectBehaviour.UseBloom)
            {
                profile.GetSetting<Bloom>().active = true;
            }
            else
            {
                profile.GetSetting<Bloom>().active = false;
            }

            if (ProjectBehaviour.UseVignette)
            {
                profile.GetSetting<Vignette>().active = true;
            }
            else
            {
                profile.GetSetting<Vignette>().active = false;
            }
        }
    }
}
