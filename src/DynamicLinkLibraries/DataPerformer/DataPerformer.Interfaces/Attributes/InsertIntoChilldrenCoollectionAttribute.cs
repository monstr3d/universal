using System;


namespace DataPerformer.Interfaces.Attributes
{
    public class InsertIntoChilldrenCoollectionAttribute : Attribute
    {
        public InsertIntoChilldrenCoollectionAttribute(bool insert)
        {
            Insert = insert;
        }

        public bool Insert { get; set; }
    }
}
