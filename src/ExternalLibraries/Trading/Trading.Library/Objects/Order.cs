using CategoryTheory;
using DataPerformer.Interfaces;
using DataPerformer.Portable;
using Diagram.Interfaces;
using DataPerformer.Interfaces.Attributes;
using Trading.Library.Enums;

namespace Trading.Library.Objects
{
   [InsertIntoChilldrenCollection(true)]
    public class Order : DataConsumer, IPostSetArrow, 
        IMeasurements, IRunning, IIteratorConsumer
    {

        #region Fields 

        bool changed = false;

        protected bool isPost = false;

        double? currentPositionValue;

        bool isRunning = false;

        bool isMeaUpdated = false;

        double income = 0;

        IMeasurement[] measurements = [];

        protected string sellPrice = string.Empty;
        
        protected string buyPrice = string.Empty;
        
        protected string position = string.Empty;

        protected string date = string.Empty;

        IMeasurement positionM = null;

        IMeasurement buyPriceM = null;

        IMeasurement sellPriceM = null;

        IMeasurement currentDate = null;


        double? mSellPrice = null;

        double? mBuyPrice = null;


        #endregion

        #region Propreties

        Action<Order, PositionDirection> orderChanged;

        public event Action<Order, PositionDirection> OrderChanged
        {
            add { orderChanged += value; }
            remove { orderChanged -= value; }
        }

        public double EnterPrice
        {
            get;
            private set;
        } = 0;

        private double TempIncome
        {
            get;
            set;
        } = 0;

        public double ExitPrice 
        { get; private set; } = 0;

        public double EnterDate { 
            get; 
            private set; 
        } = 0;

        public double ExitDate { 
            get; 
            private set; 
        } = 0;

        double? dateValue;

        Action<IRunning, bool> running;


        #region

        #region Ctor


        public Order() : base(0)
        {
            measurements = [new PositionMeasurement(this),
                new IncomeMeasurement(this),
                new SellTaxMeasurement(this),
                new BuyTaxMeasurement(this)
            ];
        }

        #endregion

   
        #region Implementation of interfaces

        void IPostSetArrow.PostSetArrow()
        {
            isPost = false;
            Find();
        }

        IMeasurement IMeasurements.this[int number] => measurements[number];

        int IMeasurements.Count => measurements.Length;

        bool IMeasurements.IsUpdated { get => isMeaUpdated; set => isMeaUpdated = value; }
  
        void IMeasurements.UpdateMeasurements()
        {
            Update();
        }

        bool IRunning.IsRunning { get => isRunning; set => Start(value); }

        event Action<IRunning, bool> IRunning.Running
        {
            add
            {
                running += value;
            }

            remove
            {
                running -= value;
            }
        }

        public IIterator Iterator
        { get; private set; } = null;


        void IIteratorConsumer.Add(IIterator iterator)
        {
            if (iterator == null) return;
            if (Iterator != null)
            {
                throw new InvalidOperationException("Itertor already exists");
            }
            Iterator = iterator;
        }

        void IIteratorConsumer.Remove(IIterator iterator)
        {
            if (iterator == this.Iterator) this.Iterator = null;
        }


        #endregion


        #region Public Properties

        public string Position
        {
            get => position;
            set
            { position = value; Find(); }
        }


        public string Date
        {
            get => date;
            set { date = value; Find(); }
        }

        public string BuyPrice
        {
            get => buyPrice;
            set
            { buyPrice = value; Find(); }
        }

        public string SellPrice
        {
            get => sellPrice;
            set
            { sellPrice = value; Find(); }
        }

        #endregion



        #endregion Members

        public PositionType CurrentPositionType
        {
            get;
            private set;
        } = PositionType.None;

        public PositionType ClosedPositionType
        {
            get;
            private set;
        } = PositionType.None;

      
        public bool? IsOpened { get; set; } = null;

        PositionType LastPositionType
        {
            get;
            set;
        } = PositionType.None;

        PositionDirection positionDirection = PositionDirection.Closed;

        bool posChanged = false;

        public PositionDirection PositionDirection
        {
            get => positionDirection;
            set
            {
                posChanged = false;
                if (positionDirection == value) return;
                posChanged = true;
                positionDirection = value;
                if (positionDirection == PositionDirection.Closed) 
                { 
                    if (currentDate != null) 
                    {
                        ExitDate = dateValue.Value;
                    }
                }
                else
                {
                    if (currentDate != null)
                    {
                        EnterDate = dateValue.Value;
                    }
                }
            }
        }
        

        private double? CurrentPositionValue
        {
            get => currentPositionValue;
            set
            {
                if (value == currentPositionValue)
                {
                    changed = false;
                    return;
                }
                if (value == null)
                {
                    currentPositionValue = value;
                    return;
                }
                changed = true;
                var type = value.ToPositionType();
                if (LastPositionType == type) { changed = false; return; }
                PositionDirection = PositionDirection.ToDirection(type, LastPositionType);
                currentPositionValue = value;
                CurrentPositionType = type;
                LastPositionType = type;
            }
        }

        void Start(bool value)
        {
            isRunning = value;
            income = 0;
            ClosedIncome = 0;
            TempIncome = 0;
            EnterPrice = 0;
            ExitPrice = 0;
            CurrentPositionValue = null;
            CurrentPositionType = PositionType.None;
            LastPositionType = PositionType.None;
            PositionDirection = PositionDirection.Closed;
            CurrentPositionValue = null;
            running?.Invoke(this, value);
        }

        void Zero()
        {
            mSellPrice = null;
            mBuyPrice = null;
        }

   
        public double ClosedIncome
        { 
            get; 
            private set; 
        } = 0;

        void Update()
        {
            Zero();
            dateValue = currentDate.ToNullable<double>();
            CurrentPositionValue = positionM.ToNullable<double>();
            if (!changed)
            {
                return;
            }
            if (PositionDirection == PositionDirection.Closed)
            {
                if (TempIncome == 0)
                {
                    return;
                }
                if (TempIncome < 0)
                {
                    mSellPrice = sellPriceM.ToNullable<double>();
                    ExitPrice = mSellPrice.Value;
                    ClosedIncome = TempIncome + ExitPrice;
                    income += ClosedIncome;
                }
                else
                {
                    mBuyPrice = buyPriceM.ToNullable<double>();
                    ExitPrice = mBuyPrice.Value;
                    ClosedIncome = TempIncome - ExitPrice;
                    income += ClosedIncome;
                }
            }
            else
            {
                ClosedPositionType = CurrentPositionType;
                if (CurrentPositionType == PositionType.Long)
                {
                    mBuyPrice = buyPriceM.ToNullable<double>();
                    EnterPrice = mBuyPrice.Value;
                    TempIncome = -EnterPrice;
                }
                else
                {
                    mSellPrice = sellPriceM.ToNullable<double>();
                    EnterPrice = mSellPrice.Value;
                    TempIncome = EnterPrice;
                }
            }
            if (posChanged)
            {
                orderChanged?.Invoke(this, PositionDirection);
            }
        }

        void Find()
        {
            if (isPost) { return; }
            positionM = this.FindMeasurement(position, true);
            buyPriceM = this.FindMeasurement(buyPrice, true);
            sellPriceM = this.FindMeasurement(sellPrice, true);
            currentDate = this.FindMeasurement(date, true);
        }


        #endregion

        #region Classes

        class BasicMeasurement : IMeasurement, IAssociatedObject
        {
            protected Order order;

            object type;

            string name;

            protected Func<object> func = null;

            internal BasicMeasurement(string name, Order order, object type)
            {
                this.name = name;
                this.order = order;
                this.type = type;
            }

            Func<object> IMeasurement.Parameter => func;

            string IMeasurement.Name => name;

            object IMeasurement.Type => type;

            object IAssociatedObject.Object { get => order; set { } }
        }

        class PositionMeasurement : BasicMeasurement
        {
            internal PositionMeasurement(Order order)  : base("Position", order, (double)0)
            {
                func = f;
            }

            object f()
            {
                return order.CurrentPositionValue;
            }
        }

        class IncomeMeasurement : BasicMeasurement
        {
            internal IncomeMeasurement(Order order) : base("Income", order, (double)0)
            {
                func = f;
            }

            object f()
            {
                return order.income;
            }
        }

        class BuyTaxMeasurement : BasicMeasurement
        {
            internal BuyTaxMeasurement(Order order) : base("Buy Price", order, (double)0)
            {
                func = f;
            }

            object f()
            {
                var pr = order.mBuyPrice;
                if (pr != null)
                {

                }
                return order.mBuyPrice;
            }
        }

        class SellTaxMeasurement : BasicMeasurement
        {
            internal SellTaxMeasurement(Order order) : base("Sell Price", order, (double)0)
            {
                func = f;
            }

            object f()
            {
                var pr = order.mSellPrice;
                if (pr != null)
                {

                }
                return pr;
            }
        }


        #endregion

    }
}

 
