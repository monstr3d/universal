import category_theory.CategoryObject;
import diagram.interfaces.IDesktop;
import general_service.Entry;
import general_service.Performer;
import general_service.interfaces.IValue;
import generated.TestDesktop;
import tests.Actor;

import java.util.ArrayList;
import java.util.List;

//TIP To <b>Run</b> code, press <shortcut actionId="Run"/> or
// click the <icon src="AllIcons.Actions.Execute"/> icon in the gutter.
public class Main {
    public static void main(String[] args) {
        java.util.List<general_service.Entry<int[], String>> list = new java.util.ArrayList<>();
        list.add(new general_service.Entry(new int[] { 1, 2}, "" ));
        var a = new Actor();
        a.testSymbolsTrading();
 //       a.testWhenAll();
       // a.testTime();
    //a.testRandomTwo();
   //     a.testODE_Feedback();
      // a.testOrbitalForecast(true);
  //   a.testRecusveFeedback();
      // a.testRecusveFeedbackSimple();


        //   a.testFeedbackFormula();
     //   a.testSimpleFormula();
       // a.testComposition();
        if (false) {
            //    new generated.ODE_Feedback();
            //TIP Press <shortcut actionId="ShowIntentionActions"/> with your caret at the highlighted text
            // to see how IntelliJ IDEA suggests fixing it.
            System.out.printf("Hello and welcome!");

            for (int i = 1; i <= 5; i++) {
                //TIP Press <shortcut actionId="Debug"/> to start debugging your code. We have set one <icon src="AllIcons.Debugger.Db_set_breakpoint"/> breakpoint
                // for you, but you can always add more by pressing <shortcut actionId="ToggleLineBreakpoint"/>.
                System.out.println("i = " + i);
            }
        }
    }
}