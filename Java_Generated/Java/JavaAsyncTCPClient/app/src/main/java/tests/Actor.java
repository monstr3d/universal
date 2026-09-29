package tests;

import cancellation.Cancellation;
import external.utilities.date_time.OADateConverter;
import trading.database.classes.TcpTradingDatabaseHistoryInterface;
import trading.database.classes.TradingDatabaseHistoryInterface;

public class Actor {

    public void testSymbolsTrading()
    {
        try {
            var cancel = new Cancellation();
            var trd = new TcpTradingDatabaseHistoryInterface("31.10.82.229", 7168);

            TradingDatabaseHistoryInterface.set(trd);

            var s = trd.getSymbols(cancel);

            var g = s.get();
        } catch (Exception e) {
            throw new RuntimeException(e);
        }
    }

    public void testWhenAll()
    {
        AsyncWhenAllExample.run();
    }

    public void testSimpleFormula()
    {
        var r = new SimpleFormulaAdd();
        r.test();
    }
    public void testComposition()
    {
        var r = new FormulaCompositionAct();
        r.test();
    }

    public void testRecusveFeedback()
    {
        var r = new RecursvieFeedbackAct();
        r.test();
    }

    public void testRecusveFeedbackSimple()
    {
        var r = new RecursiveFeedbackSimpleAct();
        r.test();
    }


    public void testFeedbackFormula()
    {
        var r = new FeedbackFormulaAct();
        r.test();
    }



    public void testRandomTwo()
    {
        var r = new RandomTwoAct();
        r.test();
    }

    public void testTime()
    {
        double t =  1770463387;
        t = t / (24 * 60 * 60);
        System.out.println(t);
        var x = OADateConverter.fromOADate(t);
        System.out.println(x);
        System.out.println((OADateConverter.toOADate(x)));


    }

    public void testRandomFour()
    {
        var r = new RandomFourAct();
        r.test();
    }

    public void testPI()
    {
        var r = new PiAct();
        r.test();
    }

    public void testODE()
    {
        var r = new ODEAct();
        r.test();
    }

    public void testODE_Feedback()
    {
        var r = new ODE_FeedAct();
        r.test();
    }

    public void testOrbitalForecast(boolean b)
    {
        var r = new OrbitalForecastAct();
        if (b) {
            r.test();
            return;
        }
        r.test1();
    }



    public void testCondition()
    {
        var r = new ConditionAct();
        r.test();
    }

    public void testTransforRecursiveFeed()
    {
        var r = new Transform_Recursive_FeedAct();
        r.test();
    }


}
