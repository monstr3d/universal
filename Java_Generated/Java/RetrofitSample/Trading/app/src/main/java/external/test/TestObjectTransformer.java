package external.test;

import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import measurements.interfaces.IObjectTransformer;

import java.util.HashMap;
import java.util.Map;

public class TestObjectTransformer  extends CategoryObject implements IObjectTransformer
{
    String[]  inp = new String[]{"a", "b", "c", "d"};
    String[]  outp = new String[]{"a", "b", "c", "d"};
    double[] a = new double[0];
    double[][] out = new double[4][];

    protected  double coefficient = 0;

    public TestObjectTransformer(String name, IDesktop desktop) {
        super(name, desktop);
        for (var i = 0; i < out.length; i++) {
            out[i] = new double[]{0};
        }
        var map = new HashMap<String, Object>() {
            {
                put("1", new double[]{1});
                put("2", new double[]{2});
            }
        };
    }

    @Override
    public String[] getInput() {
        return inp;
    }

    @Override
    public String[] getOutput() {
        return outp;
    }

    @Override
    public Object getInputType(int i) {
        return a;
    }

    @Override
    public Object getOutputType(int i) {
        return a;
    }

    @Override
    public void calculate(Object[] input, Object[] output) {
        var x = (double[])input[0];
        var a = x[0];
        x = (double[])input[1];
        var b = x[0];
        x = (double[])input[2];
        var c = x[0];
        x = (double[])input[3];
        var d = x[0];
        out[0][0] = coefficient * (a + b);
        out[1][0] = coefficient * b * c;
        out[2][0] =  coefficient * (c + Math.sin(d));
        System.arraycopy(out, 0, output, 0, output.length);

    }
}
