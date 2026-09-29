package general_service.android;

import android.util.Log;

import general_service.interfaces.IPrinter;

public class AndroidPrinter  implements IPrinter {
    @Override
    public void print(Object object) {

        Log.wtf("Parameter", object + "");
        }
    }

