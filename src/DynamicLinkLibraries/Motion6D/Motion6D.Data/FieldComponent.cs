using PhysicalField.Interfaces;

namespace Motion6D
{
    class FieldComponent
    {

        #region Fields

        IPhysicalField field;

        int num;

        #endregion

        #region Ctor

        internal FieldComponent(IPhysicalField field, int number)
        {
            this.field = field;
            this.num = number;
        }

        #endregion


        #region Members

        internal object this[double[] position]
        {
            get
            {
                return field[position][num];
            }
        }

        #endregion
    }
}
