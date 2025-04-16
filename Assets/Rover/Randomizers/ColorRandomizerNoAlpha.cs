using System;
using UnityEngine.Perception.Randomization.Parameters;
using UnityEngine.Perception.Randomization.Randomizers.Tags;
using UnityEngine.Scripting.APIUpdating;

namespace UnityEngine.Perception.Randomization.Randomizers
{
    /// <summary>
    /// Randomizes the material color of objects tagged with a ColorRandomizerTag
    /// </summary>
    [Serializable]
    [AddRandomizerMenu("Perception/Color Randomizer Without Alpha")]
    [MovedFrom("UnityEngine.Perception.Randomization.Randomizers.SampleRandomizers")]
    public class ColorRandomizerNoAlpha : Randomizer
    {
        static readonly int k_BaseColor = Shader.PropertyToID("_BaseColor");

        /// <summary>
        /// The range of random colors to assign to target objects
        /// </summary>
        [Tooltip("The range of random colors to assign to target objects.")]
        public ColorHsvaParameter colorParameter;

        /// <summary>
        /// Randomizes the colors of tagged objects at the start of each scenario iteration
        /// </summary>
        protected override void OnIterationStart()
        {
            var tags = tagManager.Query<ColorRandomizerNoAlphaTag>();
            foreach (var tag in tags)
            {
                var renderer = tag.GetComponent<Renderer>();
                var sample = colorParameter.Sample();
                // keep current alpha
                sample.a = renderer.material.color.a;
                renderer.material.SetColor(k_BaseColor, sample);
            }
        }
    }
}
