package measurements;

import diagram.interfaces.IDesktop;
import general_service.interfaces.IAssociatedObject;
import measurements.filters.Average;
import measurements.filters.Donchian;
import measurements.interfaces.IFilter;
import measurements.interfaces.IMeasurement;
import measurements.interfaces.IMeasurements;
import measurements.interfaces.IRunningChangeEvent;



public class FilterWrapper extends  DataConsumer implements IMeasurements {

    public FilterWrapper(String name, IDesktop desktop) {
        super(name, desktop);
    }


    //#region Fields

    protected FilterKind kind = FilterKind.Average;

    protected String input;

    protected IFilter filter;

    IMeasurement measurement;

    IMeasurement measurementOut;

    boolean isRunning = false;

    IRunningChangeEvent event;

    double[] value;


 public  void setKind(FilterKind kind)
 {
     this.kind = kind;
     setFilter();
 }

 public  FilterKind getKind()
 {
     return  kind;
 }

    @Override
    public void postSetArrow() {
        Find();
    }

    public String getInput()
    {
        return  input;
    }

    public  void setInput(String input)
    {
        this.input = input;
        Find();
    }

    public  IFilter getFilter()
    {
        return filter;
    }
        protected void setFilter() {
            switch (kind) {
                case Average:
                    if (filter instanceof Average) break;
                {
                    filter = new Average();
                }
                break;
                case DonchianMax:
                    var d = getDonchian();
                    d.setMax(true);
                    filter = d;
                    break;
                case DonchianMin:
                    var dd = getDonchian();
                    dd.setMax(false);
                    filter = dd;
                    break;
                default:
                    break;

            }
            measurementOut = new FilterMeasurement(this);
        }
    protected  void Find()
    {
        measurement = mPefrformer.getMeasurement(this, input);
    }


    Donchian getDonchian()
    {
        return   filter instanceof  Donchian ? (Donchian)filter : new Donchian();
    }

    @Override
    public int getMeasurementsCount() {
        return 1;
    }

    @Override
    public IMeasurement getMeasurement(int i) {
        return measurement;
    }

    @Override
    public void updateMeasurements() {
  //   var !!!
//value = filter.getFilterValue();
    }

    @Override
    public void addMeasurement(IMeasurement measurement) {

    }


    public enum FilterKind {
        Average,
        DonchianMax,
        DonchianMin

    }

    class FilterMeasurement implements IMeasurement, IAssociatedObject
    {

         public FilterMeasurement(FilterWrapper filter)
        {
            this.filter = filter;
        }


        FilterWrapper filter;

         double[] type = new double[]{};


        @Override
        public String getMeasurementName() {
            return "Output";
        }

        @Override
        public Object getMeasurementType() {
            return type;
        }

        @Override
        public Object getMeasurementValue() {
            return filter.value;
        }

        @Override
        public Object getAssociatedObject() {
            return filter;
        }

        @Override
        public void setAssociatedObject(Object obj) {

        }
    }

}



