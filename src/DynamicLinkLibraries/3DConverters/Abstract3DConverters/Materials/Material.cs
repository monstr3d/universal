namespace Abstract3DConverters.Materials
{
    /// <summary>
    /// Material
    /// </summary>
    public abstract class Material : ICloneable, IEquatable<Material>
    {
        /// <summary>
        /// Color
        /// </summary>
        public Color Color { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string ? Name { get; protected set; } = null;

        /// <summary>
        /// Clones itself
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return CloneIfself();
        }

        /// <summary>
        /// Protected clone
        /// </summary>
        /// <returns></returns>
        protected abstract object CloneIfself();

        /// <summary>
        /// The protected equals operation
        /// </summary>
        /// <param name="other">Other object</param>
        /// <returns>True if equals</returns>
        protected abstract bool Equals(Material other);

        #region IEquatable Members

        bool IEquatable<Material>.Equals(Material? other)
        {
            if (other == null)
            {
                return false;
            }
            return Equals(other);
        }

        #endregion

    }
}