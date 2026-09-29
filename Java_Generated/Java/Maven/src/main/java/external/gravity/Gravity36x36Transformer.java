package external.gravity;

import category_theory.interfaces.ICategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IObjectTransformer;

public class Gravity36x36Transformer extends Gravity36x36 implements ICategoryObject, IObjectTransformer {

    public  Gravity36x36Transformer(String name, IDesktop desktop)
    {
        this.name = name;
        this.desktop = desktop;
        desktop.addCategoryObject(this);
        for (var i = 0; i < out.length; i++)
        {
            out[i] = new double[]{0};
        }
    }

    @Override
    public String getCategoryObjectName() {
        return name;
    }

    @Override
    public IDesktop getDesktop() {
        return desktop;
    }

    protected  String name;

    protected IDesktop desktop;

    @Override
    public String[] getInput() {
        return inputs;
    }

    @Override
    public String[] getOutput() {
        return outputs;
    }

    @Override
    public Object getInputType(int i) {
        return type;
    }

    @Override
    public Object getOutputType(int i) {
        return type;
    }

    @Override
    public void calculate(Object[] input, Object[] output)
    {
        var x = (double[])input[0];
        var y = (double[])input[1];
        var z = (double[])input[2];
        Forces(n0, nk, x[0], y[0], z[0], out[0], out[1], out[2]);
        System.arraycopy(out, 0, output, 0, output.length);
    }

    double[][] out = new double[3][];


    protected double[] type = new double[0];

    /// <summary>
    /// Inputs
    /// </summary>

    protected String[] inputs = new String[] { "x", "y", "z" };
    /// <summary>
    /// Outputs
    /// </summary>

    protected  String[] outputs = new String[]{ "Gx", "Gy", "Gz" };



}
