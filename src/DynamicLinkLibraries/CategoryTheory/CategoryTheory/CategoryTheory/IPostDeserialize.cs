namespace CategoryTheory
{
    /// <summary>
    /// Objects of this interface performs post deserialize operation
    /// </summary>
    public interface IPostDeserialize
    {
        /// <summary>
        /// Operation after deserialization
        /// </summary>
        void PostDeserialize();
    }
}
