using System;


namespace DataPerformer.Interfaces.Attributes
{
    public class InsertIntoChilldrenCollectionAttribute : Attribute
    {
        public InsertIntoChilldrenCollectionAttribute(bool insert)
        {
            Insert = insert;
        }

        public bool Insert { get; set; }
    }
}
