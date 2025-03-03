using Abstract3DConverters.Materials;

namespace Abstract3DConverters.Interfaces
{
    /// <summary>
    /// The creator of material
    /// </summary>
    public interface IMaterialCreator
    {

        /// <summary>
        /// Creates of the  image object
        /// </summary>
        /// <param name="image">The image</param>
        /// <returns>The image object</returns>
        object Create(Image image);


        /// <summary>
        /// Creates of the color object
        /// </summary>
        /// <param name="color">The color</param>
        /// <returns>The color object</returns>
        object Create(Color color);


        /// <summary>
        /// Creates of the material group object
        /// </summary>
        /// <param name="material">The material group</param>
        /// <returns>The  material group object</returns>
        object Create(MaterialGroup material);

        /// <summary>
        /// Creates of the diffuse material object
        /// </summary>
        /// <param name="material">The diffuse material</param>
        /// <returns>The  diffuse material object</returns>
        object Create(DiffuseMaterial material);

        /// <summary>
        /// Creates of the specular material object
        /// </summary>
        /// <param name="material">The specular material</param>
        /// <returns>The  specular material object</returns>
        object Create(SpecularMaterial material);

        /// <summary>
        /// Creates of the emissive material object
        /// </summary>
        /// <param name="material">The emissive material</param>
        /// <returns>The  emissive material object</returns>
        object Create(EmissiveMaterial material);


        /// <summary>
        /// Creates of the material group object
        /// </summary>
        /// <param name="material">The material</param>
        /// <returns>The  material  object</returns>
        object Create(Material material);

        /// <summary>
        /// Creates effect
        /// </summary>
        /// <param name="effect">The effect</param>
        /// <returns>The effect object</returns>
        object Create(Effect effect);


        /// <summary>
        /// Adds a material to a group
        /// </summary>
        /// <param name="group">The group</param>
        /// <param name="value">The material</param>
        void Add(object group, object value);

        /// <summary>
        /// Sets image to a material
        /// </summary>
        /// <param name="effect">The effect</param>
        /// <param name="image">The image</param>
        object SetImage(object effect, object image);

        /// <summary>
        /// Set opacity to a material
        /// </summary>
        /// <param name="effect">The effect</param>
        /// <param name="opacity">The opacity</param>
        void SetOpacity(object effect, float opacity);

      }
}
